using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class Default : ControllerBase
    {
        [HttpGet]
        public string Inicio()
        {
            return "Ejecutando ...";
        }
    }
}
