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
    public class ValidarVoto_DAL
    {
        public static string ValidarVoto(int chapa, int eleicao, int eleitor)
        {
            try
            {
                string script = "INSERT INTO Eleitor_Eleicao (id_eleicao, id_eleitor, votou, escolha) VALUES (@ID_Eleicao, @ID_Eleitor, 1, @Chapa)";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                cmd.Parameters.AddWithValue("@ID_Eleitor", eleitor);
                cmd.Parameters.AddWithValue("@ID_Eleicao", eleicao);
                cmd.Parameters.AddWithValue("@Chapa", chapa);
             
                cmd.ExecuteNonQuery();
                return "Voto efetuado com sucesso!";
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

        public static Candidato_DTO AtribuirImagem(int chapa)
        {
            try
            {
                Candidato_DTO obj = new Candidato_DTO();
                string script = "SELECT foto, Apelido FROM Candidato_Eleicao WHERE chapa = @Chapa";
                SqlCommand cmd = new SqlCommand(script, Conexao_DAL.Conexao());
                cmd.Parameters.AddWithValue("@Chapa", chapa);
                SqlDataReader dados = cmd.ExecuteReader();
                while (dados.Read())
                {
                    if (dados.HasRows)
                    {                       
                        obj.Foto = (Byte[])(dados["foto"]);
                        obj.Apelido = dados["Apelido"].ToString();
                    }                    
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
    }
}
