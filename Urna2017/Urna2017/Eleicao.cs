using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Urna2017_DTO;
using Urna2017_BLL;

namespace Urna2017
{
    public partial class Eleicao : Form
    {
        //Variaveis Globais
        int chapa;
        int Eleitor, Eleicao1;
        

        public Eleicao(Eleitor_DTO obj)
        {
            InitializeComponent();
            label2.Text = obj.Nome;
            label4.Text = obj.CPF;
            label5.Text = obj.Turma;
            Eleitor = obj.Id_Eleitor;
            Eleicao1 = obj.Id_Eleicao;
            ptbFoto.Image = Properties.Resources.administrator;
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Length == 0)
            {
                txtNumero1.Text = "1";
                txtNumero2.Focus();
            }
            else
            {
                txtNumero2.Text = "1";
                chapa = Convert.ToInt32(txtNumero1.Text + txtNumero2.Text);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Length == 0)
            {
                txtNumero1.Text = "2";
                txtNumero2.Focus();
            }
            else
            {
                txtNumero2.Text = "2";
                chapa = Convert.ToInt32(txtNumero1.Text + txtNumero2.Text);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Length == 0)
            {
                txtNumero1.Text = "3";
                txtNumero2.Focus();
            }
            else
            {
                txtNumero2.Text = "3";
                chapa = Convert.ToInt32(txtNumero1.Text + txtNumero2.Text);
                MessageBox.Show("chapa: " + chapa);
                Candidato_DTO obj = new Candidato_DTO();
                Image img;
                obj = ValidarVoto_BLL.AtribuirImagem(chapa);
                txtCandidato.Text = obj.Apelido;
                MessageBox.Show("chapa: " + obj.Foto);
                MemoryStream mStream = new MemoryStream(obj.Foto);
                img = Image.FromStream(mStream);
                //ptbFoto.Image = Image.img;
            }
        }
           
        

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Length == 0)
            {
                txtNumero1.Text = "4";
                txtNumero2.Focus();
            }
            else
            {
                txtNumero2.Text = "4";
                chapa = Convert.ToInt32(txtNumero1.Text + txtNumero2.Text);
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Length == 0)
            {
                txtNumero1.Text = "5";
                txtNumero2.Focus();
            }
            else
            {
                txtNumero2.Text = "5";
                chapa = Convert.ToInt32(txtNumero1.Text + txtNumero2.Text);
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Length == 0)
            {
                txtNumero1.Text = "6";
                txtNumero2.Focus();
            }
            else
            {
                txtNumero2.Text = "6";
                chapa = Convert.ToInt32(txtNumero1.Text + txtNumero2.Text);
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Length == 0)
            {
                txtNumero1.Text = "7";
                txtNumero2.Focus();
            }
            else
            {
                txtNumero2.Text = "7";
                chapa = Convert.ToInt32(txtNumero1.Text + txtNumero2.Text);
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Length == 0)
            {
                txtNumero1.Text = "8";
                txtNumero2.Focus();
            }
            else
            {
                txtNumero2.Text = "8";
                chapa = Convert.ToInt32(txtNumero1.Text + txtNumero2.Text);
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Length == 0)
            {
                txtNumero1.Text = "9";
                txtNumero2.Focus();
            }
            else
            {
                txtNumero2.Text = "9";
                
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Length == 0)
            {
                txtNumero1.Text = "0";
                txtNumero2.Focus();
            }
            else
            {
                txtNumero2.Text = "0";
                chapa = Convert.ToInt32(txtNumero1.Text + txtNumero2.Text);
            }
        }

        private void btnCorrigir_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            txtCandidato.Clear();
            txtNumero1.Focus();
            ptbFoto.Image = Properties.Resources.administrator;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            string msg;
            try
            {
                if (txtNumero1.Text == "" || txtNumero2.Text == "")
                {
                    throw new Exception("Preencha o número do candidato!");
                }

                DialogResult confirm;
                confirm = MessageBox.Show("Confirmar voto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm.ToString().ToLower() == "yes")
                {
                    msg = ValidarVoto_BLL.ConfirmarVoto(chapa, Eleicao1, Eleitor);
                    //System.Media.SoundPlayer confirmação = new System.Media.SoundPlayer();
                    //confirmação.Play();
                    MessageBox.Show(msg, "Obrigado pela participação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Login inicio = new Login();
                    inicio.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
        }

        public void AtribuirImagem()
        {
            Candidato_DTO obj = new Candidato_DTO();
            Image img;
            obj = ValidarVoto_BLL.AtribuirImagem(chapa);
            txtCandidato.Text = obj.Apelido;
            MessageBox.Show(obj.Apelido);
            MemoryStream mStream = new MemoryStream(obj.Foto);
            img = Image.FromStream(mStream);
            ptbFoto.Image = img;
            
            
            
        }
    }
}
