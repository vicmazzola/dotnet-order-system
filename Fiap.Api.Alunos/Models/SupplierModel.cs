namespace Fiap.Web.Alunos.Models
{
    public class SupplierModel
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }

        // Relationship with Product
        public List<ProductModel> Products { get; set; }
    }
}