using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urna2017_DAL;
using Urna2017_DTO;

namespace Urna2017_BLL
{
    public class CadEleitor_BLL
    {
        public static string ValidarEleitor(Eleitor_DTO obj)
        {
            
            if (string.IsNullOrWhiteSpace(obj.CPF))
            {
                throw new Exception("Campo CPF vazio!");
            }

            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                throw new Exception("Campo Nome vazio!");
            }

            if (string.IsNullOrWhiteSpace(obj.Curso))
            {
                throw new Exception("Campo Curso vazio!");
            }

            if (string.IsNullOrWhiteSpace(obj.Modulo))
            {
                throw new Exception("Campo Módulo vazio!");
            }

            try
            {
                Convert.ToInt32(obj.Modulo);
                return CadEleitor_DAL.CadastrarEleitor(obj);
            }

            catch (Exception)
            {
                throw new Exception("O valor usado para o módulo deve ser um numero inteiro");
            }
        }
    }
}
