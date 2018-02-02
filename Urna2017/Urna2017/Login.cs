using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Urna2017_BLL;
using Urna2017_DTO;

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
            Eleitor_DTO obj = new Eleitor_DTO();
            string cpf = maskedTextBox1.Text;
            bool voto;
            
            try
            {
                obj = Login_BLL.ValidarEleitor(cpf);
                voto = Login_BLL.VerificarVoto(obj);
                if (voto == true)
                {
                    MessageBox.Show("Eleitor já votou!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (obj.Retorno == true)
                    {
                        this.Hide();
                        Eleicao eleicao = new Eleicao(obj);
                        eleicao.ShowDialog();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Eleitor não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }
    }
}
