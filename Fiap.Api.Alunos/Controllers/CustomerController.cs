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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/customer
        [HttpGet]
        public ActionResult<IEnumerable<CustomerViewModel>> Get()
        {
            var customers = _service.GetAllCustomers();
            var viewModelList = _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
            return Ok(viewModelList);
        }

        // GET: api/customer/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomerViewModel> Get(int id)
        {
            var customer = _service.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            var viewModel = _mapper.Map<CustomerViewModel>(customer);
            return Ok(viewModel);
        }

        // POST: api/customer
        [HttpPost]
        public ActionResult Post([FromBody] CustomerCreateViewModel viewModel)
        {
            var customer = _mapper.Map<CustomerModel>(viewModel);
            _service.CreateCustomer(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
        }

        // PUT: api/customer/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CustomerUpdateViewModel viewModel)
        {
            var existingCustomer = _service.GetCustomerById(id);
            if (existingCustomer == null)
                return NotFound();

            _mapper.Map(viewModel, existingCustomer);
            _service.UpdateCustomer(existingCustomer);
            return NoContent();
        }

        // DELETE: api/customer/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeleteCustomer(id);
            return NoContent();
        }
    }
}
