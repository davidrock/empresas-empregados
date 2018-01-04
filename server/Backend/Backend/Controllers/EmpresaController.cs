using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [EnableCors("AllowAll")]
    [Produces("application/json")]
    [Route("api/Empresa")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var empresas = _empresaService.ListarEmpresas();

                return new OkObjectResult(empresas);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestObjectResult(new ErrorModel
                {
                    Code = 500,
                    Motivo = e.Message
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var p = _empresaService.ObterEmpresa(id);

                return new OkObjectResult(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestObjectResult(new ErrorModel
                {
                    Code = 500,
                    Motivo = e.Message
                });
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromBody]Empresa model)
        {
            try
            {
                var id = _empresaService.Novo(model);
                return new OkObjectResult(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestObjectResult(new ErrorModel
                {
                    Code = 500,
                    Motivo = e.Message
                });
            }
        }

        
        [HttpPut]
        public IActionResult Put([FromBody]Empresa model)
        {
            try
            {
                var id = _empresaService.Alterar(model);
                return new OkObjectResult(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestObjectResult(new ErrorModel
                {
                    Code = 500,
                    Motivo = e.Message
                });
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _empresaService.RemoverEmpresa(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestObjectResult(new ErrorModel
                {
                    Code = 500,
                    Motivo = e.Message
                });
            }
        }
    }
}
