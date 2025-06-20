namespace Fiap.Web.Alunos.ViewModel
{
    public class CreatePedidoViewModel
    {
        public DateTime DataPedido { get; set; }
        public int ClienteId { get; set; }
        public int LojaId { get; set; }
        public List<int> ProdutoIds { get; set; } // Apenas os IDs dos produtos
    }
}
