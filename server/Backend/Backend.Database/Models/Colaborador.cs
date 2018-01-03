using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Database.Models
{
    public partial class Colaborador
    {
        public int EmpresaId { get; set; }
        public int PessoaId { get; set; }
        public decimal Salario { get; set; }
        public int Status { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtDemissao { get; set; }
        public string Cargo { get; set; }

        public Pessoa Pessoa { get; set; }
        public Empresa Empresa { get; set; }

    }
}
