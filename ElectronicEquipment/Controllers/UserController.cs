using ElectronicEquipment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Cors;
using System;
using System.Linq;

namespace ElectronicEquipment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public readonly UserContext _context;
        public UserController(IConfiguration configuration,UserContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("adduser")]
        public IActionResult Add(User user)
        {
            if (_context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault() != null)
            {
                return Ok("User Exist");
            }
            else if(user.Password!=user.ConfirmPassword)
            {
                return Ok("Please Confirm Your Password");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Success");
        }

        [HttpPost("loginuser")]
        public IActionResult Login(Login login)
        {
            var user = _context.Users.Where(u=> u.UserName==login.UserName && u.Password==login.Password).FirstOrDefault();
            if (user != null)
            {
                return Ok("Success");
            }
            else
            {
                return Ok("Failure");
            }
        }

        [HttpPut("updateuser")]
        public IActionResult UpdateUser(UpdatePassword updatePassword)
        {
            var users=_context.Users.Where(u=>u.UserName==updatePassword.UserName && u.Password==updatePassword.Password).FirstOrDefault();
            if (users == null)
            {
                return Ok("User Not Available");
            }
            else if(updatePassword.NewPassword!=updatePassword.ConfirmPassword)
            {
                return Ok("Please Confirm Your Password Correctly");
            }
            else
            {
                users.Password = updatePassword.NewPassword;
            }

            
            
            
            _context.Update(users);
            _context.SaveChanges();
            return Ok("Success");
            
        }
    }
}
