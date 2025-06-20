namespace Fiap.Web.Alunos.ViewModel
{
    public class CreateOrderViewModel
    {
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}