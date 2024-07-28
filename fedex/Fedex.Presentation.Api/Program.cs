using Fedex.Core.Application;
using Fedex.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddControllers();
// Dependency Injections
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // IHttpContextAccesor
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.Services.AddIdentitySeeds();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
