using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sprint3.Data;
using Sprint3.Repositories;
using Sprint3.Services;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURAÇÃO DE CONTROLLERS
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();

// 2. SWAGGER COM JWT
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PokeBistro API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header. Exemplo: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, new string[] {} }
    });
});

// 3. AUTENTICAÇÃO JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"] ?? "ChaveSecretaSuperSeguraDoPokeBistro2026");
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x => {
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// 4. CORS
builder.Services.AddCors(options => {
    options.AddPolicy("LiberarGeral", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// 5. INJEÇÃO DE DEPENDÊNCIA (Repositórios e Serviços)
builder.Services.AddScoped<ICardapioRepository, CardapioRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

// Serviços essenciais para a arquitetura robusta funcionar
builder.Services.AddScoped<CardapioService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<PedidoService>();

// 6. BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("RestauranteConnection");
builder.Services.AddDbContext<RestauranteDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// MIDDLEWARES
app.UseCors("LiberarGeral");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Serve os arquivos HTML da pasta wwwroot

app.UseAuthentication();
app.UseAuthorization();

// MAPEAMENTO DE CONTROLLERS
app.MapControllers();
app.Run();