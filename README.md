# LIMS Inventory Intelligence Sandbox

This solution demonstrates how we are extending the laboratory information
management system (LIMS) with an AI-guided inventory dashboard. The goal of
this sandbox is twofold:

1. Explore new features in isolation before integrating them into the main LIMS
   product.
2. Serve as a teaching aid for interns joining the .NET team.

## Solution tour

The ASP.NET MVC application surfaces three key layers that we will build on
throughout the project:

| Layer | Purpose | Key Files |
| --- | --- | --- |
| Data | Supplies inventory records. Currently an in-memory repository that we
  will later swap for a persistent source. | `Data/InventoryRepository.cs` |
| Intelligence | Houses the AI/ML logic. At the moment this is a rule-based
  service designed to mimic the shape of a production insight engine. | `Services/InventoryInsightService.cs` |
| Presentation | Displays a single-page dashboard that visualises stock levels
  and surfaced insights. | `Controllers/InventoryController.cs`, `Views/Inventory/Index.cshtml` |

Interns: read through each layer in the order above to understand how data
flows from raw records to actionable recommendations.

## Running the project locally

1. Restore packages (first run only): `nuget restore` from the solution root.
2. Build the solution in Visual Studio (2019 or later) targeting .NET Framework
   4.7.2.
3. Press **F5** to launch the development server. The default route now points
   at `/Inventory/Index`, which renders the AI inventory dashboard.

## Next steps for the team

- Replace the in-memory repository with a call into the LIMS data service.
- Train and integrate a forecasting model to replace the heuristic insight
  engine.
- Capture user feedback from lab managers to validate that the surfaced
  insights align with real-world expectations.

Document your experiments in this repository so we build a knowledge base for
future joiners.
