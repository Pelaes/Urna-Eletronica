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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            List<Eleicao_DTO> data;
            data = ControleEleicoes_BLL.RetEleicoes();
            int aux = data.Count;
            for (int cont = 0; cont < aux; cont++)
            {
               dataGridView1.Rows.Add(data[cont].DataEleicao.ToString(), data[cont].Nome.ToString(), data[cont].Status.ToString());
            }

            bool flag = ControleEleicoes_BLL.VerificaAtiva();

            if (flag == true)
            {
                button2.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = false;
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadCandidato candidato = new CadCandidato();
            candidato.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadEleitor eleitor = new CadEleitor();
            eleitor.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CriarEleicao eleicao = new CriarEleicao();
            eleicao.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = dataGridView1.RowCount;
                int indice = dataGridView1.SelectedRows[0].Index;
                string data = dataGridView1.Rows[indice].Cells[0].Value.ToString();
                bool flag = ControleEleicoes_BLL.IniciarEleicao(data);
                if (flag == true)
                {
                    MessageBox.Show("Eleição iniciada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Home.ActiveForm.Refresh();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Por favor, selecione uma eleição disponivel", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
    }
}
