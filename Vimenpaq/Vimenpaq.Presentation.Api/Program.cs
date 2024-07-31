using Vimenpaq.Core.Application;
using Vimenpaq.Infrastructure.Identity;
using Vimenpaq.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddControllers(options => {
    options.RespectBrowserAcceptHeader = true; // Optional, respect header Accept
}).AddXmlSerializerFormatters(); // Add XML support
builder.Services.AddSwaggerExtension();
builder.Services.AddApiVersioningExtension();
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
