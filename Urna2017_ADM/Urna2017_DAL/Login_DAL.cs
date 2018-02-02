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
    public class Login_DAL
    {
        public static bool ValidarLogin (Login_DTO obj)
        {
            try
            {
                string script = "SELECT nome, usuario, senha FROM Administrador WHERE usuario = @Usuario AND senha = @Senha";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                cmd.Parameters.AddWithValue("@Usuario", obj.Usuario);
                cmd.Parameters.AddWithValue("@Senha", obj.Senha);
                SqlDataReader dados = cmd.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        obj.Nome = dados["nome"].ToString();
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
