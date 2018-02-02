using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urna2017_DAL;
using Urna2017_DTO;

namespace Urna2017_BLL
{
    public class CadEleicao_BLL
    {
        public static string ValidarEleicao(Eleicao_DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                throw new Exception("Campo Nome vazio!");
            }
            try
            {
                DateTime data = Convert.ToDateTime(obj.DataEleicao);
                
                if (data >= DateTime.Today)
                {
                    string data_certa = data.ToShortDateString();
                    return CadEleicao_DAL.CadastrarEleicao(obj, data_certa);
                }
                else
                {
                    throw new Exception("Data Inválida!");
                }
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
