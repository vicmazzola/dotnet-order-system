namespace Fiap.Web.Alunos.Data.Repository
{
    using Fiap.Web.Alunos.Data.Contexts;
    using Fiap.Web.Alunos.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _context;

        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderModel> GetAll()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<OrderModel> GetAllWithDetails()
        {
            return _context.Orders
                .Include(order => order.Customer)
                .Include(order => order.Store)
                .Include(order => order.OrderProducts)
                .ThenInclude(op => op.Product)
                .ThenInclude(product => product.Supplier)
                .ToList();
        }

        public OrderModel GetById(int id)
        {
            return _context.Orders.Find(id);
        }

        public OrderModel GetByIdWithDetails(int id)
        {
            return _context.Orders
                .Where(order => order.OrderId == id)
                .Include(order => order.Customer)
                .Include(order => order.Store)
                .Include(order => order.OrderProducts)
                .ThenInclude(op => op.Product)
                .ThenInclude(product => product.Supplier)
                .FirstOrDefault();
        }

        public void Add(OrderModel order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(OrderModel order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(OrderModel order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}