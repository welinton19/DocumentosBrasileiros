using DocumentosBrasileiros.Application.UseCases;
using DocumentosBrsileiros.Domain.Services;
using DocumentosBrsileiros.Domain.Validator;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Registra todos os validators
builder.Services.AddScoped<IDocumentoValidator, CpfValidator>();
builder.Services.AddScoped<IDocumentoValidator, CnpjValidator>();
builder.Services.AddScoped<IDocumentoValidator, CnhValidator>();
builder.Services.AddScoped<IDocumentoValidator, PisValidator>();
builder.Services.AddScoped<IDocumentoValidator, NisValidator>();
builder.Services.AddScoped<IDocumentoValidator, CeiValidator>();

// Registra o UseCase
builder.Services.AddScoped<IDocumentoValidatorService, ValidarDocumentoUseCase>();

var app = builder.Build();



app.MapOpenApi();
app.MapScalarApiReference();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();