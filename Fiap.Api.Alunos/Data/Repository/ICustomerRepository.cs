using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Data.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerModel> GetAll();
        CustomerModel GetById(int id);
        void Add(CustomerModel customer);
        void Update(CustomerModel customer);
        void Delete(CustomerModel customer);
    }
}