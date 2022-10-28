using EmployeeAppModels;
using EmployeeAppBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost("Post")]
        //[Route]
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

        [HttpGet]
        [Route("Get/{username}")]
        public ActionResult<EmployeeRegistration> Get(string UserName)
        {
            return _emp.Get(UserName);
         }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(EmployeeRegistration emp1)
        {
            if (!ModelState.IsValid)
                return BadRequest("Is not valid");
            _emp.Edit(emp1);
            return Ok();
        }

    }

}
