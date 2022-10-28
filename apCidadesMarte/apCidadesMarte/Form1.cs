using System;
using System.Drawing;
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

                arvoreCidades.OndeExibir = pnlArvore;
                arvoreCidades.LerArquivoDeRegistros(nomeDoArquivo);
                pnlArvore.Invalidate();  // disparar o evento Paint, que desenha a árvore

                MessageBox.Show(arvoreCidades.QtosNos() + "");

                /* while (arvoreCidades.Atual.Info != null)
                     MessageBox.Show(arvoreCidades.Atual.Info);*/
            }
        }

        private void btnIncluirCidade_Click(object sender, EventArgs e)
        {
            if (arvoreCidades.SituacaoAtual != Situacao.incluindo)
            {
                arvoreCidades.SituacaoAtual = Situacao.incluindo;

                // habilitando os campos para que o user digite os dados da cidade
                txtNome.ReadOnly = false;
                txtNome.Enabled  = true;
                udX.ReadOnly     = false;
                udX.Enabled      = true;
                udY.ReadOnly     = false;
                udY.Enabled      = true;

                // setando os botões
                btnIncluirCidade.Enabled = true;
                btnCancelar.Enabled = true;
                btnExcluirCidade.Enabled = false;
                btnEditarCidade.Enabled = false;
                btnExibir.Enabled = false;
                btnSalvar.Enabled = false;

                sslMensagem.Text = "Digite os dados da cidade e clique em incluir.";
            }
            else
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
                        pnlArvore.Invalidate();
                    }
                    catch (Exception ex) // se o registro já existe na árvore
                    {
                        MessageBox.Show("Essa cidade já está cadastrada!");
                    }

                    // setamos tudo para a situacao navegando, deixando os campos desabilitados
                    // e habilitando os botões necessários do toolstrip
                    TelaDeNavegacaoCidades();
                }
            }
        }

        private void TelaDeNavegacaoCidades()
        {
            arvoreCidades.SituacaoAtual = Situacao.navegando;
            sslMensagem.Text = "Escolha a operação desejada.";

            btnCancelar.Enabled = false; // nenhuma operação está sendo feita, então não é necessário cancelar
            
            btnIncluirCidade.Enabled = true;
            btnExcluirCidade.Enabled = true;
            btnEditarCidade.Enabled = true;
            btnExibir.Enabled = true;
            btnSalvar.Enabled = true;
            btnSair.Enabled = true;

            // desabilitando os campos de digitação de dados
            txtNome.ReadOnly = true;
            txtNome.Enabled = false;
            udX.ReadOnly = true;
            udX.Enabled = false;
            udY.ReadOnly = true;
            udY.Enabled = false;
        }

        private void btnExcluirCidade_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != null)
            {
                var cidade = new Cidade(txtNome.Text);
                if (arvoreCidades.ApagarNo(cidade))
                    pnlArvore.Invalidate();
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
                    pnlArvore.Invalidate();
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

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIncluirCaminho_Click(object sender, EventArgs e)
        {
            if (txtOrigem.Text != "" && txtOrigem.Text != "" &&
                txtDistancia.Text != "" && txtTempo.Text != "" && txtCusto.Text != "")
            {
                try
                {
                    string origem, destino;
                    origem = txtOrigem.Text;
                    destino = txtDestino.Text;

                    Cidade cidadeOrigemProcurada = new Cidade(origem);
                    Cidade cidadeDestinoProcurada = new Cidade(destino);

                    if (arvoreCidades.ExisteRegistro(cidadeOrigemProcurada) && 
                        arvoreCidades.ExisteRegistro(cidadeDestinoProcurada))
                    {
                        int distancia, tempo, custo;
                        distancia = int.Parse(txtDistancia.Text);
                        tempo = int.Parse(txtTempo.Text);
                        custo = int.Parse(txtCusto.Text);

                        Caminho caminho = new Caminho(origem, destino, distancia, tempo, custo);
                        arvoreCaminhos.InserirBalanceado(caminho);
                    }
                }
                catch (Exception mens)
                {
                    MessageBox.Show("Esse caminho já está registrado!");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para incluir o caminho!");
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

        private void tpArvore_Enter(object sender, EventArgs e)
        {
            // toda vez que a tabPage de visualização da árvore de cidades for selecionada,
            // desenhamos a árvore atualizada
            pnlArvore.Invalidate();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            // se o usuário clicou em exibir pela primeira vez
            if (arvoreCidades.SituacaoAtual != Situacao.exibindo)
            {
                arvoreCidades.SituacaoAtual = Situacao.exibindo;

                // habilitando os campos para que o user digite o nome da cidade procurada
                txtNome.ReadOnly = false;
                txtNome.Enabled = true;

                // setando os botões
                btnIncluirCidade.Enabled = false;
                btnCancelar.Enabled = true;
                btnExcluirCidade.Enabled = false;
                btnEditarCidade.Enabled = false;
                btnExibir.Enabled = true;
                btnSalvar.Enabled = false;

                // pedimos para o usuário digitar o nome da cidade que ele quer consultar
                sslMensagem.Text = "Digite o nome da cidade desejada e clique em exibir novamente.";
                txtNome.ReadOnly = false; // habilitamos o txtNome
                txtNome.Focus();          // colocamos o foco no txtNome
            }
            else
            {
                if (txtNome.Text != "")
                {
                    string nome = txtNome.Text;
                    nome.TrimEnd().TrimStart();
                    Cidade cidadeAConsultar = new Cidade(nome);

                    if (arvoreCidades.ExisteRegistro(cidadeAConsultar))
                    {
                        udX.Value = arvoreCidades.Atual.Info.X;
                        udY.Value = arvoreCidades.Atual.Info.Y;
                    }

                    // desabilitamos o txtNome
                    txtNome.ReadOnly = true;

                    // destacar a cidade atual no mapa - pontinho e texto em vermelho

                    TelaDeNavegacaoCidades(); // volta tudo ao normal
                }
                else
                    MessageBox.Show("Digite o nome da cidade que deseja consultar!");
            }
        }

        private void pnlArvore_Paint(object sender, PaintEventArgs e)
        {
            if (arvoreCidades != null)
            {
                Graphics g = e.Graphics;
                arvoreCidades.DesenharArvore(true, arvoreCidades.Raiz, (int)pnlArvore.Width / 2, 0,
                  Math.PI / 2, Math.PI / 2.5, 300, g);
            }
        }
    }
}
