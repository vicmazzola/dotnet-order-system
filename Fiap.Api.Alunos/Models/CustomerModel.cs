namespace Fiap.Web.Alunos.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Notes { get; set; }
        public int RepresentativeId { get; set; }
        public RepresentativeModel? Representative { get; set; }
    }
}