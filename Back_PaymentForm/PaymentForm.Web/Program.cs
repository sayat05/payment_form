using Microsoft.EntityFrameworkCore;
using PaymentForm.DataBase.DataBase;

var builder = WebApplication.CreateBuilder(args);

#region Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Controllers

builder.Services.AddControllers();

#endregion

#region EfCore

builder.Services.AddDbContext<MyAppContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#endregion


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
