using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urna2017_DTO;
using Urna2017_DAL;

namespace Urna2017_BLL
{
    public class CadCandidato_BLL
    {
        public static string ValidarCandidato(string CPF, string data, string chapa, byte[] foto, string apelido)
        {
            Candidato_DTO obj = new Candidato_DTO();
            if (string.IsNullOrWhiteSpace(CPF))
            {
                throw new Exception("Campo CPF vazio!");
            }
            
            if (string.IsNullOrWhiteSpace(chapa))
            {
                throw new Exception("Campo Chapa vazio!");
            }

            if (string.IsNullOrWhiteSpace(apelido))
            {
                throw new Exception("Campo Apelido vazio!");
            }
            
            try
            {
                DateTime valor = Convert.ToDateTime(data);
                obj = CadCandidato_DAL.BuscarCPF(CPF);
                int id_C = obj.IdCandidato;
                int id_E;
                CadCandidato_DAL.RetornaData(out id_E);
                return CadCandidato_DAL.CadastrarCand(id_C, id_E, chapa, foto, apelido);
            }

            catch (Exception ex)
            {
                throw new Exception("erro aqui" + ex.Message);
            }
        }

        public static Candidato_DTO ValidaCPF(string cpf)
        {
            Candidato_DTO obj = new Candidato_DTO();

            if (string.IsNullOrWhiteSpace(cpf))
            {
                throw new Exception("Campo CPF vazio!");
            }
            try
            {
                obj = CadCandidato_DAL.BuscarCPF(cpf);
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string RetornaData()
        {
            int id;
            return CadCandidato_DAL.RetornaData(out id);
        }
    }
}
