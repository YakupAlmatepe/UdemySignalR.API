using UdemySignalR.APIProject.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost4200").AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers();
builder.Services.AddSignalR();
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
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<MyHub>("/myhub");

app.Run();
