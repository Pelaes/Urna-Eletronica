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
    public class CadEleicao_DAL
    {
        public static string CadastrarEleicao (Eleicao_DTO obj, string data)
        {
            try
            {
                string script = "INSERT INTO Eleicao (data_eleicoes, descricao, ativa ) VALUES (@Data, @Descricao, 'Agendada')";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                cmd.Parameters.AddWithValue("@Data", data);
                cmd.Parameters.AddWithValue("@Descricao", obj.Nome);
                cmd.ExecuteNonQuery();
                return "Eleição cadastrada com sucesso!";
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
