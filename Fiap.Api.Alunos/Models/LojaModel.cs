﻿namespace Fiap.Web.Alunos.Models
{
    public class LojaModel
    {
        public int LojaId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        // Relacionamento com Pedido
        public List<PedidoModel> Pedidos { get; set; }
    }
}
