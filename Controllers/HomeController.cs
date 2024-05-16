using Microsoft.AspNetCore.Mvc;
using Sprint2.Models;
using System.Diagnostics;

namespace Sprint2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult TendenciasGastos()
        {
            // Aqui voc� pode escrever a l�gica para carregar e exibir os dados de tend�ncias de gastos
            return View();
        }

        // GET: DesempenhoFinanceiro
        public ActionResult DesempenhoFinanceiro()
        {
            // Aqui voc� pode escrever a l�gica para carregar e exibir os dados de desempenho financeiro
            return View();
        }

        // GET: ComportamentoNegocios
        public ActionResult ComportamentoNegocios()
        {
            // Aqui voc� pode escrever a l�gica para carregar e exibir os dados de comportamento de neg�cios
            return View();
        }
    }
}
