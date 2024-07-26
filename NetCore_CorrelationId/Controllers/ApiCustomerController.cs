
using Microsoft.AspNetCore.Mvc;

namespace NetCore_CorrelationId.Controller;

[ApiController]
[Route("[controller]")]
public class ApiCustomerController : ControllerBase
{

    private readonly ILogger<ApiCustomerController> _logger;

    public ApiCustomerController(ILogger<ApiCustomerController> logger)
    {
        _logger = logger;
    }
 
    [HttpGet]
    [Route("GetAllCustomers")]
    public IActionResult GetAllCustomers()
    {
        _logger.LogInformation("ApiCustomerController GetAllCustomers test  .");
        //to do
        return Ok(new List<Customer>());
    }
    [HttpGet]
    [Route("GetCustomerByid")]
    public IActionResult GetCustomerByid(int Id)
    {
        _logger.LogInformation("ApiCustomerController GetCustomerByid test {0} .", Id);
        //to do
        return Ok("success");
    }

    [HttpPost]
    [Route("InsertToCustomers")]
    public IActionResult InsertToCustomers([FromForm] Customer Customer)
    {
        _logger.LogInformation("ApiCustomerController InsertToCustomers test {0} .", Customer);
        //to do
        return Ok("success");
    }


}

public class Customer
{
    public int Id { get; set; }
    public string name { get; set; }
}
