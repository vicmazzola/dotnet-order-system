using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        // Método para obter todos os pedidos
        public IEnumerable<PedidoModel> ObterTodosPedidos()
        {
            return _pedidoRepository.GetAll();
        }

        // Método para obter todos os pedidos com detalhes completos
        public IEnumerable<PedidoModel> ObterTodosPedidosComDetalhes()
        {
            return _pedidoRepository.GetAllWithDetails();
        }

        // Método para obter um pedido por ID
        public PedidoModel ObterPedidoPorId(int id)
        {
            return _pedidoRepository.GetById(id);
        }

        // Método para obter um pedido por ID com detalhes completos
        public PedidoModel ObterPedidoPorIdComDetalhes(int id)
        {
            return _pedidoRepository.GetByIdWithDetails(id);
        }

        // Método para adicionar um novo pedido
        public void AdicionarPedido(PedidoModel pedido)
        {
            if (pedido.PedidoProdutos == null || pedido.PedidoProdutos.Count == 0)
            {
                throw new ArgumentException("O pedido deve ter pelo menos um produto associado.");
            }
            _pedidoRepository.Add(pedido);
        }

        // Método para atualizar um pedido existente
        public void AtualizarPedido(PedidoModel pedido)
        {
            if (pedido.PedidoProdutos == null || pedido.PedidoProdutos.Count == 0)
            {
                throw new ArgumentException("O pedido deve ter pelo menos um produto associado.");
            }
            _pedidoRepository.Update(pedido);
        }

        // Método para deletar um pedido
        public void DeletarPedido(PedidoModel pedido)
        {
            _pedidoRepository.Delete(pedido);
        }
    }
}
