using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ask2Friends.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ask2Friends.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetList()
        {
            var result = _userService.GetAllUsers();

            return Ok(result);
        }
    }
}