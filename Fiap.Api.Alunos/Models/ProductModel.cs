namespace Fiap.Web.Alunos.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        // Relationship with Supplier
        public int SupplierId { get; set; }
        public SupplierModel Supplier { get; set; }

        // Relationship with Orders
        public List<OrderProductModel> OrderProducts { get; set; }
    }
}