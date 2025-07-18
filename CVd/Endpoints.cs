﻿using CVd.Data;
using Microsoft.EntityFrameworkCore;

namespace CVd
{
    internal static partial class Endpoints
    {
        public static void Configure(WebApplication app, bool mapAdditional = false)
        {
            app.MapGet("/user/{id}", (CvDbContext db, int id, string lang) =>
            {
                try
                {
                    var user = db.Users
                       .Include(u => u.Contacts)
                       .Include(u => u.Milestones)
                       .Include(u => u.Skills
                            .Where(s => string.IsNullOrEmpty(s.LanguageCode) || s.LanguageCode == lang)
                            .OrderBy(s => s.SortOrder))
                       .Include(u => u.Projects
                            .OrderBy(s => s.SortOrder))
                       .Include(u => u.Decorations)
                       .FirstOrDefault(u => u.Id == id);

                    if (user == null) { return Results.NotFound(); }

                    //single db query, then aggregate in-memory
                    var mDescriptions = db.MilestoneDescriptions.Where(md =>
                        md.LanguageCode == lang && user.Milestones.Select(d => d.DescriptionId).Contains(md.DescriptionId));

                    foreach (var milestone in user.Milestones)
                    {
                        milestone.Description = mDescriptions.FirstOrDefault(d => d.DescriptionId == milestone.DescriptionId);
                    }

                    var pDescriptions = db.ProjectDescriptions.Where(pd =>
                        pd.LanguageCode == lang && user.Projects.Select(d => d.Id).Contains(pd.DescriptionId));

                    foreach (var project in user.Projects)
                    {
                        project.Description = pDescriptions.FirstOrDefault(d => d.DescriptionId == project.Id);
                    }

                    return Results.Ok(user);
                }
                catch
                {
                    return Results.BadRequest();
                }
            });

            if (mapAdditional)
            {
                app.MapAdditional();
            }
        }
    }
}