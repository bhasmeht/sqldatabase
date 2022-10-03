using ElectronicEquipment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ElectronicEquipment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentCategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EquipmentCategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        [Route("addequipmentcategory")]
        public int AddEquipmentGroup(EquipmentCategory equipmentcategory)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_AddEquipmentCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter EquipmentsCategoryId = new SqlParameter("@EquipmentCategoryId", SqlDbType.Int);
            EquipmentsCategoryId.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipmentcategory.EquipmentCategoryId);
            cmd.Parameters.AddWithValue("@EquipmentCategoryName", equipmentcategory.EquipmentCategoryName);
            
            cmd.ExecuteNonQuery();
            con.Close();
            return (int)EquipmentsCategoryId.Value;
        }

        [HttpPost]
        [Route("updateequipmentcategory/{EquipmentCategoryId}")]
        public void UpdateEquipment(EquipmentCategory equipmentcategory)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_UpdateEquipmentCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipmentcategory.EquipmentCategoryId);
            cmd.Parameters.AddWithValue("@EquipmentCategoryName", equipmentcategory.EquipmentCategoryName);

            cmd.ExecuteNonQuery();
            con.Close();

        }

        [HttpDelete]
        [Route("deleteequipmentcategory/{EquipmentCategoryId}")]
        public void DeleteEquipment(int equipmentCategoryId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_DeleteEquipmentCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipmentCategoryId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
