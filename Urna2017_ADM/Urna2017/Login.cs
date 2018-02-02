using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Urna2017_DTO;
using Urna2017_BLL;

namespace Urna2017
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();      
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Login_DTO obj = new Login_DTO();
            bool login;
            try
            {
                obj.Usuario = textBox1.Text;
                obj.Senha = textBox2.Text;
                login = Login_BLL.ValidarLogin(obj);
                if(login == true)
                {
                    this.Hide();
                    Home inicio = new Home();
                    inicio.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha Inválidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
            

        }
    }
}
