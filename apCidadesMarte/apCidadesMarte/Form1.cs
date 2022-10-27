using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apCidadesMarte
{
    public partial class frmCidadesMarte : Form
    {
        ArvoreDeBusca<Cidade> arvoreCidades;
        ArvoreDeBusca<Caminho> arvoreCaminhos;
        BinaryWriter arquivo = new BinaryWriter(new MemoryStream());

        public frmCidadesMarte()
        {
            InitializeComponent();
        }

        private void frmCidadesMarte_Load(object sender, EventArgs e)
        {
            arvoreCidades = new ArvoreDeBusca<Cidade>();
                /*
                if (dlgAbrirCidades.ShowDialog() == DialogResult.OK)
                {
                    arvoreCidades = new ArvoreDeBusca<Cidade>();
                    // arvoreCidades.OndeExibir = pbArvore;
                    if (!File.Exists(dlgAbrirCidades.FileName))
                    {
                        var cidade = new Cidade();
                        var arquivoCriado = File.Create(dlgAbrirCidades.FileName);
                        arquivoCriado.Close();
                    }
                    arvoreCidades.LerArquivoDeRegistros(dlgAbrirCidades.FileName);
                    // pbArvore.Invalidate();  // disparar o evento Paint, que desenha a árvore
                }
                */
            }

        private void btnIncluirCidade_Click(object sender, EventArgs e)
        {
            try
            {
                ListaSimples<Caminho> caminhos = new ListaSimples<Caminho>();
                var cidade = new Cidade(txtNome.Text, udX.Value, udY.Value, caminhos);
                arvoreCidades.InserirBalanceado(cidade);
                pbArvore.Invalidate();
            }
            catch (Exception mens)
            {
                MessageBox.Show(mens.Message);
            }
        }

        private void btnExcluirCidade_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != null)
            {
                var cidade = new Cidade(txtNome.Text);
                if (arvoreCidades.ApagarNo(cidade))
                    pbArvore.Invalidate();
                else
                    MessageBox.Show("Matrícula não existente!");
            }
        }

        private void btnExcluirCaminho_Click(object sender, EventArgs e)
        {
            if (txtDestino.Text != null)
            {
                var caminho = new Caminho(txtOrigem.Text, txtDestino.Text);
                if (arvoreCaminhos.ApagarNo(caminho))
                    pbArvore.Invalidate();
                else
                    MessageBox.Show("Matrícula não existente!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitarCampos();
            AtualizarInfos();
        }

        

        public void DesabilitarCampos()
        {
            txtNome.ReadOnly = true;
            udX.Enabled = false;
            udY.Enabled = false;
        }

      

        private void AtualizarInfos()
        {
            if (arvoreCidades != null)
            {
                Cidade cidadeAtual = arvoreCidades.Atual.Info;
                txtNome.Text = cidadeAtual.Nome;
                udX.Value = cidadeAtual.X;
                udY.Value = cidadeAtual.Y;

                /*
                slMensagem.Text = "Registro " +
                                  (listaCidades.PosicaoAtual + 1) +
                                  "/" +
                                  listaCidades.Tamanho;

                lbListaCidades.SelectedIndex = listaCidades.PosicaoAtual;
                */
            }
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            if (arvoreCidades != null)
            {
                Graphics g = e.Graphics;
                arvoreCidades.DesenharArvore(true, arvoreCidades.Raiz, (int)pbArvore.Width / 2, 0,
                  Math.PI / 2, Math.PI / 2.5, 300, g);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            var nomeDoArquivo = dlgAbrirCidades.FileName;
            if (nomeDoArquivo != "" || nomeDoArquivo != " " || nomeDoArquivo != null)
                arvoreCidades.GravarArquivoDeRegistros(nomeDoArquivo);
            Close();
        }

        private void btnIncluirCaminho_Click(object sender, EventArgs e)
        {
            try
            {
                var caminho = new Caminho(txtOrigem.Text, txtDestino.Text);
                arvoreCaminhos.InserirBalanceado(caminho);
                pbArvore.Invalidate();
            }
            catch (Exception mens)
            {
                MessageBox.Show(mens.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            arvoreCidades.GravarArquivoDeRegistros(dlgAbrirCidades.FileName);
        }
    }
}
