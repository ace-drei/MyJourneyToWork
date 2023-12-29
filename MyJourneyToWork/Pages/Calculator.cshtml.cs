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
            var history = HttpContext.Session.GetString("CalculationHistory");
            var historyList = history != null ? JsonConvert.DeserializeObject<List<double>>(history) : new List<double>();
            historyList.Add(calculator.sustainabilityWeighting);
            HttpContext.Session.SetString("CalculationHistory", JsonConvert.SerializeObject(historyList));
        }

        public List<double> GetCalculationHistory()
        {
            var history = HttpContext.Session.GetString("CalculationHistory");
            return history != null ? JsonConvert.DeserializeObject<List<double>>(history) : new List<double>();
        }
    }
}
