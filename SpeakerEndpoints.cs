using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace BackEnd;

public static class SpeakerEndpoints
{
    public static void MapSpeakerEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Speaker").WithTags(nameof(Speaker));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Speakers.ToListAsync();
        })
        .WithName("GetAllSpeakers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Speaker>, NotFound>> (int speaker_id, ApplicationDbContext db) =>
        {
            return await db.Speakers.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Speaker_id == speaker_id)
                is Speaker model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSpeakerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int speaker_id, Speaker speaker, ApplicationDbContext db) =>
        {
            var affected = await db.Speakers
                .Where(model => model.Speaker_id == speaker_id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Speaker_id, speaker.Speaker_id)
                  .SetProperty(m => m.Speaker_name, speaker.Speaker_name)
                  .SetProperty(m => m.Facebook_id, speaker.Facebook_id)
                  .SetProperty(m => m.Linkedin_id, speaker.Linkedin_id)
                  .SetProperty(m => m.git, speaker.git)
                  .SetProperty(m => m.twitter, speaker.twitter)
                  .SetProperty(m => m.bio, speaker.bio)
                  .SetProperty(m => m.About_Experience, speaker.About_Experience)
                  .SetProperty(m => m.Interest, speaker.Interest)
                  .SetProperty(m => m.WebSite, speaker.WebSite)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSpeaker")
        .WithOpenApi();

        group.MapPost("/", async (Speaker speaker, ApplicationDbContext db) =>
        {
            db.Speakers.Add(speaker);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Speaker/{speaker.Speaker_id}",speaker);
        })
        .WithName("CreateSpeaker")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int speaker_id, ApplicationDbContext db) =>
        {
            var affected = await db.Speakers
                .Where(model => model.Speaker_id == speaker_id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSpeaker")
        .WithOpenApi();
    }
}
