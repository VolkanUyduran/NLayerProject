using Microsoft.AspNetCore.Mvc;
using NlayerProject.Core.Models;
using NlayerProject.Core.Services;
using System.Threading.Tasks;

namespace NlayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _service;

        public PersonsController(IService<Person> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _service.GetAllAsync();
            return Ok(persons);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newPerson = await _service.AddAsync(person);
            return Ok(newPerson);
        }
    }
}
