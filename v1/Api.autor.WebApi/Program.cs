using Api.autor.IoC;
using Api.autor.WebApi.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuhorIoC(builder.Host, builder.Configuration);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ConfigureWebApplication();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
////app.UseMiddleware<ExceptionHandlingMiddleware>();

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
