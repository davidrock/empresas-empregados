using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Database.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public DateTime DtCadastro { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
