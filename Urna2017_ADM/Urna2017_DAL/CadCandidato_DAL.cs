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
    public class CadCandidato_DAL
    {
        public static string CadastrarCand (int id_Cand, int id_Eleicao, string chapa, byte[] foto, string apelido)
        {
            try
            {
                string script = "INSERT INTO Candidato_Eleicao (id_eleicao, id_candidato, chapa, foto, Apelido) VALUES (@ID_E, @ID_C, @Chapa, @Foto, @Apelido)";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                cmd.Parameters.AddWithValue("@ID_E", id_Eleicao);
                cmd.Parameters.AddWithValue("@ID_C", id_Cand);
                cmd.Parameters.AddWithValue("@Chapa", chapa);
                cmd.Parameters.AddWithValue("@Foto", foto);
                cmd.Parameters.AddWithValue("@Apelido", apelido);
                cmd.ExecuteNonQuery();
                string msg = "Candidato cadastrado com sucesso!";
                return msg;
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

        public static Candidato_DTO BuscarCPF(string CPF)
        {
            Candidato_DTO obj = new Candidato_DTO();
            try
            {
                string script = "SELECT id_eleitores, nome, turma_cargo, modulo FROM Eleitor WHERE cpf = @CPF";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                cmd.Parameters.AddWithValue("@CPF", CPF);
                SqlDataReader dados = cmd.ExecuteReader();
                while (dados.Read())
                {
                    obj.IdCandidato = Convert.ToInt32(dados["id_eleitores"]);
                    obj.Nome = dados["nome"].ToString();
                    obj.Turma = dados["turma_cargo"].ToString();
                    obj.Modulo = dados["modulo"].ToString();
                }
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

        public static string RetornaData(out int ID)
        {
            try
            {
                string script = "SELECT id_eleicoes, data_eleicao FROM Eleicao WHERE ativa = 'Ativa'";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                SqlDataReader dados = cmd.ExecuteReader();
                string data = null;
                ID = 0;
                while (dados.Read())
                {
                    ID = Convert.ToInt32(dados["id_eleicoes"]);
                    data = dados["data_eleicao"].ToString();
                }
                return data;
               
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
