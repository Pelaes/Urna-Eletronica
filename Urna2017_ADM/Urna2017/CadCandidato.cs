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
    public partial class CadCandidato : Form
    {
        Candidato_DTO obj = new Candidato_DTO();

        public CadCandidato()
        {
            InitializeComponent();
            string data = CadCandidato_BLL.RetornaData();
            maskedTextBox3.Text = data;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                byte[] foto_to_byte = null;
                string CPF = maskedTextBox2.Text;
                maskedTextBox3.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (maskedTextBox3.Text == string.Empty)
                {
                    throw new Exception("Campo Data vazio!");
                }
                maskedTextBox3.TextMaskFormat = MaskFormat.IncludeLiterals;
                string data = maskedTextBox3.Text;
                string apelido = textBox4.Text;
                string chapa = textBox1.Text;
                Image img = pictureBox1.Image;
                if (img == null)
                {
                    throw new Exception("Preencher imagem");
                }
                MemoryStream foto = new MemoryStream();
                img.Save(foto, img.RawFormat);
                foto_to_byte = foto.ToArray();
                string msg = CadCandidato_BLL.ValidarCandidato(CPF, data, chapa, foto_to_byte, apelido);
                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CadCandidato.ActiveForm.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();
            if (foto.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = foto.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirm;
            confirm = MessageBox.Show("Deseja voltar à Home?", "Retornar Home", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm.ToString().ToLower() == "yes")
            {
                this.Hide();
                Home home = new Home();
                home.ShowDialog();
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string cpf = maskedTextBox2.Text;
                obj = CadCandidato_BLL.ValidaCPF(cpf);
                textBox3.Text = obj.Nome;
                textBox2.Text = obj.Turma;
                maskedTextBox1.Text = obj.Modulo;
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
