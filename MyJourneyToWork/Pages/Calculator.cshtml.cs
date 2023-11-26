using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MyJourneyToWork.Pages
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]
        public Calculator.Calculator calculator { get; set; }

        public void OnGet()
        {
            // This method is intentionally left empty as there is nothing to do on a GET request.
            // The functionality might be extended in the future.
            // For now, it serves as a placeholder.
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                SaveCalculationHistory();

            }
        }

        public void SaveCalculationHistory()
        {
            try
            {
                var history = HttpContext.Session.GetString("CalculationHistory");
                var historyList = history != null ? JsonConvert.DeserializeObject<List<double>>(history) : new List<double>();
                historyList.Add(calculator.sustainabilityWeighting);
                HttpContext.Session.SetString("CalculationHistory", JsonConvert.SerializeObject(historyList));
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or rethrow based on your application's error handling strategy.
                // Example: Log.Error($"Failed to save calculation history. Error: {ex.Message}");
                throw;
            }
        }



        public List<double> GetCalculationHistory()
        {
            try

            {
                var history = HttpContext.Session.GetString("CalculationHistory");
                return history != null ? JsonConvert.DeserializeObject<List<double>>(history) : new List<double>();
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or rethrow based on your application's error handling strategy.
                // Example: Log.Error($"Failed to retrieve calculation history. Error: {ex.Message}");
                throw;
            }

        }
    }
}
