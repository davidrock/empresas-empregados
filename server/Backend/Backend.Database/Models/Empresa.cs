using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Database.Models
{
    public partial class Empresa
    {

        public Empresa()
        {
            Colaboradores = new HashSet<Colaborador>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public DateTime DtCadastro { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
