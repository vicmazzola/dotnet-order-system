using Fiap.Web.Alunos.Models;
using System.Collections.Generic;

namespace Fiap.Web.Alunos.Data.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<OrderModel> GetAll();
        IEnumerable<OrderModel> GetAllWithDetails();
        OrderModel GetById(int id);
        OrderModel GetByIdWithDetails(int id);
        void Add(OrderModel order);
        void Update(OrderModel order);
        void Delete(OrderModel order);
    }
}