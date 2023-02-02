using HttpProxy.Core;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpProxy();
var app = builder.Build();
app.UseHttpProxy();
app.Run();