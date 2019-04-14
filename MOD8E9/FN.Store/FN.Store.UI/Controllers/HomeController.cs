using Microsoft.AspNetCore.Mvc;

namespace FN.Store.UI.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index() => View();

        public ViewResult About() => View();

    }
}