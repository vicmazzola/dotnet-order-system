using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class RepresentativeService : IRepresentativeService
    {
        private readonly IRepresentativeRepository _repository;

        public RepresentativeService(IRepresentativeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<RepresentativeModel> GetAllRepresentatives() => _repository.GetAll();

        public RepresentativeModel GetRepresentativeById(int id) => _repository.GetById(id);

        public void CreateRepresentative(RepresentativeModel representative) => _repository.Add(representative);

        public void UpdateRepresentative(RepresentativeModel representative) => _repository.Update(representative);

        public void DeleteRepresentative(int id)
        {
            var representative = _repository.GetById(id);
            if (representative != null)
            {
                _repository.Delete(representative);
            }
        }
    }
}