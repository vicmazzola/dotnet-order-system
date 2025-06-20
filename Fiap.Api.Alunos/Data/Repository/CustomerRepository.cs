using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _context;

    public CustomerRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<CustomerModel> GetAll() =>
        _context.Customers.Include(c => c.Representative).ToList();

    public CustomerModel GetById(int id) =>
        _context.Customers.Find(id);

    public void Add(CustomerModel customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public void Update(CustomerModel customer)
    {
        _context.Update(customer);
        _context.SaveChanges();
    }

    public void Delete(CustomerModel customer)
    {
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }
}