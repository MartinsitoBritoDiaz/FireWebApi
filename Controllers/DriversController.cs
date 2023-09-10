using FireApp.Models;
using FireApp.Services;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace FireApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private static List<Driver> drivers = new List<Driver>();
    private readonly ILogger<DriversController> _logger;

    public DriversController(ILogger<DriversController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult AddDriver([FromBody] Driver driver){
        if(ModelState.IsValid)
        {
            drivers.Add(driver);

            var jobId = BackgroundJob.Enqueue<IServiceManagment>(x => x.SendEmail());

            return CreatedAtAction("GetDriver", new { driver.Id }, driver);
        }
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetDriver([FromQuery]Guid id){
        var driver = drivers.FirstOrDefault(x => x.Id == id);

        return driver != null ? Ok(driver) : NotFound();
    }

    [HttpDelete]
    public IActionResult DeleteDriver([FromQuery]Guid id)
    { 
        var driver = drivers.FirstOrDefault(x => x.Id == id);

        if(driver == null)
            return NotFound();

        driver.Status = 0;

        RecurringJob.AddOrUpdate<IServiceManagment>(x => x.UpdateDatabase(), Cron.Minutely);
        return NoContent();
    }
}
