using AutoMapper;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Fiap.Web.Alunos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Alunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentativeController : Controller
    {
        private readonly IRepresentativeService _representativeService;
        private readonly IMapper _mapper;

        public RepresentativeController(IRepresentativeService representativeService, IMapper mapper)
        {
            _representativeService = representativeService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RepresentativeViewModel>> Get()
        {
            var list = _representativeService.GetAllRepresentatives();
            var viewModelList = _mapper.Map<IEnumerable<RepresentativeViewModel>>(list);

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
        public ActionResult<RepresentativeViewModel> Get([FromRoute] int id)
        {
            var model = _representativeService.GetRepresentativeById(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<RepresentativeViewModel>(model);
                return Ok(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] RepresentativeViewModel viewModel)
        {
            var model = _mapper.Map<RepresentativeModel>(viewModel);
            _representativeService.CreateRepresentative(model);

            return CreatedAtAction(nameof(Get), new { id = model.RepresentativeId }, model);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _representativeService.DeleteRepresentative(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Put(
            [FromRoute] int id,
            [FromBody] RepresentativeViewModel viewModel
        )
        {
            if (viewModel.RepresentativeId == id)
            {
                var model = _mapper.Map<RepresentativeModel>(viewModel);
                _representativeService.UpdateRepresentative(model);

                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
