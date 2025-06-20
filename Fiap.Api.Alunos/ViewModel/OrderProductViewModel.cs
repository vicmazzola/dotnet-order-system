namespace Fiap.Web.Alunos.ViewModel
{
    public class OrderProductViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}