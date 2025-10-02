using System;
using System.Collections.Generic;
using System.Linq;
using test_lab_inventory.Models;

namespace test_lab_inventory.Services
{
    /// <summary>
    /// Simple rule based implementation that approximates AI behaviour. The
    /// emphasis here is showing the interns how to structure the code so it can
    /// be replaced with a richer model later.
    /// </summary>
    public class InventoryInsightService : IInventoryInsightService
    {
        public IList<InventoryInsight> BuildInsights(IList<InventoryItem> items)
        {
            var insights = new List<InventoryInsight>();

            if (items == null || !items.Any())
            {
                insights.Add(new InventoryInsight
                {
                    Title = "Inventory is empty",
                    Message = "No inventory items were supplied. Double check the data source.",
                    Severity = InsightSeverity.Warning
                });

                return insights;
            }

            foreach (var item in items)
            {
                EvaluateStockLevels(item, insights);
                EvaluateExpiration(item, insights);
            }

            EvaluateCriticalCoverage(items, insights);

            return insights;
        }

        public IDictionary<string, double> CalculateCategoryUtilization(IList<InventoryItem> items)
        {
            return items
                .GroupBy(i => i.Category)
                .ToDictionary(
                    g => g.Key,
                    g => Math.Round(g.Sum(item => item.AverageDailyUsage), 2));
        }

        private static void EvaluateStockLevels(InventoryItem item, IList<InventoryInsight> insights)
        {
            if (item.QuantityOnHand <= item.ReorderPoint)
            {
                insights.Add(new InventoryInsight
                {
                    Title = $"Reorder recommended: {item.Name}",
                    Message = $"Current stock is {item.QuantityOnHand} while the reorder threshold is {item.ReorderPoint}.",
                    Severity = InsightSeverity.Critical
                });
            }
            else if (item.QuantityOnHand <= item.ReorderPoint * 1.5)
            {
                insights.Add(new InventoryInsight
                {
                    Title = $"Monitor stock: {item.Name}",
                    Message = "Inventory is trending low. Schedule a restock in the next procurement cycle.",
                    Severity = InsightSeverity.Warning
                });
            }
        }

        private static void EvaluateExpiration(InventoryItem item, IList<InventoryInsight> insights)
        {
            if (!item.ExpirationDate.HasValue)
            {
                return;
            }

            var daysUntilExpiration = (item.ExpirationDate.Value - DateTime.UtcNow.Date).TotalDays;

            if (daysUntilExpiration <= 0)
            {
                insights.Add(new InventoryInsight
                {
                    Title = $"Expired material: {item.Name}",
                    Message = "Remove and safely dispose expired inventory immediately.",
                    Severity = InsightSeverity.Critical
                });
            }
            else if (daysUntilExpiration <= 14)
            {
                insights.Add(new InventoryInsight
                {
                    Title = $"Expiring soon: {item.Name}",
                    Message = $"Only {daysUntilExpiration:0} day(s) remain before expiration.",
                    Severity = InsightSeverity.Warning
                });
            }
        }

        private static void EvaluateCriticalCoverage(IList<InventoryItem> items, IList<InventoryInsight> insights)
        {
            var criticalCategories = new[] { "Reagents", "Controls" };

            foreach (var category in criticalCategories)
            {
                var categoryItems = items.Where(item => item.Category == category).ToList();
                if (!categoryItems.Any())
                {
                    continue;
                }

                var coverageDays = CalculateCoverageDays(categoryItems);

                if (coverageDays < 7)
                {
                    insights.Add(new InventoryInsight
                    {
                        Title = $"Low {category} coverage",
                        Message = $"Projected coverage is {coverageDays:0.0} day(s). Prepare urgent replenishment.",
                        Severity = InsightSeverity.Critical
                    });
                }
            }
        }

        private static double CalculateCoverageDays(IEnumerable<InventoryItem> items)
        {
            var totalQuantity = items.Sum(item => item.QuantityOnHand);
            var totalDailyUsage = items.Sum(item => Math.Max(item.AverageDailyUsage, 0.1));

            return Math.Round(totalQuantity / totalDailyUsage, 1);
        }
    }
}
