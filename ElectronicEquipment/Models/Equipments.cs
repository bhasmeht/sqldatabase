using System.ComponentModel.DataAnnotations;

namespace ElectronicEquipment.Models
{
    public class Equipments
    {
        [Key]
        
        public int EquipmentId { get; set; }
        [Required]
        public string EquipmentName { get; set; }
        [Required]
        public string PartId { get; set; }
        
        
        
        public int? EquipmentCategoryId { get; set; } // Foreign key
        public EquipmentCategory EquipmentCategory { get; set; } //// Reference navigation
        
        public int? EquipmentGroupId { get; set; }
        public EquipmentGroup EquipmentGroup { get; set; }
    }
}
