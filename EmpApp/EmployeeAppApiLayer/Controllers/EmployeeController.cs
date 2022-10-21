using EmployeeAppModels;
using EmployeeAppBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAppApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _emp;
        public EmployeeController(IEmployee emp)
        {
            _emp = emp;
        }
        [HttpGet("Get")]
        public ActionResult<List<EmployeeRegistration>> Get()
        {
            var result = _emp.Get();
            return Ok(result);
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post(EmployeeRegistration emp1)
        {
            if (!ModelState.IsValid)
                return BadRequest("Is not valid");
            _emp.Post(emp1);
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete]
        [Route("Delete/{UserName}")]
        public ActionResult Delete(string username)
        {
            _emp.Delete(username);
            return Ok();

        }

        
    }

}
