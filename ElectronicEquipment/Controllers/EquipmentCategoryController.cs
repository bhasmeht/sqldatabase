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
    public class EquipmentCategoryController : ControllerBase
    {
        


        private readonly IConfiguration _configuration;
        public readonly UserContext _context;
        public EquipmentCategoryController(IConfiguration configuration, UserContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet("getequipmentcategory")]
        public IActionResult Get()
        {
            return Ok(_context.EquipmentCategories.ToList());
        }



        [HttpPost("addequipmentcategory")]
        public IActionResult Add(EquipmentCategory equipmentCategory)
        {
            if (_context.EquipmentCategories.Where(u => u.EquipmentCategoryName == equipmentCategory.EquipmentCategoryName).FirstOrDefault() != null)
            {
                return Ok("EquipmentCategory Exist");
            }
            _context.EquipmentCategories.Add(equipmentCategory);
            _context.SaveChanges();
            return Ok("Success");
        }



        [HttpPut("updateequipmentcategory")]
        public IActionResult UpdateEquipmentCategory(EquipmentCategory equipmentCategory)
        {
            var equipmentCategories = _context.EquipmentCategories.Where(u => u.EquipmentCategoryId == equipmentCategory.EquipmentCategoryId).FirstOrDefault();
            if (equipmentCategories == null)
            {
                return Ok("EquipmentCategory Not Available");
            }

            equipmentCategories.EquipmentCategoryName = equipmentCategory.EquipmentCategoryName;

            _context.Update(equipmentCategories);
            _context.SaveChanges();
            return Ok("Success");

        }

        [HttpDelete("deleteequipmentcategory/{id}")]
        public IActionResult DeleteEquipmentCategory(int id)
        {
            var equipmentCategories = _context.EquipmentCategories.Where(u => u.EquipmentCategoryId == id).FirstOrDefault();
            if (equipmentCategories == null)
            {
                return Ok("EquipmentCategory Not Available");
            }
            _context.EquipmentCategories.Remove(equipmentCategories);
            _context.SaveChanges();
            return Ok("Success");

        }
    }
}
