namespace Fiap.Web.Alunos.Data.Repository
{
    using Fiap.Web.Alunos.Data.Contexts;
    using Fiap.Web.Alunos.Data.Repository;
    using Fiap.Web.Alunos.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class PedidoRepository : IPedidoRepository
    {
        private readonly DatabaseContext _context;

        public PedidoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<PedidoModel> GetAll()
        {
            return _context.Pedidos
                .ToList();
        }

        // Método para obter todos os pedidos com detalhes completos
        public IEnumerable<PedidoModel> GetAllWithDetails()
        {
            return _context.Pedidos
                .Include(p => p.Cliente)  // Incluir dados do cliente
                .Include(p => p.Loja)     // Incluir dados da loja
                .Include(p => p.PedidoProdutos)  // Incluir relacionamento PedidoProduto
                    .ThenInclude(pp => pp.Produto)  // E então incluir produtos de cada PedidoProduto
                        .ThenInclude(pr => pr.Fornecedor)  // Incluir fornecedor de cada produto
                .ToList();
        }

        public PedidoModel GetById(int id)
        {
            return _context.Pedidos.Find(id);
        }

        public PedidoModel GetByIdWithDetails(int id)
        {
            return _context.Pedidos
                .Where(p => p.PedidoId == id)
                .Include(p => p.Cliente)
                .Include(p => p.Loja)
                .Include(p => p.PedidoProdutos)
                    .ThenInclude(pp => pp.Produto)
                        .ThenInclude(pr => pr.Fornecedor)
                .FirstOrDefault();
        }

        public void Add(PedidoModel pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public void Update(PedidoModel pedido)
        {
            _context.Update(pedido);
            _context.SaveChanges();
        }

        public void Delete(PedidoModel pedido)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }
    }

}
