using Microsoft.EntityFrameworkCore;
using OdontoAPP.Data;
using OdontoAPP.Repositories;
using OdontoAPP.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner
builder.Services.AddControllers();

// Configurando o DbContext para o banco de dados (ajuste a string de conexão no appsettings.json)
builder.Services.AddDbContext<OdontoDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Adicionando o RoboflowService como dependência injetada
builder.Services.AddHttpClient<RoboflowService>();

// Adicionando CORS para permitir requisições de outras origens (durante o desenvolvimento)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configuração do Swagger (documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OdontoAPP API v1");
        c.RoutePrefix = string.Empty; // Swagger será carregado na raiz (opcional)
    });
}

// Habilitando o CORS configurado
app.UseCors("PermitirTudo");

// Middlewares padrões
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeamento de controladores
app.MapControllers();

// Executando a aplicação
app.Run();
