using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna2017_DTO
{
    public class Eleitor_DTO
    {
        public int Id_Eleitor { get; set; }
        public int Id_Eleicao { get; set; }
        public string Descricao { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }
        public bool Retorno { get; set; }
    }
}
