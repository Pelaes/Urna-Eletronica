using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urna2017_DTO;
using Urna2017_DAL;

namespace Urna2017_BLL
{
    public class Login_BLL
    {
        public static Eleitor_DTO ValidarEleitor(string cpf)
        {
            
            if (string.IsNullOrWhiteSpace(cpf))
            {
                throw new Exception("Campo CPF vazio!");
            }
            try
            {
                return Login_DAL.ValidarEleitor(cpf);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool VerificarVoto(Eleitor_DTO obj)
        {
            try
            {
                return Login_DAL.VerificarVoto(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
