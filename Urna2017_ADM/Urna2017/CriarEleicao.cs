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
    public partial class CriarEleicao : Form
    {
        public CriarEleicao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mTxtBox.Clear();
            textBox1.Clear();
            mTxtBox.Focus();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            try
            {
                Eleicao_DTO obj = new Eleicao_DTO();
                mTxtBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (mTxtBox.Text == string.Empty)
                {
                    throw new Exception("Campo Data vazio!");
                }
                mTxtBox.TextMaskFormat = MaskFormat.IncludeLiterals;
                obj.DataEleicao = mTxtBox.Text;
                obj.Nome = textBox1.Text;
                string msg = CadEleicao_BLL.ValidarEleicao(obj);
                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mTxtBox.Clear();
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
