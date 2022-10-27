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
            if (dlgAbrirCidades.ShowDialog() == DialogResult.OK)
            {
                if (txtNome.Text == "")
                    MessageBox.Show("Preencha todos os campos para incluir a cidade!");
                else
                {
                    string nome = txtNome.Text;
                    decimal x = udX.Value, y = udY.Value;
                    ListaSimples<Caminho> caminhos = new ListaSimples<Caminho>();
                    Cidade cidadeNova = new Cidade(nome, x, y, caminhos);

                    arvoreCidades.IncluirNovoRegistro(cidadeNova);
                }
                arvoreCidades.GravarArquivoDeRegistros(dlgAbrirCidades.FileName);
            }
            
        }

        private void btnExcluirCidade_Click(object sender, EventArgs e)
        {
            if (dlgAbrirCidades.ShowDialog() == DialogResult.OK)
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Digite o nome da cidade que deseja excluir!");
                    txtNome.Focus();
                }
                 
                else
                {
                    string nomeCidade = txtNome.Text;
                    Cidade cidade = new Cidade();
                    cidade.Nome = nomeCidade;

                    if (!arvoreCidades.Existe(cidade))
                    {
                        MessageBox.Show("Essa cidade não existe!");
                    }
                    else
                    {
                        Cidade cidadeAExcluir = arvoreCidades.Atual.Info;
                        arvoreCidades.ApagarNo(arvoreCidades.Atual.Info); // ApagarNo ou Excluir???

                        DesabilitarCampos();
                        AtualizarTela();
                        AtualizarInfos();

                        btnSalvar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnExcluirCidade.Enabled = true;
                    }

                }
            }
        }

        private void btnExcluirCaminho_Click(object sender, EventArgs e)
        {
            if (txtDestino.Text == "")
            {
                MessageBox.Show("Digite o caminho que deseja excluir!");
                txtDestino.Focus();
            }

            else
            {
                string nomeCaminho = txtDestino.Text;
                Caminho caminho = new Caminho();
                caminho.CidDestino = nomeCaminho;

                if (!arvoreCaminhos.Existe(caminho))
                {
                    MessageBox.Show("Esse caminho não existe!");
                }
                else
                {
                    Caminho caminhoAExcluir = arvoreCaminhos.Atual.Info;
                    arvoreCaminhos.ApagarNo(arvoreCaminhos.Atual.Info);

                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnExcluirCidade.Enabled = true;
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void AtualizarTela()
        {
            if (arvoreCidades != null)
            {
                // MostrarCidadesNoMapa();
                // arvoreCidades.ExibirDados(arvoreCidades);
                // AtualizarInfos();
            }
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
            int posicaoDado = arvoreCidades.;

            /*
            int posicaoDado = listaCidades.PosicaoAtual;
            listaCidades.PosicionarNoPrimeiro();
            Font fonte = new Font("Arial", 10);

            while (listaCidades.DadoAtual() != null)
            {
                Cidade cidade = listaCidades.DadoAtual();

                int x = (int)(cidade.X * pbMapa.Width);
                int y = (int)(cidade.Y * pbMapa.Height);

                e.Graphics.DrawEllipse(Pens.Black, new Rectangle(x, y, 6, 6));
                e.Graphics.FillEllipse(Brushes.Black, new Rectangle(x, y, 6, 6));
                e.Graphics.DrawString(cidade.Nome, fonte, Brushes.Black, x - 20, y + 10);

                listaCidades.AvancarPosicao();
            }

            listaCidades.PosicionarEm(posicaoDado);
            */
        }
    }
}
