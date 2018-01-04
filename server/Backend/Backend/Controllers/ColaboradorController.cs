using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Database.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [EnableCors("AllowAll")]
    [Produces("application/json")]
    [Route("api/Colaborador")]
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var colaboradors = _colaboradorService.ListarColaboradores();

                return new OkObjectResult(colaboradors);
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
                var p = _colaboradorService.ObterColaborador(id);

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
        public IActionResult Post([FromBody]Colaborador model)
        {
            try
            {
                _colaboradorService.Novo(model);
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
        
        [HttpPut]
        public IActionResult Put([FromBody]Colaborador model)
        {
            try
            {
                var id = _colaboradorService.Alterar(model);
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

        
        [HttpDelete]
        public IActionResult Delete(Colaborador model)
        {
            try
            {
                _colaboradorService.RemoverColaborador(model);
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

        [HttpPost]
        [Route("demitir")]
        public IActionResult Demitir([FromBody]Colaborador model)
        {
            try
            {
                _colaboradorService.DemitirColaborador(model);
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
