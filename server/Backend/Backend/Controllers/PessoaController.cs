﻿using System;
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
    [Route("api/Pessoa")]
    public class PessoaController : Controller
    {

        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pessoas = _pessoaService.ListarPessoas();

                return new OkObjectResult(pessoas);
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
                var p = _pessoaService.ObterPessoa(id);

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
        public IActionResult Post([FromBody]Pessoa model)
        {
            try
            {
                var id = _pessoaService.Novo(model);
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
        public IActionResult Put([FromBody]Pessoa model)
        {
            try
            {
                var id = _pessoaService.Alterar(model);
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
                _pessoaService.RemoverPessoa(id);
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
