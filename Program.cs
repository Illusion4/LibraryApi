using Library.Aplication.Services;
using Library.Infrastructure;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ILibraryDbContext,LibraryContext>(optionsBuilder =>
    optionsBuilder.UseInMemoryDatabase(databaseName:"LibraryDb"));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();

builder.Services.AddTransient<IBookService,BookService>();

var app = builder.Build();

app.MapControllers();

app.Run();