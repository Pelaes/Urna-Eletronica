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
        public static Eleitor_DTO ValidarEleitor(string cpf)
        {
            Eleitor_DTO obj = new Eleitor_DTO();
            try
            {
                string script = "SELECT id_eleitores, nome, cpf, turma_cargo, id_eleicoes, descricao FROM Eleitor, Eleicao WHERE cpf = @cpf AND ativa = 'Ativa'";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                cmd.Parameters.AddWithValue("@cpf", cpf);
                SqlDataReader dados = cmd.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        obj.Id_Eleitor = Convert.ToInt32(dados["id_eleitores"]);
                        obj.CPF = dados["cpf"].ToString();
                        obj.Nome = dados["nome"].ToString();
                        obj.Turma = dados["turma_cargo"].ToString();
                        obj.Id_Eleicao = Convert.ToInt32(dados["id_eleicoes"]);
                        obj.Descricao = dados["descricao"].ToString();
                        obj.Retorno = true;
                        return obj;
                    }
                }
                obj.Retorno = false;
                return obj;

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

        public static bool VerificarVoto(Eleitor_DTO obj)
        {
            try
            {
                string script = "SELECT id_eleitor, id_eleicao FROM Eleitor_Eleicao WHERE id_eleitor = @eleitor AND id_eleicao = @eleicao";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                cmd.Parameters.AddWithValue("@eleitor", obj.Id_Eleitor);
                cmd.Parameters.AddWithValue("@eleicao", obj.Id_Eleicao);
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
