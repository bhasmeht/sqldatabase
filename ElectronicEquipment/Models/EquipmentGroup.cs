using System.Collections.Generic;

namespace ElectronicEquipment.Models
{
    public class EquipmentGroup
    {
        public int EquipmentGroupId { get; set; }
        public string EquipmentGroupName { get; set; }

        public int? EquipmentCategoryId { get; set; } // Foreign key
        public EquipmentCategory EquipmentCategory { get; set; } //// Reference navigation
        
        

    }
}
