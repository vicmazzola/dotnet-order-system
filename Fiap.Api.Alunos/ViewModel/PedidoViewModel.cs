namespace Fiap.Web.Alunos.ViewModel
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public int LojaId { get; set; }
        public LojaViewModel Loja { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
