using Fiap.Web.Alunos.Models;
using System.Collections.Generic;

namespace Fiap.Web.Alunos.Data.Repository
{
    public interface IPedidoRepository
    {
        IEnumerable<PedidoModel> GetAll();
        IEnumerable<PedidoModel> GetAllWithDetails();
        PedidoModel GetById(int id);
        PedidoModel GetByIdWithDetails(int id);
        void Add(PedidoModel pedido);
        void Update(PedidoModel pedido);
        void Delete(PedidoModel pedido);
    }
}
