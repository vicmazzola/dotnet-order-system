﻿namespace Fiap.Web.Alunos.Models
{
    public class FornecedorModel
    {

        public int FornecedorId { get; set; }
        public string Nome { get; set; }

        // Relacionamento com Produto
        public List<ProdutoModel> Produtos { get; set; }

    }
}
