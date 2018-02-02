using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Urna2017_DAL
{
    public class ControlaEleicao_DAL
    {
        public static bool IniciaEleicao(string data)
        {
            try
            {
                string script = "UPDATE Eleicao SET ativa = 'Ativa' WHERE data_eleicao = @Data";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                cmd.Parameters.AddWithValue("@Data", data);
                cmd.ExecuteNonQuery();
                return true;
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

        public static bool VerificaAtiva()
        {
            try
            {
                string script = "SELECT ativa FROM Eleicao WHERE ativa = 'Ativa'";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                SqlDataReader dados = cmd.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        return true;
                    }
                }
                return false;
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
