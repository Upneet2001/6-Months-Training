using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace BackEnd;

public static class SessionEndpoints
{
    public static void MapSessionEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Session").WithTags(nameof(Session));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Session.ToListAsync();
        })
        .WithName("GetAllSessions")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Session>, NotFound>> (int session_id, ApplicationDbContext db) =>
        {
            return await db.Session.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Session_id == session_id)
                is Session model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSessionById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int session_id, Session session, ApplicationDbContext db) =>
        {
            var affected = await db.Session
                .Where(model => model.Session_id == session_id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Session_id, session.Session_id)
                  .SetProperty(m => m.Session_date, session.Session_date)
                  .SetProperty(m => m.Topic, session.Topic)
                  .SetProperty(m => m.Description, session.Description)
                  .SetProperty(m => m.Speaker_id, session.Speaker_id)
                  .SetProperty(m => m.Location, session.Location)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSession")
        .WithOpenApi();

        group.MapPost("/", async (Session session, ApplicationDbContext db) =>
        {
            db.Session.Add(session);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Session/{session.Session_id}",session);
        })
        .WithName("CreateSession")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int session_id, ApplicationDbContext db) =>
        {
            var affected = await db.Session
                .Where(model => model.Session_id == session_id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSession")
        .WithOpenApi();
    }
}
