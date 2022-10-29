using System;
using System.Drawing;
using System.Windows.Forms;

namespace apCidadesMarte
{
    public partial class frmCidadesMarte : Form
    {
        ArvoreDeBusca<Cidade> arvoreCidades; // arvore de cidades
        ListaSimples<Caminho> listaCaminhos; // lista simples de caminhos

        string nomeDoArquivoDeCidades;  // nome do arquivo binario de cidades
        string nomeDoArquivoDeCaminhos; // nome do arquivo binario de caminhos

        public frmCidadesMarte()
        {
            InitializeComponent();
        }

        private void frmCidadesMarte_Load(object sender, EventArgs e)
        {
            if (dlgAbrirCidades.ShowDialog() == DialogResult.OK)
            {
                nomeDoArquivoDeCidades = dlgAbrirCidades.FileName;
                arvoreCidades = new ArvoreDeBusca<Cidade>();

                arvoreCidades.OndeExibir = pnlArvore;
                arvoreCidades.LerArquivoDeRegistros(nomeDoArquivoDeCidades);
                pnlArvore.Invalidate();  // disparar o evento Paint, que desenha a árvore

                MessageBox.Show(arvoreCidades.QtosNos() + "");

                /* while (arvoreCidades.Atual.Info != null)
                     MessageBox.Show(arvoreCidades.Atual.Info);*/

                TelaDeNavegacaoCidades();

                if (dlgAbrirCaminhos.ShowDialog() == DialogResult.OK)
                {
                    nomeDoArquivoDeCaminhos = dlgAbrirCaminhos.FileName;

                    listaCaminhos = new ListaSimples<Caminho>();

                    listaCaminhos.LerArquivoDeRegistros(nomeDoArquivoDeCidades);

                    MessageBox.Show(listaCaminhos.QuantosNos + "");
                }
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
                btnExibirCidade.Enabled = false;
                btnSalvar.Enabled = false;

                // limpando os campos para o usuário digitar os dados desejados
                txtNome.Text = "";
                udX.Value = 0;
                udY.Value = 0;

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
            btnExibirCidade.Enabled = true;
            btnSalvar.Enabled = true;
            btnSair.Enabled = true;

            // desabilitando os campos de digitação de dados
            DesabilitarCampos();
            AtualizarInfos(); 
        }

        private void btnExcluirCidade_Click(object sender, EventArgs e)
        {
            if (arvoreCidades.SituacaoAtual != Situacao.excluindo)
            {
                arvoreCidades.SituacaoAtual = Situacao.excluindo;

                // habilitando os campos para que o user digite o nome da cidade a ser excluida
                txtNome.ReadOnly = false;
                txtNome.Enabled = true;

                // setando os botões
                btnIncluirCidade.Enabled = false;
                btnCancelar.Enabled = true;
                btnExcluirCidade.Enabled = true;
                btnEditarCidade.Enabled = false;
                btnExibirCidade.Enabled = false;
                btnSalvar.Enabled = false;

                // pedimos para o usuário digitar o nome da cidade que ele quer excluir
                sslMensagem.Text = "Digite o nome da cidade que quer deletar e clique em excluir.";
                txtNome.Focus(); // colocamos o foco no txtNome
            }
            else
            {
                if (txtNome.Text != "")
                {
                    Cidade cidade = new Cidade(txtNome.Text);
                    if (arvoreCidades.ApagarNo(cidade))
                    {
                        pnlArvore.Invalidate();
                        TelaDeNavegacaoCidades(); // volta tudo ao normal
                    }
                    else
                        MessageBox.Show("Essa cidade não existe!");
                }
                else
                    MessageBox.Show("Digite o nome da cidade que quer excluir!");
            }
        }

        private void btnExcluirCaminho_Click(object sender, EventArgs e)
        {
            if (txtDestino.Text != null)
            {
                var caminho = new Caminho(txtOrigem.Text, txtDestino.Text);
                if (listaCaminhos.RemoverDado(caminho))
                    pnlArvore.Invalidate();
                else
                    MessageBox.Show("Matrícula não existente!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TelaDeNavegacaoCidades();
        }

        public void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            udX.Enabled = false;
            udY.Enabled = false;
            txtNome.ReadOnly = true;
            udX.ReadOnly = true;
            udY.ReadOnly = true;
        }

        private void AtualizarInfos()
        {
            if (arvoreCidades != null && arvoreCidades.Raiz != null) 
            {
                Cidade cidade = arvoreCidades.Raiz.Info;
                txtNome.Text = cidade.Nome;
                udX.Value = cidade.X;
                udY.Value = cidade.Y;
            }
            else // se a arvore estiver vazia ou nenhum arquivo tiver sido lido
            {
                txtNome.Text = "";
                udX.Value = 0;
                udY.Value = 0;
                
            }
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!listaCaminhos.EstaVazia)
            {
                if (txtOrigem.Text != "" && txtDestino.Text != "")
                {
                    Caminho caminhoProcurado = new Caminho(txtOrigem.Text, txtDestino.Text,
                        Convert.ToInt32(udDistancia.Value), Convert.ToInt32(udTempo.Value), Convert.ToInt32(udCusto.Value));

                    if (listaCaminhos.ExisteDado(caminhoProcurado))
                    {
                        Cidade cidadeOrigem = new Cidade(caminhoProcurado.CidOrigem);
                        arvoreCidades.ExisteRegistro(cidadeOrigem);

                        arvoreCidades.Atual.Info.caminhos.Atual.Info.Distancia = caminhoProcurado.Distancia;
                        arvoreCidades.Atual.Info.caminhos.Atual.Info.Tempo     = caminhoProcurado.Tempo;
                        arvoreCidades.Atual.Info.caminhos.Atual.Info.Custo     = caminhoProcurado.Custo;
                    }
                    else
                        MessageBox.Show("Esse caminho não existe!");
                }
                else
                    MessageBox.Show("Digite a origem e o destino para alterar caminho!");
            }
            else
                MessageBox.Show("Não há caminhos para alterar!");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DesativarNavegacaoCidades()
        {
            txtNome.Enabled = false;
            txtNome.ReadOnly = true;

            udX.Enabled = false;
            udX.ReadOnly = true;

            udY.Enabled = false;
            udY.ReadOnly = true;

            btnEditarCidade.Enabled  = false;
            btnIncluirCidade.Enabled = false;
            btnExcluirCidade.Enabled = false;
            btnExibirCidade.Enabled  = false;
            btnSalvar.Enabled        = false;
        }

        private void btnIncluirCaminho_Click(object sender, EventArgs e)
        {
            if (listaCaminhos.SituacaoAtual != Situacao.incluindo)
            {
                listaCaminhos.SituacaoAtual = Situacao.incluindo;

                // desativando as opções de alterações da arvore de cidades
                DesativarNavegacaoCidades();

                // habilitando os campos para que o user informe os dados do caminho
                txtOrigem.ReadOnly = false;
                txtOrigem.Enabled = true;
                txtDestino.ReadOnly = false;
                txtDestino.Enabled = true;
                udDistancia.Enabled = true;
                udDistancia.ReadOnly = false;
                udCusto.Enabled = true;
                udCusto.ReadOnly = false;
                udTempo.Enabled = true;
                udTempo.ReadOnly = false;

                // setando os botões
                btnIncluirCaminho.Enabled = true;
                btnExcluirCaminho.Enabled = false;
                btnAlterar.Enabled = false;

                // limpando os campos para o usuário digitar os dados desejados
                txtOrigem.Text  = "";
                txtDestino.Text = "";
                udCusto.Value = 0;
                udDistancia.Value = 0;
                udDistancia.Value = 0;

                sslMensagem.Text = "Digite os dados do caminho e clique em incluir.";
            }
            else
            {
                if (txtOrigem.Text != "" && txtOrigem.Text != "")
                {
                    try
                    {
                        string origem, destino;
                        origem = txtOrigem.Text;
                        destino = txtDestino.Text;

                        Cidade cidadeOrigemProcurada = new Cidade(origem);
                        Cidade cidadeDestinoProcurada = new Cidade(destino);

                        if (arvoreCidades.ExisteRegistro(cidadeDestinoProcurada) &&
                            arvoreCidades.ExisteRegistro(cidadeOrigemProcurada))
                        {
                            int distancia, tempo, custo;
                            distancia = Convert.ToInt32(udDistancia.Value);
                            tempo = Convert.ToInt32(udTempo.Value);
                            custo = Convert.ToInt32(udCusto.Value);

                            Caminho caminho = new Caminho(origem, destino, distancia, tempo, custo);
                            listaCaminhos.InserirEmOrdem(caminho);

                            arvoreCidades.Atual.Info.caminhos.InserirEmOrdem(caminho);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Esse caminho já está registrado!");
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos para incluir o caminho!");
                }
            }            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (nomeDoArquivoDeCidades != "" && nomeDoArquivoDeCidades != " " && nomeDoArquivoDeCidades != null)
            {
                arvoreCidades.GravarArquivoDeRegistros(nomeDoArquivoDeCidades);
                MessageBox.Show("As alterações foram salvas!");
            }
            else
                MessageBox.Show("Nenhum arquivo foi selecionado!");
            
        }

        private void frmCidadesMarte_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nomeDoArquivoDeCidades != "" && nomeDoArquivoDeCidades != " " && nomeDoArquivoDeCidades != null)
            {
                arvoreCidades.GravarArquivoDeRegistros(nomeDoArquivoDeCidades);
                if (nomeDoArquivoDeCaminhos != "" && nomeDoArquivoDeCaminhos != " " && nomeDoArquivoDeCaminhos != null)
                {
                    listaCaminhos.GravarArquivoDeRegistros(nomeDoArquivoDeCaminhos);
                }
            }
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
                btnExibirCidade.Enabled = true;
                btnSalvar.Enabled = false;

                // pedimos para o usuário digitar o nome da cidade que ele quer consultar
                sslMensagem.Text = "Digite o nome da cidade desejada e clique em exibir novamente.";
                txtNome.Focus();          // colocamos o foco no txtNome
            }
            else
            {
                if (txtNome.Text != "")
                {
                    string nome = txtNome.Text;
                    Cidade cidadeAConsultar = new Cidade(nome);

                    if (arvoreCidades.ExisteRegistro(cidadeAConsultar))
                    {
                        udX.Value = arvoreCidades.Atual.Info.X;
                        udY.Value = arvoreCidades.Atual.Info.Y;
                    }
                    else 
                    {
                        MessageBox.Show("Essa cidade não está registrada!");
                    }

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

        private void btnEditarCidade_Click(object sender, EventArgs e)
        {


        }
    }
}
