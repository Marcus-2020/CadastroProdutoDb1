using CadastroProduto.Api.Domain.Entities;
using CadastroProduto.Api.Domain.Models;
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
    return result.EhFalha switch
    {
        true when result.Erro is ErroValidacao => Results.BadRequest(new
        {
            message = "Produto inválido", erros = (result.Erro as ErroValidacao)!.Erros
        }),
        true => Results.StatusCode(500),
        _ => Results.Created(default(string), new { produtoId = result.Valor, })
    };
});

app.Run();