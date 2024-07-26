
using Microsoft.AspNetCore.Mvc;

namespace NetCore_CorrelationId.Controller;

[ApiController]
[Route("[controller]")]
public class ApiPersonController : ControllerBase
{

    private readonly ILogger<ApiPersonController> _logger;

    public ApiPersonController(ILogger<ApiPersonController> logger)
    {
        _logger = logger;
    }
 
    [HttpGet]
    [Route("GetAllPersons")]
    public IActionResult GetAllPersons()
    {
        _logger.LogInformation("ApiPersonController GetAllPersons test  .");
        //to do
        return Ok(new List<Person>());
    }
    [HttpGet]
    [Route("GetPersonByid")]
    public IActionResult GetPersonByid(int Id)
    {
        _logger.LogInformation("ApiPersonController GetPersonByid test {0} .", Id);
        //to do
        return Ok("success");
    }

    [HttpPost]
    [Route("InsertToPersons")]
    public IActionResult InsertToPersons([FromForm] Person person)
    {
        _logger.LogInformation("ApiPersonController InsertToPersons test {0} .", person);
        //to do
        return Ok("success");
    }


}

public class Person
{
    public int Id { get; set; }
    public string name { get; set; }
}
