using AutoMapper;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Fiap.Web.Alunos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Alunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentanteController : Controller
    {
        private readonly IRepresentanteService _representanteService;
        private readonly IMapper _mapper;


        public RepresentanteController(IRepresentanteService representanteService, IMapper mapper)
        {
            _representanteService = representanteService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RepresentanteViewModel>> Get()
        {
            var lista = _representanteService.ListarRepresentantes();
            var viewModelList = _mapper.Map<IEnumerable<RepresentanteViewModel>>(lista);

            if (viewModelList == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(viewModelList);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<RepresentanteViewModel> Get([FromRoute] int id)
        {
            var model = _representanteService.ObterRepresentantePorId(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<RepresentanteViewModel>(model);
                return Ok(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] RepresentanteViewModel viewModel)
        {
            var model = _mapper.Map<RepresentanteModel>(viewModel);
            _representanteService.CriarRepresentante(model);


            return CreatedAtAction(nameof(Get), new { id = model.RepresentanteId }, model);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _representanteService.DeletarRepresentante(id);
            return NoContent();
        }


        [HttpPut("{id}")]
        public ActionResult Put(
            [FromRoute] int id,
            [FromBody] RepresentanteViewModel viewModel
        )
        {
            if (viewModel.RepresentanteId == id)
            {
                var model = _mapper.Map<RepresentanteModel>(viewModel);
                _representanteService.AtualizarRepresentante(model);

                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}