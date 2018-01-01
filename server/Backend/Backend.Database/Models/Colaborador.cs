using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Database.Models
{
    public class Colaborador
    {
        public int EmpresaId { get; set; }
        public int PessoaId { get; set; }
        public decimal Salario { get; set; }
        public int Status { get; set; }

        public Pessoa Pessoa { get; set; }
        public Empresa Empresa { get; set; }

    }
}
