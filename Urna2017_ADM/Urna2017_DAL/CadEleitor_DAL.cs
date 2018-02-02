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
    public class CadEleitor_DAL
    {
        public static string CadastrarEleitor(Eleitor_DTO obj)
        {
            try
            {
                string script = "INSERT INTO Eleitor (nome, cpf, turma_cargo, modulo) VALUES (@Nome, @CPF, @Turma, @Modulo)";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                cmd.Parameters.AddWithValue("@Nome", obj.Nome);
                cmd.Parameters.AddWithValue("@Cpf", obj.CPF);
                cmd.Parameters.AddWithValue("@Turma", obj.Curso);
                cmd.Parameters.AddWithValue("@Modulo", obj.Modulo);
                cmd.ExecuteNonQuery();
                return "Eleitor cadastrado com sucesso";
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
