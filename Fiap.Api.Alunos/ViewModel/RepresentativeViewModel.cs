namespace Fiap.Web.Alunos.ViewModel
{
    public class RepresentativeViewModel
    {
        public int RepresentativeId { get; set; }
        public string RepresentativeName { get; set; }
        public string Cpf { get; set; } // Optionally: rename to "TaxId" if needed
    }
}
