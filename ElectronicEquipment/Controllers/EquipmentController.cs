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
    public class EquipmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EquipmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addequipment")]
        public int AddEquipment(Equipments equipments)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_AddEquipment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter EquipmentsId = new SqlParameter("@EquipmentId", SqlDbType.Int);
            EquipmentsId.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@EquipmentId", equipments.EquipmentId);
            cmd.Parameters.AddWithValue("@EquipmentName", equipments.EquipmentName);
            cmd.Parameters.AddWithValue("@PartId", equipments.PartId);
            cmd.Parameters.AddWithValue("@EquipmentGroupId", equipments.EquipmentGroupId);
            cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipments.EquipmentCategoryId);
            cmd.ExecuteNonQuery();
            con.Close();
            return (int)EquipmentsId.Value;
        }

        [HttpPost]
        [Route("updateequipment/{EquipmentId}")]
        public void UpdateEquipment(Equipments equipments)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_UpdateEquipment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EquipmentId", equipments.EquipmentId);
            cmd.Parameters.AddWithValue("@EquipmentName", equipments.EquipmentName);
            cmd.Parameters.AddWithValue("@PartId", equipments.PartId);
            cmd.Parameters.AddWithValue("@EquipmentGroupId", equipments.EquipmentGroupId);
            cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipments.EquipmentCategoryId);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        [HttpDelete]
        [Route("deleteequipment/{EquipmentId}")]
        public void DeleteEquipment(int equipmentId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_DeleteEquipment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EquipmentId", equipmentId);
            cmd.ExecuteNonQuery ();
            con.Close();
        }
    }
}
