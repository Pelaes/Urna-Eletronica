using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna2017_DTO
{
    public class Candidato_DTO
    {
        public int IdEleicao { get; set;}
        public int IdCandidato { get; set; }
        public string CPF { get; set; }
        public string Chapa { get; set; }
        public string Data { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }
        public string Modulo { get; set; }
        public string Foto { get; set; }
    }
}
