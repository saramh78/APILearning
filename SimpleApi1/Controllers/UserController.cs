using Microsoft.AspNetCore.Mvc;
using SimpleApi1.Dtos;
using SimpleApi1.Helper;
using SimpleApi1.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;

        public UserController(IUserService userService,IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }


        //[HttpGet]
        //public ActionResult<List<UserDto>> Get()
        //{
        //    var service =  _userService.GetAll();
        //    return service;
        //}

        // api/user
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            //List<int> data = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            //var a = data.MaxSara();
            var service = await _userService.GetAllAsync();
            return service;
        }

        //// GET api/values?id=5
        //[HttpGet]
        //public ActionResult<UserDto> Get(int id)
        //{
        //    var service = _userService.Get(id);
        //    return service;
        //}


        // api/user/5
        //[HttpGet("majid/sara/{id}")]
        //public ActionResult<UserDto> Get(int id)
        //{
        //    var service = _userService.Get(id);
        //    return service;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetAsync(int id)
        {
            var service = await _userService.GetAsync(id);
            return service;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<UserDto> Post(UserDto userDto)
        {
            var service = _userService.Add(userDto);
            return service;
        }


        [HttpPost("AddEager")]
        public ActionResult<UserDto> AddEager(UserDto userDto)
        {
            var service = _userService.AddEager(userDto);
            return service;
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var service = _userService.Delete(id);
            return service;

        }


        [HttpPost("AddUserRole")]
        public async Task<ActionResult<UserRoleDto>> AddUserRole(UserRoleDto userRoleDto)
        {
            return await _userRoleService.AddAsync(userRoleDto);
        } 

    }
}
