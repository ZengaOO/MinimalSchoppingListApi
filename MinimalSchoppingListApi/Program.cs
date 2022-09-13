using Microsoft.EntityFrameworkCore;
using MinimalSchoppingListApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase("ShoppingListApi"));

var app = builder.Build();

app.MapGet("/shoppinglist", async (ApiDbContext db) =>
    await db.Groseries.ToListAsync());

app.MapGet("/shoppinglist/{id}", async (int id, ApiDbContext db) =>
{

    var grocery = await db.Groseries.FindAsync(id);

    return grocery != null? Results.Ok(grocery) : Results.NotFound();

});



app.MapPost("/shoppinglist", async (Grocery grocery, ApiDbContext db) =>
{
    db.Groseries.Add(grocery);
    await db.SaveChangesAsync();

    return Results.Created($"/shoppinglist /{grocery.Id}", grocery);
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();