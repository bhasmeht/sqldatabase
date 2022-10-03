namespace ElectronicEquipment.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
    public class Equipments
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string PartId { get; set; }
        public int EquipmentGroupId { get; set; }
        public int EquipmentCategoryId { get; set; }
    }

    public class EquipmentGroup
    {
        public int EquipmentGroupId { get;set; }
        public string EquipmentGroupName { get;set; }
        public int EquipmentCategoryId { get; set; }
    }

    public class EquipmentCategory
    {
        public int EquipmentCategoryId { get;set; }
        public string EquipmentCategoryName { get; set; }

    }
}
