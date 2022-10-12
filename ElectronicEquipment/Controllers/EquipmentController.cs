﻿using ElectronicEquipment.Models;
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


        [HttpGet("getequipment")]
        public IActionResult Get()
        {
            return Ok(_context.Equipment.ToList().Select(a => new { a.EquipmentId, a.EquipmentName }));
        }

        [HttpPost("addequipment")]
        public IActionResult Add(Equipments equipments)
        {
            if (_context.Equipment.Where(u => u.EquipmentName == equipments.EquipmentName).FirstOrDefault() != null)
            {
                return Ok("EquipmentExist");
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
                return Ok("Equipment Not Available");
            }
            _context.Equipment.Remove(equipment);
            _context.SaveChanges();
            return Ok("Success");

        }

        //[HttpDelete("deleteequipment")]
        //public IActionResult DeleteEquipmentCategory(DeleteEquipment deleteEquipment)
        //{
        //    var equipment = _context.Equipment.Where(u => u.EquipmentName == deleteEquipment.EquipmentName).FirstOrDefault();
        //    if (equipment == null)
        //    {
        //        return Ok("Equipment Not Available");
        //    }
        //    _context.Equipment.Remove(equipment);
        //    _context.SaveChanges();
        //    return Ok("Success");

        //}
    }
}
