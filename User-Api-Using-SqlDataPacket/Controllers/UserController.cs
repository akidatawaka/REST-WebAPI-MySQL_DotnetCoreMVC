using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Api_Using_SqlDataPacket.Models;

namespace User_Api_Using_SqlDataPacket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            this._context = context;
        }

      
        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<UserItem>> GetUserItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            //return new string[] { "value1", "value2" };
            return _context.GetAllUsers();
        }

        //Get : api/user/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<UserItem>> GetUserItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            return _context.GetUser(id);
        }

        //// GET: api/User/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/User
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/User/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
