using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace BackEnd;

public static class AttendeeEndpoints
{
    public static void MapAttendeeEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Attendee").WithTags(nameof(Attendee));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Attendee.ToListAsync();
        })
        .WithName("GetAllAttendees")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Attendee>, NotFound>> (int attendee_id, ApplicationDbContext db) =>
        {
            return await db.Attendee.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Attendee_id == attendee_id)
                is Attendee model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAttendeeById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int attendee_id, Attendee attendee, ApplicationDbContext db) =>
        {
            var affected = await db.Attendee
                .Where(model => model.Attendee_id == attendee_id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Attendee_id, attendee.Attendee_id)
                  .SetProperty(m => m.Attendee_name, attendee.Attendee_name)
                  .SetProperty(m => m.Attendee_email, attendee.Attendee_email)
                  .SetProperty(m => m.Attendee_contact, attendee.Attendee_contact)
                  .SetProperty(m => m.Facebook_id, attendee.Facebook_id)
                  .SetProperty(m => m.Linkedin_id, attendee.Linkedin_id)
                  .SetProperty(m => m.git, attendee.git)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAttendee")
        .WithOpenApi();

        group.MapPost("/", async (Attendee attendee, ApplicationDbContext db) =>
        {
            db.Attendee.Add(attendee);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Attendee/{attendee.Attendee_id}",attendee);
        })
        .WithName("CreateAttendee")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int attendee_id, ApplicationDbContext db) =>
        {
            var affected = await db.Attendee
                .Where(model => model.Attendee_id == attendee_id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAttendee")
        .WithOpenApi();
    }
}
