using Microsoft.AspNetCore.Mvc;
using ServiceLifeTime.Models;
using ServiceLifeTime.Services;
using System.Diagnostics;
using System.Text;

namespace ServiceLifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingleton sService1;
        private readonly ISingleton sService2;
        private readonly IScopped scService1;
        private readonly IScopped scService2;
        private readonly ITransiant tService1;
        private readonly ITransiant tService2;

        public HomeController(ISingleton SService1,ISingleton SService2
            , IScopped ScService1, IScopped ScService2
            , ITransiant TService1, ITransiant TService2)
        {
            sService1 = SService1;
            sService2 = SService2;
            scService1 = ScService1;
            scService2 = ScService2;
            tService1 = TService1;
            tService2 = TService2;
        }

        public string Index()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Singleton 1: {sService1.GetGuid()}");
            sb.AppendLine($"Singleton 2: {sService2.GetGuid()}");
            sb.AppendLine($"Scopped 1: {scService1.GetGuid()}");
            sb.AppendLine($"Scopped 2: {scService2.GetGuid()}");
            sb.AppendLine($"Transiant 1: {tService1.GetGuid()}");
            sb.AppendLine($"Transiant 2: {tService2.GetGuid()}");


            return sb.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
