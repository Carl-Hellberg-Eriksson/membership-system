using MembershipSystem.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MembershipSystem.WebService.Controllers;
[Route("[controller]")]
[ApiController]
public class ExampleController : ControllerBase {

    private readonly IExample example;
    public ExampleController(IExample example) {
        this.example = example;
    }
    [HttpGet]
    public ActionResult<string> Get() {
        var ex = example.GetString();
        return Ok(ex);
    }
}
