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
    public partial class CadEleitor : Form
    {
        public CadEleitor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Eleitor_DTO obj = new Eleitor_DTO();
            try
            {
                obj.CPF = maskedTextBox2.Text;
                obj.Nome = textBox3.Text;
                obj.Curso = comboBox1.Text;
                obj.Modulo = maskedTextBox1.Text;
                string msg = CadEleitor_BLL.ValidarEleitor(obj);
                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskedTextBox2.Clear();
                textBox3.Clear();
                comboBox1.SelectedIndex = -1;
                maskedTextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            maskedTextBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            maskedTextBox1.Clear();
            maskedTextBox2.Focus();
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
    }
}
