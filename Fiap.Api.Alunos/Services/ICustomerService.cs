using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAllCustomers();
        CustomerModel GetCustomerById(int id);
        void CreateCustomer(CustomerModel customer);
        void UpdateCustomer(CustomerModel customer);
        void DeleteCustomer(int id);
    }
}