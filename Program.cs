using Microsoft.EntityFrameworkCore;
using OdontoAPP.Data;
using OdontoAPP.Repositories;
using OdontoAPP.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionando servi�os ao cont�iner
builder.Services.AddControllers();

// Configurando o DbContext para o banco de dados (ajuste a string de conex�o no appsettings.json)
builder.Services.AddDbContext<OdontoDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Adicionando o RoboflowService como depend�ncia injetada
builder.Services.AddHttpClient<RoboflowService>();

// Adicionando CORS para permitir requisi��es de outras origens (durante o desenvolvimento)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configura��o do Swagger (documenta��o da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura��o de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OdontoAPP API v1");
        c.RoutePrefix = string.Empty; // Swagger ser� carregado na raiz (opcional)
    });
}

// Habilitando o CORS configurado
app.UseCors("PermitirTudo");

// Middlewares padr�es
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeamento de controladores
app.MapControllers();

// Executando a aplica��o
app.Run();
