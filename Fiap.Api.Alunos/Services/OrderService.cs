using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Method to retrieve all orders
        public IEnumerable<OrderModel> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        // Method to retrieve all orders with full details
        public IEnumerable<OrderModel> GetAllOrdersWithDetails()
        {
            return _orderRepository.GetAllWithDetails();
        }

        // Method to retrieve an order by ID
        public OrderModel GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        // Method to retrieve an order by ID with full details
        public OrderModel GetOrderByIdWithDetails(int id)
        {
            return _orderRepository.GetByIdWithDetails(id);
        }

        // Method to add a new order
        public void AddOrder(OrderModel order)
        {
            if (order.OrderProducts == null || order.OrderProducts.Count == 0)
            {
                throw new ArgumentException("The order must have at least one associated product.");
            }
            _orderRepository.Add(order);
        }

        // Method to update an existing order
        public void UpdateOrder(OrderModel order)
        {
            if (order.OrderProducts == null || order.OrderProducts.Count == 0)
            {
                throw new ArgumentException("The order must have at least one associated product.");
            }
            _orderRepository.Update(order);
        }

        // Method to delete an order
        public void DeleteOrder(OrderModel order)
        {
            _orderRepository.Delete(order);
        }
    }
}