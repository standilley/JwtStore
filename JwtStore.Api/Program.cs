using JwtStore.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();

builder.AddAccountContext();

builder.AddMediator();

var app = builder.Build();
app.UseHttpsRedirection(); // forcar o https
app.UseStaticFiles(); // usar arquivos static, caso necessário
app.UseRouting(); // usar rotas
app.UseAuthentication();
app.UseAuthorization();

app.MapAccountEndpoints();

app.Run();

