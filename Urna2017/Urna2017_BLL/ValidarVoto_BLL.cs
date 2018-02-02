using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Urna2017_DAL;
using Urna2017_DTO;

//luiz zica...

//muleke piranha

//carai...

namespace Urna2017_BLL
{
    public class ValidarVoto_BLL
    {
        public static string ConfirmarVoto(int chapa, int eleicao, int eleitor)
        {
            if (string.IsNullOrWhiteSpace(chapa.ToString()))
            {
                throw new Exception("Digite o número do Candidato!");
            }
            string msg;
            msg = ValidarVoto_DAL.ValidarVoto(chapa, eleicao, eleitor);
            return msg;
        }

        public static Candidato_DTO AtribuirImagem(int chapa)
        {
            Candidato_DTO obj = new Candidato_DTO();
            
            obj = ValidarVoto_DAL.AtribuirImagem(chapa);

            return obj;           
        }
    }
}
