using System;
using System.Collections.Generic;
using test_lab_inventory.Models;

namespace test_lab_inventory.Data
{
    /// <summary>
    /// Temporary in-memory store while we develop the UI. Interns: notice how
    /// the repository only concerns itself with supplying data and nothing else.
    /// Later we can replace this with Entity Framework or an API call without
    /// touching the controller.
    /// </summary>
    public static class InventoryRepository
    {
        public static IList<InventoryItem> LoadSampleInventory()
        {
            return new List<InventoryItem>
            {
                new InventoryItem
                {
                    ItemCode = "RGT-001",
                    Name = "PCR Master Mix",
                    Category = "Reagents",
                    QuantityOnHand = 24,
                    ReorderPoint = 30,
                    ExpirationDate = DateTime.UtcNow.Date.AddDays(10),
                    AverageDailyUsage = 4.5,
                    StorageLocation = "Cold Room A"
                },
                new InventoryItem
                {
                    ItemCode = "CTL-004",
                    Name = "Positive Control Kit",
                    Category = "Controls",
                    QuantityOnHand = 6,
                    ReorderPoint = 8,
                    ExpirationDate = DateTime.UtcNow.Date.AddDays(2),
                    AverageDailyUsage = 1.2,
                    StorageLocation = "Quality Cabinet"
                },
                new InventoryItem
                {
                    ItemCode = "SUP-015",
                    Name = "Pipette Tips 200µL",
                    Category = "Consumables",
                    QuantityOnHand = 3200,
                    ReorderPoint = 2000,
                    ExpirationDate = null,
                    AverageDailyUsage = 250,
                    StorageLocation = "Inventory Aisle 3"
                },
                new InventoryItem
                {
                    ItemCode = "RGT-010",
                    Name = "Antibody Diluent",
                    Category = "Reagents",
                    QuantityOnHand = 12,
                    ReorderPoint = 15,
                    ExpirationDate = DateTime.UtcNow.Date.AddDays(-1),
                    AverageDailyUsage = 2.1,
                    StorageLocation = "Cold Room B"
                },
                new InventoryItem
                {
                    ItemCode = "EQP-101",
                    Name = "Calibration Beads",
                    Category = "Calibration",
                    QuantityOnHand = 2,
                    ReorderPoint = 5,
                    ExpirationDate = DateTime.UtcNow.Date.AddDays(90),
                    AverageDailyUsage = 0.2,
                    StorageLocation = "Equipment Shelf"
                }
            };
        }
    }
}
