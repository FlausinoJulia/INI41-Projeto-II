using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace apCidadesMarte
{
    public partial class frmCidadesMarte : Form
    {
        // arvores de caminho de de cidades
        ArvoreDeBusca<Cidade>  arvoreCidades;
        ArvoreDeBusca<Caminho> arvoreCaminhos;
        // variáveis relacionadas aos arquivos binários
        string nomeDoArquivo;
        BinaryWriter arquivo = new BinaryWriter(new MemoryStream());

        public frmCidadesMarte()
        {
            InitializeComponent();
        }

        private void frmCidadesMarte_Load(object sender, EventArgs e)
        {
            if (dlgAbrirCidades.ShowDialog() == DialogResult.OK)
            {
                nomeDoArquivo = dlgAbrirCidades.FileName;
                arvoreCidades = new ArvoreDeBusca<Cidade>();
                // arvoreCidades.OndeExibir = pbArvore;
                if (File.Exists(nomeDoArquivo))
                {
                    arvoreCidades.LerArquivoDeRegistros(nomeDoArquivo);
                }
                else
                    MessageBox.Show("O arquivo indicado não existe!"); // arrumar isso aqui
                // pbArvore.Invalidate();  // disparar o evento Paint, que desenha a árvore

                MessageBox.Show(arvoreCidades.QtosNos() + "");

                /* while (arvoreCidades.Atual.Info != null)
                     MessageBox.Show(arvoreCidades.Atual.Info);*/
            }
        }

        private void btnIncluirCidade_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
                MessageBox.Show("Preencha todos os campos para incluir a cidade!");
            else
            {
                string nome = txtNome.Text;
                decimal x = udX.Value, y = udY.Value;

                // verificar se existe uma cidade naquela coordenada,
                // porque não pode ter duas cidades diferentes na mesma coordenada
                // if (arvoreCidades.)

                ListaSimples<Caminho> caminhos = new ListaSimples<Caminho>();
                Cidade cidadeNova = new Cidade(nome, x, y, caminhos);

                try
                {
                    arvoreCidades.InserirBalanceado(cidadeNova);
                    pbArvore.Invalidate();
                }
                catch (Exception ex) // se o registro já existe na árvore
                {
                    MessageBox.Show("Essa cidade já está cadastrada!");
                }
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
            if (nomeDoArquivo != "" && nomeDoArquivo != " " && nomeDoArquivo != null)
                arvoreCidades.GravarArquivoDeRegistros(nomeDoArquivo);
        }

        private void frmCidadesMarte_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nomeDoArquivo != "" || nomeDoArquivo != " " || nomeDoArquivo != null)
                arvoreCidades.GravarArquivoDeRegistros(nomeDoArquivo);
        }
    }
}
