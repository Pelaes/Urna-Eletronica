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
        public static bool ValidarLogin(Login_DTO obj)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(obj.Usuario))
                {
                    throw new Exception("Campo Usuário é obrigatório.");
                }
                if (string.IsNullOrWhiteSpace(obj.Senha))
                {
                    throw new Exception("Campo Senha é obrigatório.");
                }
                return Login_DAL.ValidarLogin(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
