namespace Fiap.Web.Alunos.Models
{
    public class StoreModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        // Relationship with Order
        public List<OrderModel> Orders { get; set; }
    }
}