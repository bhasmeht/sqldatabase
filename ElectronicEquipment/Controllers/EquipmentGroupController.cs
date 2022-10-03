using ElectronicEquipment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ElectronicEquipment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipmentGroupController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EquipmentGroupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addequipmentgroup")]
        public int AddEquipmentGroup(EquipmentGroup equipmentgroup)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_AddEquipmentGroup", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter EquipmentsGroupId = new SqlParameter("@EquipmentGroupId", SqlDbType.Int);
            EquipmentsGroupId.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@EquipmentGroupId", equipmentgroup.EquipmentGroupId);
            cmd.Parameters.AddWithValue("@EquipmentGroupName", equipmentgroup.EquipmentGroupName);
            cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipmentgroup.EquipmentCategoryId);
            cmd.ExecuteNonQuery();
            con.Close();
            return (int)EquipmentsGroupId.Value;
        }

        [HttpPost]
        [Route("updateequipmentgroup/{EquipmentGroupId}")]
        public void UpdateEquipment(EquipmentGroup equipmentgroup)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_UpdateEquipmentGroup", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EquipmentGroupId", equipmentgroup.EquipmentGroupId);
            cmd.Parameters.AddWithValue("@EquipmentGroupName", equipmentgroup.EquipmentGroupName);
            cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipmentgroup.EquipmentCategoryId);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        [HttpDelete]
        [Route("deleteequipmentgroup/{EquipmentGroupId}")]
        public void DeleteEquipment(int equipmentGroupId)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_DeleteEquipmentGroup", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EquipmentGroupId", equipmentGroupId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
