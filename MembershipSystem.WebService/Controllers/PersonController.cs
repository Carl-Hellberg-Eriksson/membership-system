using MembershipSystem.Core.DatabaseEntities;
using MembershipSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MembershipSystem.WebService.Controllers;
[Route("[controller]")]
[ApiController]
public class PersonController : ControllerBase {

    private readonly IPersonService personService;
    public PersonController(IPersonService personService) {
        this.personService = personService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> Get() {
        try {
            var persons = await personService.GetAllPersonsAsync();
            return Ok(persons);
        } catch (Exception ex) {
            return Problem();
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<IEnumerable<Person>>> Get(int id) {
        try {
            var person = await personService.GetPersonByIdAsync(id);
            return Ok(person);
        } catch (Exception ex) {
            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post(Person person) {
        try {
            await personService.AddPersonAsync(person);
            return Ok();
        } catch (Exception ex) {
            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult> Put(Person person) {
        try {
            await personService.UpdatePersonAsync(person);
            return Ok();
        } catch (Exception ex) {
            return Problem();
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id) {
        try {
            await personService.DeletePersonAsync(id);
            return Ok();
        } catch (Exception ex) {
            return Problem();
        }
    }
}
