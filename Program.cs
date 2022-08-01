using Library.Aplication.Services;
using Library.Infrastructure;
using Library.Infrastructure.Persistence;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ILibraryDbContext,LibraryContext>(optionsBuilder =>
    optionsBuilder.UseInMemoryDatabase(databaseName:"LibraryDb"));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.Request | HttpLoggingFields.RequestMethod |
                            HttpLoggingFields.RequestPath | HttpLoggingFields.RequestQuery;
});

builder.Services.AddTransient<IBookService,BookService>();

var app = builder.Build();

app.UseExceptionHandler("/error");

app.UseHttpLogging();

app.MapControllers();

app.Run();