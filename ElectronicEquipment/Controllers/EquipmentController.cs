using ElectronicEquipment.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ElectronicEquipment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class EquipmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public readonly UserContext _context;
        public EquipmentController(IConfiguration configuration, UserContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        [HttpPost("addequipment")]
        public IActionResult Add(Equipments equipments)
        {
            if (_context.Equipment.Where(u => u.EquipmentName == equipments.EquipmentName).FirstOrDefault() != null)
            {
                return Ok("Equipment Already Exist");
            }
            _context.Equipment.Add(equipments);
            _context.SaveChanges();
            return Ok("Success");
        }


        [HttpPut("updateequipment")]
        public IActionResult UpdateEquipmentCategory(Equipments equipments)
        {
            var equipment = _context.Equipment.Where(u => u.EquipmentId == equipments.EquipmentId).FirstOrDefault();
            if (equipment == null)
            {
                return Ok("Equipments Not Available");
            }

            equipment.EquipmentName = equipments.EquipmentName;
            equipment.PartId = equipments.PartId;
            equipment.EquipmentCategoryId = equipments.EquipmentCategoryId;
            equipment.EquipmentGroupId = equipments.EquipmentGroupId;

            _context.Update(equipment);
            _context.SaveChanges();
            return Ok("Success");

        }

        [HttpDelete("deleteequipment/{id}")]
        public IActionResult DeleteEquipmentCategory(int id)
        {
            var equipment = _context.Equipment.Where(u => u.EquipmentId == id).FirstOrDefault();
            if (equipment == null)
            {
                return Ok("EquipmentCategory Not Available");
            }
            _context.Equipment.Remove(equipment);
            _context.SaveChanges();
            return Ok("Success");

        }


















        //public int AddEquipment(Equipments equipments)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("usp_AddEquipment", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlParameter EquipmentsId = new SqlParameter("@EquipmentId", SqlDbType.Int);
        //    EquipmentsId.Direction = ParameterDirection.Output;
        //    cmd.Parameters.AddWithValue("@EquipmentId", equipments.EquipmentId);
        //    cmd.Parameters.AddWithValue("@EquipmentName", equipments.EquipmentName);
        //    cmd.Parameters.AddWithValue("@PartId", equipments.PartId);
        //    cmd.Parameters.AddWithValue("@EquipmentGroupId", equipments.EquipmentGroupId);
        //    cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipments.EquipmentCategoryId);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    return (int)EquipmentsId.Value;
        //}

        //[HttpPut]
        //[Route("updateequipment")]
        //public void UpdateEquipment(Equipments equipments)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("usp_UpdateEquipment", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@EquipmentId", equipments.EquipmentId);
        //    cmd.Parameters.AddWithValue("@EquipmentName", equipments.EquipmentName);
        //    cmd.Parameters.AddWithValue("@PartId", equipments.PartId);
        //    cmd.Parameters.AddWithValue("@EquipmentGroupId", equipments.EquipmentGroupId);
        //    cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipments.EquipmentCategoryId);
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //}



        //[HttpDelete]
        //[Route("deleteequipment/{EquipmentId}")]
        //public void DeleteEquipment(int equipmentId)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("usp_DeleteEquipment", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@EquipmentId", equipmentId);
        //    cmd.ExecuteNonQuery ();
        //    con.Close();
        //}
    }
}
