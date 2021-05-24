using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InfoClimaWeb.Models;
using AKSoftware.WebApi.Client;
using Microsoft.Extensions.Configuration;

namespace InfoClimaWeb.Controllers
{
    public class HomeController : Controller
    {
        //Para el este ejemplo, desde el la web utilizaré AKSoftware.WebApi 
        //para las consultas a la api de InfoCLima
        private readonly ServiceClient _client = new ServiceClient();
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, ServiceClient client, IConfiguration configuration)
        {
            _logger = logger;
            _client = client;
            _configuration = configuration;
        }

        // Metodo HTTPGET que hará la llamada a la api InfoClima para obtener los climas
        [HttpGet]
        public async Task<JsonResult> getClimas(string nombreCiudad, bool Historico)
        {         
            var Climas = new List<ClimasModel>();
            var response = await _client.GetAsync<List<ClimasModel>>(
                $"{_configuration["InfoClimaApi"]}?Ciudad=" + nombreCiudad
                + "&historico=" + Historico);
            if (response.IsSucceded)
            {
                Climas = response.Result;
            }
            return Json(Climas);
        }
        // Metodo HTTPGET que hará la llamada a la api InfoClima para obtener las ciudades
        [HttpGet]
        public async Task<JsonResult> getCiudades(string nombreCiudad, bool Historico)
        {
            var Climas = new List<ClimasModel>();
            var response = await _client.GetAsync<List<ClimasModel>>(
                $"{_configuration["InfoClimaApi"]}Ciudades");
            if (response.IsSucceded)
            {
                Climas = response.Result;
            }
            return Json(Climas);
        }
        public IActionResult Index()
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
