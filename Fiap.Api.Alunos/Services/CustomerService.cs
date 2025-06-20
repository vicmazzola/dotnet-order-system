using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CustomerModel> GetAllCustomers() => _repository.GetAll();

        public CustomerModel GetCustomerById(int id) => _repository.GetById(id);

        public void CreateCustomer(CustomerModel customer) => _repository.Add(customer);        

        public void UpdateCustomer(CustomerModel customer) => _repository.Update(customer);

        public void DeleteCustomer(int id)
        {
            var customer = _repository.GetById(id);
            if (customer != null)
            {
                _repository.Delete(customer);
            }
        }
    }
}