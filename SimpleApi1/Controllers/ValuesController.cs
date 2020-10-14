using Microsoft.AspNetCore.Mvc;
using SimpleApi1.Dtos;
using SimpleApi1.Services.Interface;
using System.Collections.Generic;

namespace SimpleApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService; 

        public ValuesController(IUserService userService)
        {
          _userService = userService;
        }


        [HttpGet]
        public ActionResult<List<UserDto>> Get()
        {
            var service = _userService.GetAll();
            return service;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            var service = _userService.Get(id);
            return service;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<UserDto> Post(UserDto userDto)
        {           
            var service = _userService.Add(userDto);
            return service;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public ActionResult<bool> Delete(int id)
        {
            var service = _userService.Delete(id);
            return service;

        }
    }
}
