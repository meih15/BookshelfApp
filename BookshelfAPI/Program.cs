using BookshelfAPI.Data;
using BookshelfAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();


// Book Endpoints
app.MapGet("/books", async (ApplicationDbContext db) => await db.Books.ToListAsync());

app.MapGet("/books/{id}", async (int id, ApplicationDbContext db) => 
    await db.Books.FindAsync(id) is Book book ? Results.Ok(book) : Results.NotFound());

app.MapPost("/books", async (Book book, ApplicationDbContext db) => 
{
    db.Books.Add(book);
    
    await db.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

app.MapPut("/books/{id}", async (int id, Book inputBook, ApplicationDbContext db) => 
{
    var book = await db.Books.FindAsync(id);
    
    if (book is null) return Results.NotFound();
    
    book.Title = inputBook.Title;
    book.Genre = inputBook.Genre;
    book.AuthorId = inputBook.AuthorId;
    
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/books/{id}", async (int id, ApplicationDbContext db) => 
{
    var book = await db.Books.FindAsync(id);
    
    if (book is null) return Results.NotFound();
    
    db.Books.Remove(book);
    
    await db.SaveChangesAsync();
    return Results.NoContent();
});



// Author Endpoints
app.MapGet("/authors", async (ApplicationDbContext db) => await db.Authors.ToListAsync());

app.MapGet("/authors/{id}", async (int id, ApplicationDbContext db) => 
    await db.Authors.FindAsync(id) is Author author ? Results.Ok(author) : Results.NotFound());

app.MapPost("/authors", async (Author author, ApplicationDbContext db) => 
{
    db.Authors.Add(author);
    
    await db.SaveChangesAsync();
    return Results.Created($"/authors/{author.Id}", author);
});

app.MapPut("/authors/{id}", async (int id, Author inputAuthor, ApplicationDbContext db) => 
{
    var author = await db.Authors.FindAsync(id);
   
    if (author is null) return Results.NotFound();
   
    author.Name = inputAuthor.Name;
    author.Biography = inputAuthor.Biography;
   
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/authors/{id}", async (int id, ApplicationDbContext db) => 
{
    var author = await db.Authors.FindAsync(id);
   
    if (author is null) return Results.NotFound();
   
    db.Authors.Remove(author);
   
    await db.SaveChangesAsync();
    return Results.NoContent();
});



// Review Endpoints
app.MapGet("/reviews", async (ApplicationDbContext db) => await db.Reviews.ToListAsync());

app.MapGet("/reviews/{id}", async (int id, ApplicationDbContext db) => 
    await db.Reviews.FindAsync(id) is Review review ? Results.Ok(review) : Results.NotFound());

app.MapPost("/reviews", async (Review review, ApplicationDbContext db) => 
{
    db.Reviews.Add(review);
   
    await db.SaveChangesAsync();
    return Results.Created($"/reviews/{review.Id}", review);
});

app.MapPut("/reviews/{id}", async (int id, Review inputReview, ApplicationDbContext db) => 
{
    var review = await db.Reviews.FindAsync(id);

    if (review is null) return Results.NotFound();

    review.Content = inputReview.Content;
    review.Rating = inputReview.Rating;
    review.BookId = inputReview.BookId;
    review.UserId = inputReview.UserId;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/reviews/{id}", async (int id, ApplicationDbContext db) => 
{
    var review = await db.Reviews.FindAsync(id);
    
    if (review is null) return Results.NotFound();
    
    db.Reviews.Remove(review);
    
    await db.SaveChangesAsync();
    return Results.NoContent();
});



// User Endpoints
app.MapGet("/users", async (ApplicationDbContext db) => await db.Users.ToListAsync());

app.MapGet("/users/{id}", async (int id, ApplicationDbContext db) => 
    await db.Users.FindAsync(id) is User user ? Results.Ok(user) : Results.NotFound());

app.MapPost("/users", async (User user, ApplicationDbContext db) => 
{
    db.Users.Add(user);

    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

app.MapPut("/users/{id}", async (int id, User inputUser, ApplicationDbContext db) => 
{
    var user = await db.Users.FindAsync(id);

    if (user is null) return Results.NotFound();

    user.Username = inputUser.Username;
    user.Email = inputUser.Email;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/users/{id}", async (int id, ApplicationDbContext db) => 
{
    var user = await db.Users.FindAsync(id);

    if (user is null) return Results.NotFound();

    db.Users.Remove(user);

    await db.SaveChangesAsync();
    return Results.NoContent();
});



// Reading Log Endpoints
app.MapGet("/readinglogs", async (ApplicationDbContext db) => await db.ReadingLogs.ToListAsync());

app.MapGet("/readinglogs/{id}", async (int id, ApplicationDbContext db) => 
    await db.ReadingLogs.FindAsync(id) is ReadingLog readingLog ? Results.Ok(readingLog) : Results.NotFound());

app.MapPost("/readinglogs", async (ReadingLog readingLog, ApplicationDbContext db) => 
{
    db.ReadingLogs.Add(readingLog);

    await db.SaveChangesAsync();
    return Results.Created($"/readinglogs/{readingLog.Id}", readingLog);
});

app.MapPut("/readinglogs/{id}", async (int id, ReadingLog inputReadingLog, ApplicationDbContext db) => 
{
    var readingLog = await db.ReadingLogs.FindAsync(id);

    if (readingLog is null) return Results.NotFound();

    readingLog.BookId = inputReadingLog.BookId;
    readingLog.UserId = inputReadingLog.UserId;
    readingLog.StartDate = inputReadingLog.StartDate;
    readingLog.EndDate = inputReadingLog.EndDate;
    readingLog.CurrentPage = inputReadingLog.CurrentPage;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/readinglogs/{id}", async (int id, ApplicationDbContext db) => 
{
    var readingLog = await db.ReadingLogs.FindAsync(id);

    if (readingLog is null) return Results.NotFound();
    db.ReadingLogs.Remove(readingLog);

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
