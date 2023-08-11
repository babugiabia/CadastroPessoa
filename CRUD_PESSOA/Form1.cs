using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Aula_04_agosto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pessoa pes = new Pessoa ();
            List<Pessoa> pessoas = pes.listapessoa();
            dgvPessoa.DataSource = pessoas;
            btEditar.Enabled = false;
            btEditar.Enabled = false;   
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            Pessoa pes = new Pessoa(); //Instanciar a classe para chama-la
            if (pes.RegistroRepetido(txtNome.Text,txtCelular.Text)==true)
            {
                MessageBox.Show("Pessoa já existe em nossa base de dados!");
                txtNome.Text = "";
                txtCelular.Text = "";
            }
            else
            {
                pes.Inserir(txtNome.Text, txtCelular.Text);
                MessageBox.Show("Pessoa cadastrada com sucesso!");
                List<Pessoa> pessoas = pes.listapessoa();
                dgvPessoa.DataSource= pessoas;
                txtNome.Text = "";
                txtCelular.Text = "";
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            if (txtNome.Text != null)
            {
                btEditar.Enabled = true;
                btExcluir.Enabled = true;
            }
            Pessoa pes = new Pessoa();
            pes.Localiza(id);
            txtNome.Text = pes.nome;
            txtCelular.Text = pes.celular;
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((string)txtId.Text.Trim());
            Pessoa pes = new Pessoa();
            pes.Atualizar(id, txtNome.Text, txtCelular.Text);
            MessageBox.Show("Pessoa atualizada com sucesso!");
            List<Pessoa> pessoas = pes.listapessoa();
            dgvPessoa.DataSource = pessoas;
            txtNome.Text = "";
            txtCelular.Text = "";
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((string)txtId.Text.Trim());
            Pessoa pes = new Pessoa();
            pes.Excluir(id);
            MessageBox.Show("Pessoa excluída com sucesso!");
            List<Pessoa> pessoas = pes.listapessoa();
            dgvPessoa.DataSource = pessoas;
            txtNome.Text = "";
            txtCelular.Text = "";
        }

        private void dgvPessoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                DataGridViewRow row = this.dgvPessoa.Rows[e.RowIndex];
                this.dgvPessoa.Rows[e.RowIndex].Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();   
                txtCelular.Text = row.Cells[2].Value.ToString();
            }
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
        }
    }
}
