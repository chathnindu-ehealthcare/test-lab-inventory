using System.Collections.Generic;

namespace test_lab_inventory.Models
{
    /// <summary>
    /// View model that packages everything the Razor view needs to render the
    /// dashboard. Teaching moment: we never want to pass domain models directly
    /// to the UI because we would then leak extra fields that the page does not
    /// actually require.
    /// </summary>
    public class InventoryDashboardViewModel
    {
        public IList<InventoryItem> Items { get; set; }

        public IList<InventoryInsight> Insights { get; set; }

        public IDictionary<string, double> CategoryUtilization { get; set; }
    }
}
