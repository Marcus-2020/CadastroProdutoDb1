﻿using CadastroProduto.Api.Data.Repositories;
using CadastroProduto.Api.Domain.Entities;
using CadastroProduto.Api.Domain.Models;
using CadastroProduto.Api.Domain.Validators;

namespace CadastroProduto.Api.Domain.Services;

public class ProdutoService
{
    private readonly ProdutoRepository _produtoRepository;
    private readonly ProdutoValidator _produtoValidator;

    public ProdutoService(ProdutoRepository produtoRepository,
        ProdutoValidator produtoValidator)
    {
        _produtoRepository = produtoRepository;
        _produtoValidator = produtoValidator;
    }

    public Resultado<string> AdicionaProduto(Produto produto)
    {
        try
        {
            var validacao = _produtoValidator.Valida(produto);
            if (!validacao.Item1)
            {
                return Resultado<string>.Falha(new Erro("Produto inválido"));
            }

            var addProduto = _produtoRepository.AdicionaProduto(produto);
            if (addProduto.EhFalha)
            {
                return Resultado<string>.Falha(addProduto.Erro);
            }

            return Resultado<string>.Ok(addProduto.Valor!);
        }
        catch (Exception ex)
        {
            return Resultado<string>.Falha(new Erro("Ocorreu um erro interno ao tentar adicionar o produto",
                ex));
        }
    }
}