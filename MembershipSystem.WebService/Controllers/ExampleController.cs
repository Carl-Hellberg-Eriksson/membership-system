using MembershipSystem.Core.DatabaseEntities;
using MembershipSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MembershipSystem.WebService.Controllers;
[Route("[controller]")]
[ApiController]
public class ExampleController : ControllerBase {

    private readonly IExample example;
    private readonly IPersonService personService;
    public ExampleController(IExample example, IPersonService personService) {
        this.example = example;
        this.personService = personService;
    }
    [HttpGet]
    public async Task<ActionResult<string>> Get() {
        var ex = example.GetString();
        await personService.AddPersonAsync(new Person { FirstName = "Calle", LastName = "Hellberg Eriksson" });
        var persons = await personService.GetAllPersonsAsync();
        return Ok(ex);
    }
}
