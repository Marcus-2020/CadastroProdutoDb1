using CadastroProduto.Api.Domain.Entities;
using CadastroProduto.Api.Domain.Services;
using CadastroProduto.Api.Infra;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/v1/produto", ([FromServices] IProdutoService service, [FromBody] Produto produto) =>
{
    var result = service.AdicionaProduto(produto);
    if (result.EhFalha)
    {
        return result.Erro.Exception is not null 
            ? Results.StatusCode(500) 
            : Results.BadRequest("Ocorreu um erro ao adicionar o produto");
    }

    return Results.Created(default(string), new
    {
        produtoId = result.Valor,
    });
});

app.Run();