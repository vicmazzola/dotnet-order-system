namespace Fiap.Web.Alunos.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        // Relationship with Customer
        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }

        // Relationship with Store
        public int StoreId { get; set; }
        public StoreModel Store { get; set; }

        // Relationship with Product
        public List<OrderProductModel> OrderProducts { get; set; }
    }
}