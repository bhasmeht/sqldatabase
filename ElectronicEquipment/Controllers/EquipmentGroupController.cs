using ElectronicEquipment.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ElectronicEquipment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class EquipmentGroupController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public readonly UserContext _context;
        public EquipmentGroupController(IConfiguration configuration, UserContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        

        [HttpGet("getequipmentcategorybygroupid/{id}")]
        public IActionResult GetequipmentGroupbyId(int id)
        {
            var equipmentCategoryList = _context.EquipmentGroups.Where(u => u.EquipmentCategoryId == id)
                .Select(a => new { a.EquipmentGroupId, a.EquipmentGroupName });
            return Ok(equipmentCategoryList);
        }

        [HttpPost("addequipmentgroup")]
        public IActionResult Add(EquipmentGroup equipmentGroup)
        {
            if (_context.EquipmentGroups.Where(u => u.EquipmentGroupName == equipmentGroup.EquipmentGroupName).FirstOrDefault() != null)
            {
                return Ok("EquipmentGroup Exist");
            }
            _context.EquipmentGroups.Add(equipmentGroup);
            _context.SaveChanges();
            return Ok("Success");
        }



        [HttpPut("updateequipmentgroup")]
        public IActionResult UpdateEquipmentCategory(EquipmentGroup equipmentGroup)
        {
            var equipmentGroups = _context.EquipmentGroups.Where(u => u.EquipmentGroupId == equipmentGroup.EquipmentGroupId).FirstOrDefault();
            if (equipmentGroups == null)
            {
                return Ok("EquipmentGroup Not Available");
            }

            equipmentGroups.EquipmentGroupName = equipmentGroup.EquipmentGroupName;
            equipmentGroups.EquipmentCategoryId = equipmentGroup.EquipmentCategoryId;

            _context.Update(equipmentGroups);
            _context.SaveChanges();
            return Ok("Success");

        }

        [HttpDelete("deleteequipmentgroup/{id}")]
        public IActionResult DeleteEquipmentGroup(int id)
        {
            var equipmentGroups = _context.EquipmentGroups.Where(u => u.EquipmentGroupId == id).FirstOrDefault();
            if (equipmentGroups == null)
            {
                return Ok("EquipmentGroup Not Available");
            }
            _context.EquipmentGroups.Remove(equipmentGroups);
            _context.SaveChanges();
            return Ok("Success");

        }


















        //[HttpPost]
        //[Route("addequipmentgroup")]
        //public int AddEquipmentGroup(EquipmentGroup equipmentgroup)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("usp_AddEquipmentGroup", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlParameter EquipmentsGroupId = new SqlParameter("@EquipmentGroupId", SqlDbType.Int);
        //    EquipmentsGroupId.Direction = ParameterDirection.Output;
        //    cmd.Parameters.AddWithValue("@EquipmentGroupId", equipmentgroup.EquipmentGroupId);
        //    cmd.Parameters.AddWithValue("@EquipmentGroupName", equipmentgroup.EquipmentGroupName);
        //    cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipmentgroup.EquipmentCategoryId);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    return (int)EquipmentsGroupId.Value;
        //}

        //[HttpPut]
        //[Route("updateequipmentgroup")]
        //public void UpdateEquipment(EquipmentGroup equipmentgroup)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("usp_UpdateEquipmentGroup", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@EquipmentGroupId", equipmentgroup.EquipmentGroupId);
        //    cmd.Parameters.AddWithValue("@EquipmentGroupName", equipmentgroup.EquipmentGroupName);
        //    cmd.Parameters.AddWithValue("@EquipmentCategoryId", equipmentgroup.EquipmentCategoryId);
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //}

        //[HttpDelete]
        //[Route("deleteequipmentgroup/{EquipmentGroupId}")]
        //public void DeleteEquipment(int equipmentGroupId)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Database").ToString());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("usp_DeleteEquipmentGroup", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@EquipmentGroupId", equipmentGroupId);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
    }
}
