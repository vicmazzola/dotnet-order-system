using AutoMapper;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Fiap.Web.Alunos.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Alunos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteViewModel>> Get()
        {
            var clientes = _service.ListarClientes();
            var viewModelList = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteViewModel> Get(int id)
        {
            var cliente = _service.ObterClientePorId(id);
            if (cliente == null)
                return NotFound();

            var viewModel = _mapper.Map<ClienteViewModel>(cliente);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClienteCreateViewModel viewModel)
        {
            var cliente = _mapper.Map<ClienteModel>(viewModel);
            _service.CriarCliente(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.ClienteId }, cliente);
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClienteUpdateViewModel viewModel)
        {
            var clienteExistente = _service.ObterClientePorId(id);
            if (clienteExistente == null)
                return NotFound();
        
            _mapper.Map(viewModel, clienteExistente);
            _service.AtualizarCliente(clienteExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeletarCliente(id);
            return NoContent();
        }
    }
}