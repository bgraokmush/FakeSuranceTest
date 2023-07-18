using FakeSurance.API.Model.User;
using FakeSurance.Business.Abstract;
using FakeSurance.Core.Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeSurance.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/xml")] // for xml
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UsersController(IUserService userService)
        {
            _UserService = userService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _UserService.UserList();

            //Header' a bilgi ekleme
            Response.Headers.Add("User-Count", result.Count.ToString());

            if(result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("User not found");
            }

        }

        [HttpGet("{id}")]
        public ActionResult GetByID(int id)
        {
            var result = _UserService.GetUser(id);

            if (result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("User not found");
            }
        }

        [HttpGet("GetByName/{Name}")]
        public ActionResult GetByName(string Name)
        {
            var result = _UserService.GetUserByName(Name);
        
            if(result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("User not found");
            }

        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            _UserService.AddUser(user);
            return Ok("User Added Successfuly");
        }

        [HttpPut]
        public ActionResult UpdateUser(User user)
        {
            if(_UserService.GetUser(user.Id) is not null)
            {
                _UserService.UpdateUser(user);
                return Ok("User Update Successfuly");
            }
            else
            {
                return BadRequest("User not found");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            if(_UserService.GetUser(id) is not null)
            {
                _UserService.DeleteUser(id);
                return Ok("User Deleted Successfuly");
            }
            else
            {
                return BadRequest("User not found");
            }
        }
    }
}
