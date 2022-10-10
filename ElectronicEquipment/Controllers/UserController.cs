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
        public IActionResult UpdateUser(User user)
        {
            var users=_context.Users.Where(u=>u.UserId==user.UserId).FirstOrDefault();
            if (users == null)
            {
                return Ok("User Not Available");
            }

            users.UserName = user.UserName;
            users.Password = user.Password;
            users.Active = user.Active;
            _context.Update(users);
            _context.SaveChanges();
            return Ok("Success");
            
        }



























        
        
        //[HttpPost]
        //[Route("adduser")]
        //public string AddUser([FromBody] Users users)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("usp_AddUser", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlParameter UserId = new SqlParameter("@userId",SqlDbType.Int);
        //    UserId.Direction = ParameterDirection.Output;
        //    cmd.Parameters.AddWithValue("@userId", users.UserId);
        //    cmd.Parameters.AddWithValue("@username", users.UserName);
        //    cmd.Parameters.AddWithValue("@password", users.Password);
        //    cmd.Parameters.AddWithValue("@active", users.Active);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    return UserId.Value.ToString();
        //}

        //[HttpPost]
        //[Route("loginuser")]
        //public string Login(Login login)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
        //    con.Open();
        //    //var userNameStatus=con.UserDB.Contains(login.UserName);
        //    var userNameStatus= con.Database.Contains(login.UserName);
        //    if(userNameStatus)
        //    {
        //        return "Ok";
        //    }


        //    return "Failure";
        //}
        

        //[HttpPut]
        //[Route("updateuser/{id}")]
        //public void UpdateUser( Users users)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("usp_UpdateUser", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.Parameters.AddWithValue("@userId", users.UserId);
        //    if(users.UserId )
        //    {
        //        cmd.Parameters.AddWithValue("@username", users.UserName);
        //        cmd.Parameters.AddWithValue("@password", users.Password);
        //        cmd.Parameters.AddWithValue("@active", users.Active);
        //    }

            
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //}

        //[Route("gethere")]
        //public string Get()
        //{
        //    return "Hello";
        //}


    }
}
