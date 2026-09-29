using System.ComponentModel.DataAnnotations;

namespace Pizza_Delievery_System.Models
{
    public class InventoryTransaction
    {

        [Key]
        public int InventoryTransactionID { get; set; }

        public string ItemType { get; set; }

        public int ItemID { get; set; }
    }
}
