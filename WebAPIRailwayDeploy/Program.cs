using Scalar.AspNetCore;

var builder = WebApplication.CreateSlimBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHealthChecks("/health");

app.MapScalarApiReference();

app.Run();