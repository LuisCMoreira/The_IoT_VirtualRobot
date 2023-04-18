using IoTbotAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();





builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        //builder.WithOrigins( "http://localhost:80","https://172.20.0.2:7666","http://172.20.0.2:80")
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});




builder.Services.AddControllers();
builder.Services.AddDbContext<botContext>(opt =>
    opt.UseInMemoryDatabase("btdataList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();