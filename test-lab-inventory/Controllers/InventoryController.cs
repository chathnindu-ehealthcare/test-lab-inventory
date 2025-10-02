using System.Web.Mvc;
using test_lab_inventory.Data;
using test_lab_inventory.Models;
using test_lab_inventory.Services;

namespace test_lab_inventory.Controllers
{
    /// <summary>
    /// Controller that wires together our repository and the insight service.
    /// Pay attention to how responsibilities are kept small and targeted – a
    /// key lesson for building maintainable enterprise code.
    /// </summary>
    public class InventoryController : Controller
    {
        private readonly IInventoryInsightService _insightService;

        public InventoryController()
            : this(new InventoryInsightService())
        {
        }

        public InventoryController(IInventoryInsightService insightService)
        {
            _insightService = insightService;
        }

        public ActionResult Index()
        {
            var items = InventoryRepository.LoadSampleInventory();

            var viewModel = new InventoryDashboardViewModel
            {
                Items = items,
                Insights = _insightService.BuildInsights(items),
                CategoryUtilization = _insightService.CalculateCategoryUtilization(items)
            };

            return View(viewModel);
        }
    }
}
