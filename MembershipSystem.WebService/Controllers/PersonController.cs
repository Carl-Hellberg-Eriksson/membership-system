using MembershipSystem.Core.DatabaseEntities;
using MembershipSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MembershipSystem.WebService.Controllers;
[Route("[controller]")]
[ApiController]
public class PersonController : ControllerBase {

    private readonly IPersonService personService;
    private readonly ILogger<PersonController> log;

    public PersonController(IPersonService personService, ILogger<PersonController> log) {
        this.personService = personService;
        this.log = log;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> Get() {
        try {
            var persons = await personService.GetAllPersonsAsync();
            return Ok(persons);
        } catch (Exception ex) {
            log.LogError(ex, "Error in Get");
            return Problem();
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<IEnumerable<Person>>> Get(int id) {
        try {
            var person = await personService.GetPersonByIdAsync(id);
            log.LogDebug("Returned: {@person}", person);
            return Ok(person);
        } catch (Exception ex) {
            log.LogError(ex, "Error in Get(id)");
            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post(Person person) {
        try {
            await personService.AddPersonAsync(person);
            log.LogDebug("Added: {@person}", person);
            return Ok();
        } catch (Exception ex) {
            log.LogError(ex, "Error in Post");
            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult> Put(Person person) {
        try {
            await personService.UpdatePersonAsync(person);
            log.LogDebug("Updated: {@person}", person);
            return Ok();
        } catch (Exception ex) {
            log.LogError(ex, "Error in Put");
            return Problem();
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id) {
        try {
            await personService.DeletePersonAsync(id);
            log.LogDebug("Deleted person with id {id}", id);
            return Ok();
        } catch (Exception ex) {
            log.LogError(ex, "Error in Delete");
            return Problem();
        }
    }
}
