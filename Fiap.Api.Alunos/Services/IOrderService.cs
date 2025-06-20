using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderModel> GetAllOrders();
        IEnumerable<OrderModel> GetAllOrdersWithDetails();
        OrderModel GetOrderById(int id);
        OrderModel GetOrderByIdWithDetails(int id);
        void AddOrder(OrderModel order);
        void UpdateOrder(OrderModel order);
        void DeleteOrder(OrderModel order);
    }
}