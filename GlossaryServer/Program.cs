using GlossaryServer.Data;
using GlossaryServer.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<GlossaryDbContext>(options =>
    options.UseSqlite("Data Source=glossary.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GlossaryDbContext>();
    db.Database.EnsureCreated();

    if (true)
    {
        db.Terms.RemoveRange(db.Terms);
        db.SaveChanges();

        db.Terms.AddRange(SeedData.GetTerms());
        db.SaveChanges();
    }
}

app.Run();