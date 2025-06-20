namespace Fiap.Web.Alunos.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public int StoreId { get; set; }
        public StoreViewModel Store { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}