using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface IRepresentativeService
    {
        IEnumerable<RepresentativeModel> GetAllRepresentatives();
        RepresentativeModel GetRepresentativeById(int id);
        void CreateRepresentative(RepresentativeModel representative);
        void UpdateRepresentative(RepresentativeModel representative);
        void DeleteRepresentative(int id);
    }
}