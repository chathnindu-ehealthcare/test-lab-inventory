using System;

namespace test_lab_inventory.Models
{
    /// <summary>
    /// Represents a single inventory item that we track within the lab.
    /// This class is intentionally lightweight so the interns can see
    /// how we map domain concepts (inventory) into concrete code.
    /// </summary>
    public class InventoryItem
    {
        public string ItemCode { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int QuantityOnHand { get; set; }

        public int ReorderPoint { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public double AverageDailyUsage { get; set; }

        public string StorageLocation { get; set; }
    }
}
