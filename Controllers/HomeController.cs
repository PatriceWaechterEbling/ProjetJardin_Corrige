using Microsoft.AspNetCore.Mvc;
using ProjetJardin.Models;
using System.Diagnostics;

namespace ProjetJardin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ContexteApplication _contexteApplication;

        public HomeController(ILogger<HomeController> logger, ContexteApplication contexte)
        {
            _logger = logger;
            _contexteApplication = contexte;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            if(_contexteApplication.Jardins.FirstOrDefault() == null)
            { 
                Legume l1 = new Legume();
                l1.Name = "Carotte";
                l1.Description = "Belle et Bonne";
                l1.Vitamine = "32 grammes";

                Legume l3 = new Legume();
                l3.Name = "Céleri";
                l3.Description = "Beau et Bon";
                l3.Vitamine = "44 grammes";

                Fruit l2 = new Fruit();
                l2.Name = "Pomme";
                l2.Description = "rouge";
                l2.Sucre = "10 grammes";

                Fruit l4 = new Fruit();
                l4.Name = "Poire";
                l4.Description = "Verte";
                l4.Sucre = "14 grammes";

                List<Aliment> listeAliments = new List<Aliment>();
                listeAliments.Add(l1);
                listeAliments.Add(l2);
                listeAliments.Add(l3);
                listeAliments.Add(l4);

                Jardin j1 = new Jardin();
                j1.Surface = 10;
                j1.Emplacement = "Ici";
                j1.Aliment = listeAliments;

                Jardin j2 = new Jardin();
                j2.Surface = 20;
                j2.Emplacement = "Là-bas";
                j2.Aliment = listeAliments;

                _contexteApplication.Add(l1);
                _contexteApplication.Add(l2);
                _contexteApplication.Add(l3);
                _contexteApplication.Add(l4);
                _contexteApplication.Add(j1);
                _contexteApplication.Add(j2);


                _contexteApplication.SaveChanges();
            }

            Fruit? fruit = _contexteApplication.FruitJardins.Where(f => f.Name == "Poire").FirstOrDefault();

            if(fruit != null)
            {
                fruit.Description = "Jaune";
                _contexteApplication.SaveChanges();
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}