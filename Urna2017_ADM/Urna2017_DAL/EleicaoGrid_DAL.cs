using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Urna2017_DTO;

namespace Urna2017_DAL
{
    public class EleicaoGrid_DAL
    {
        public static List<Eleicao_DTO> RetornarEleicao()
        {
            try
            {
                List<Eleicao_DTO> datas = new List<Eleicao_DTO>();
                string script = "SELECT TOP 5 data_eleicao, descricao, ativa FROM Eleicao WHERE ativa = 'Agendada' OR ativa = 'Ativa' ORDER BY data_eleicao";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                SqlDataReader dados = cmd.ExecuteReader();
                               
                while (dados.Read())
                {
                    Eleicao_DTO obj = new Eleicao_DTO();
                    obj.DataEleicao = dados["data_eleicao"].ToString();
                    obj.Nome = dados["descricao"].ToString();
                    obj.Status = dados["ativa"].ToString();
                    datas.Add(obj);
                }
                return datas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
            finally
            {
                if (Conexao_DAL.Conexao().State != ConnectionState.Closed)
                {
                    Conexao_DAL.Conexao().Close();
                }
            }
        }
    }
}
