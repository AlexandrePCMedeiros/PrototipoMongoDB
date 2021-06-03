using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using PrototipoMongoDB.Database.Mongo;
using PrototipoMongoDB.Models;
using PrototipoMongoDB.Repositories.Contracts;
using PrototipoMongoDB.Repositories.Mongo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFotografiaClientePFRepository _repository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<FotografiaClientePF> fotografias = ListarImagens();
            return View(fotografias);
        }

        [HttpPost]
        public IActionResult Index(IFormFile formFile)
        {
            MemoryStream ms = new MemoryStream();
            formFile.CopyTo(ms);
            byte[] binario = ms.ToArray();

            var services = new ServiceCollection();
            string connectionString = "mongodb+srv://biometriaIO_01:biometria@cluster0.eyqae.mongodb.net/Fotografia?retryWrites=true&w=majority";
            services.AddScoped(_ => new MContext(connectionString));
            var context = services.BuildServiceProvider().GetService<MContext>();
            _repository = new FotografiaClientePFRepository(context);

            FotografiaClientePF fotografiaClientePF = new FotografiaClientePF();
            var lista = _repository.List();
            if (lista.Count() == 0)
            {
                fotografiaClientePF.Id = 1;
            }
            else
            {
                fotografiaClientePF.Id = lista.OrderBy(f => f.Id).Last().Id + 1;
            }
            fotografiaClientePF.PedidoId = ObjectId.GenerateNewId().ToString();
            fotografiaClientePF.Imagem = binario;
            _repository.Add(fotografiaClientePF);
            //fotografiaClientePF = _repository.Get(fotografiaClientePF.Id);
            //return View(fotografiaClientePF);
            TempData["ID"] = fotografiaClientePF.Id;
            return View(_repository.List());
        }

        private IEnumerable<FotografiaClientePF> ListarImagens()
        {
            var services = new ServiceCollection();
            string connectionString = "mongodb+srv://biometriaIO_01:biometria@cluster0.eyqae.mongodb.net/Fotografia?retryWrites=true&w=majority";
            services.AddScoped(_ => new MContext(connectionString));
            var context = services.BuildServiceProvider().GetService<MContext>();
            _repository = new FotografiaClientePFRepository(context);
            var lista = _repository.List();
            return lista;
        }

        public IActionResult VisualizarImagem(int id)
        {
            TempData["ID"] = id;
            return RedirectToAction(nameof(Index));
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
    }
}
