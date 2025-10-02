using System.Collections.Generic;
using test_lab_inventory.Models;

namespace test_lab_inventory.Services
{
    /// <summary>
    /// Interface that describes the intelligence layer. By keeping everything
    /// behind an interface we can later swap in a true ML/AI model without
    /// breaking the rest of the system.
    /// </summary>
    public interface IInventoryInsightService
    {
        IList<InventoryInsight> BuildInsights(IList<InventoryItem> items);

        IDictionary<string, double> CalculateCategoryUtilization(IList<InventoryItem> items);
    }
}
