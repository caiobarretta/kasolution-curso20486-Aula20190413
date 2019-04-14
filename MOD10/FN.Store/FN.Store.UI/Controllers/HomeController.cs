using Microsoft.AspNetCore.Mvc;

namespace FN.Store.UI.Controllers
{
    public class HomeController : Controller
    {

        //Método criado para querbra o teste
        //public IActionResult Index() => Json(new { });

        public ViewResult Index() => View();
        
        public ViewResult About() => View();

    }
}