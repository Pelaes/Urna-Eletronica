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
    public class Conexao_DAL
    {
        public static SqlConnection Conexao()
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\Projects;Initial Catalog=URNA_BD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas na conexão!\n" + ex.Message);
            }
            
        }
        
    }
}
