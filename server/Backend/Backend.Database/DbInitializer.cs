using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Database.Models;

namespace Backend.Database
{
    public class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            // Look for any students.
            if (context.Pessoas.Any())
            {
                return;   // já esta alimentado
            }

            var pessoas = new Pessoa[]
            {
                new Pessoa{Cpf = "12718414790", DtCadastro = DateTime.Now, DtNascimento = DateTime.Today, Nome = "David"}
            };

            var empresas = new Empresa[]
            {
                new Empresa
                {
                    Cnpj = "88888888888",
                    Nome = "Empresa A",
                    RazaoSocial = "Razao A",
                    DtCadastro = DateTime.Now
                }
            };

            var colaboradores = new Colaborador[]
            {
                new Colaborador {Empresa = empresas.First(), Pessoa = pessoas.First(), Salario = 6000, Status = 1, Cargo = "Desenvolvedor Web", DtCadastro = DateTime.Now}
            };

            context.Pessoas.AddRange(pessoas);
            context.Empresas.AddRange(empresas);
            context.Colaboradores.AddRange(colaboradores);
            context.SaveChanges();

        }
    }
}
