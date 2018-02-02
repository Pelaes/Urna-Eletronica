using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urna2017_DAL;
using Urna2017_DTO;

namespace Urna2017_BLL
{
    public class ControleEleicoes_BLL
    {
        public static List<Eleicao_DTO> RetEleicoes()
        {
            return EleicaoGrid_DAL.RetornarEleicao();
        }

        public static bool IniciarEleicao(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new Exception("Nenhuma data selecionada!");
            }
            try
            {
                return ControlaEleicao_DAL.IniciaEleicao(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static bool VerificaAtiva()
        {
            return ControlaEleicao_DAL.VerificaAtiva();
        }
    }
}
