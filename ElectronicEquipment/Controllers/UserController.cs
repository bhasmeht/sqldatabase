using ElectronicEquipment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Cors;

namespace ElectronicEquipment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("adduser")]
        
        public int AddUser(Users users)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_AddUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter UserId = new SqlParameter("@userId",SqlDbType.Int);
            UserId.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@userId", users.UserId);
            cmd.Parameters.AddWithValue("@username", users.UserName);
            cmd.Parameters.AddWithValue("@password", users.Password);
            cmd.Parameters.AddWithValue("@active", users.Active);
            cmd.ExecuteNonQuery();
            con.Close();
            return (int)UserId.Value;
        }

        [HttpPut]
        [Route("updateuser")]
        public void UpdateUser(Users users)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_UpdateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userId", users.UserId);
            cmd.Parameters.AddWithValue("@username", users.UserName);
            cmd.Parameters.AddWithValue("@password", users.Password);
            cmd.Parameters.AddWithValue("@active", users.Active);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        [Route("gethere")]
        public string Get()
        {
            return "Hello";
        }


    }
}
