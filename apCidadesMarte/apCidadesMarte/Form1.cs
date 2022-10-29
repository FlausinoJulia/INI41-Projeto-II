using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace apCidadesMarte
{
    public partial class frmCidadesMarte : Form
    {
        ArvoreDeBusca<Cidade> arvoreCidades; // arvore de cidades

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
                
                arvoreCidades.LerArquivoDeRegistros(nomeDoArquivoDeCidades);

                arvoreCidades.OndeExibir = pnlArvore;
                pnlArvore.Invalidate();  // disparar o evento Paint, que desenha a árvore

                MessageBox.Show(arvoreCidades.QtosNos() + "");

                TelaDeNavegacaoCidades();

                if (dlgAbrirCaminhos.ShowDialog() == DialogResult.OK)
                {
                    nomeDoArquivoDeCaminhos = dlgAbrirCaminhos.FileName;

                    Caminho caminhoLido = new Caminho();
                    FileStream origem = new FileStream(nomeDoArquivoDeCaminhos, FileMode.OpenOrCreate);
                    BinaryReader arquivo = new BinaryReader(origem);

                    for (int i = 0; i < arquivo.BaseStream.Length / caminhoLido.TamanhoRegistro; i++)
                    {
                        caminhoLido = new Caminho();
                        caminhoLido.LerRegistro(arquivo, i);

                        Cidade cidadeDeOrigem = new Cidade(caminhoLido.CidOrigem);
                        if (arvoreCidades.ExisteRegistro(cidadeDeOrigem))
                        {
                            arvoreCidades.Atual.Info.caminhos.InserirEmOrdem(caminhoLido);
                        }
                    }

                    origem.Close();
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
                txtNome.Enabled = true;
                udX.ReadOnly = false;
                udX.Enabled = true;
                udY.ReadOnly = false;
                udY.Enabled = true;

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
            txtNome.Enabled = false;
            udX.Enabled = false;
            udY.Enabled = false;
            txtNome.ReadOnly = true;
            udX.ReadOnly = false;
            udY.ReadOnly = false;

            txtNome.Text = "";
            udX.Value = 0;
            udY.Value = 0;
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
            if (arvoreCidades != null && arvoreCidades.Raiz != null)
            {
                if (txtDestino.Text != "" && txtOrigem.Text != "")
                {

                    string origem = txtOrigem.Text, destino = txtDestino.Text;
                    Caminho caminho = new Caminho(origem, destino);
                    Cidade cidOrigem = new Cidade(origem);

                    if (arvoreCidades.ExisteRegistro(cidOrigem) &&
                        arvoreCidades.Atual.Info.caminhos.RemoverDado(caminho))
                        MessageBox.Show("O caminho de " + origem + " a " + destino + " foi excluido!");
                    else
                        MessageBox.Show("Esse caminho não existe!");
                }
                else
                    MessageBox.Show("Digite a cidade de origem e de destino para excluir o caminho!");
            }
            else
                MessageBox.Show("Não é possível incluir um caminho! Não há nenhuma cidade registrada.");

            // volta tudo ao normal
            LimparCamposCaminhos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TelaDeNavegacaoCidades();
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            listaCidades.PosicionarNoPrimeiro();

            Font fonte = new Font("Arial", 11);

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
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (arvoreCidades != null)
            {
                if (txtOrigem.Text != "" && txtDestino.Text != "")
                {
                    Caminho caminhoProcurado = new Caminho(txtOrigem.Text, txtDestino.Text,
                        Convert.ToInt32(udDistancia.Value), Convert.ToInt32(udTempo.Value), Convert.ToInt32(udCusto.Value));

                    Cidade cidadeOrigem = new Cidade(caminhoProcurado.CidOrigem);
                    if (arvoreCidades.ExisteRegistro(cidadeOrigem) &&
                        arvoreCidades.Atual.Info.caminhos.ExisteDado(caminhoProcurado))
                    {
                        arvoreCidades.Atual.Info.caminhos.Atual.Info.Distancia = caminhoProcurado.Distancia;
                        arvoreCidades.Atual.Info.caminhos.Atual.Info.Tempo = caminhoProcurado.Tempo;
                        arvoreCidades.Atual.Info.caminhos.Atual.Info.Custo = caminhoProcurado.Custo;

                        MessageBox.Show("O caminho de " + cidadeOrigem.Nome.TrimEnd() + " a " + arvoreCidades.Atual.Info.caminhos.Atual.Info.CidDestino.TrimEnd() + " foi alterado!");
                    }
                    else
                        MessageBox.Show("Esse caminho não existe!");
                }
                else
                    MessageBox.Show("Digite a origem e o destino para alterar caminho!");
            }
            else
                MessageBox.Show("Não é possível incluir um caminho! Não há nenhuma cidade registrada.");

            // volta tudo ao normal
            LimparCamposCaminhos();
        }

        private void LimparCamposCaminhos()
        {
            txtDestino.Text = "";
            txtOrigem.Text = "";
            udCusto.Value = 0;
            udTempo.Value = 0;
            udDistancia.Value = 0;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIncluirCaminho_Click(object sender, EventArgs e)
        {
            if (arvoreCidades != null)
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
                            arvoreCidades.Atual.Info.caminhos.InserirEmOrdem(caminho);

                            MessageBox.Show("O caminho de " + origem + " a " + destino + " foi incluído!");
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
            else
                MessageBox.Show("Não é possível incluir um caminho! Não há nenhuma cidade registrada.");

            LimparCamposCaminhos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (nomeDoArquivoDeCidades != "" && nomeDoArquivoDeCidades != " " && nomeDoArquivoDeCidades != null)
            {
                arvoreCidades.GravarArquivoDeRegistros(nomeDoArquivoDeCidades);
                MessageBox.Show("As alterações no arquivo de cidades foram salvas!");

                if (nomeDoArquivoDeCaminhos != "" && nomeDoArquivoDeCaminhos != " " && nomeDoArquivoDeCaminhos != null)
                {
                    MessageBox.Show("As alterações no arquivo de caminhos foram salvas!");
                }
                else
                    MessageBox.Show("Nenhum arquivo de caminhos foi selecionado!");
            }
            else
                MessageBox.Show("Nenhum arquivo de cidades foi selecionado!");
            
        }

        private void frmCidadesMarte_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nomeDoArquivoDeCidades != "" && nomeDoArquivoDeCidades != " " && nomeDoArquivoDeCidades != null)
            {
                arvoreCidades.GravarArquivoDeRegistros(nomeDoArquivoDeCidades);
                if (nomeDoArquivoDeCaminhos != "" && nomeDoArquivoDeCaminhos != " " && nomeDoArquivoDeCaminhos != null)
                {
                    FileStream destino = new FileStream(nomeDoArquivoDeCaminhos, FileMode.Create);
                    BinaryWriter arquivo = new BinaryWriter(destino);

                    List<NoArvore<Cidade>> listaCidades = new List<NoArvore<Cidade>>();
                    Queue<NoArvore<Cidade>> filaCidades = new Queue<NoArvore<Cidade>>();
                    NoArvore <Cidade> no = arvoreCidades.Raiz;
                    while (no != null)
                    {
                        if (no.Esq != null)
                            filaCidades.Enqueue(no.Esq);
                        if (no.Dir != null)
                            filaCidades.Enqueue(no.Dir);
                        listaCidades.Add(no);
                        if (filaCidades.Count == 0)
                            no = null;
                        else
                            no = filaCidades.Dequeue();
                    }

                    foreach (NoArvore<Cidade> cidade in listaCidades)
                    {
                        ListaSimples<Caminho> caminhos = cidade.Info.caminhos;

                        caminhos.IniciarPercursoSequencial();
                        while(caminhos.PodePercorrer())
                        {
                            caminhos.Atual.Info.GravarRegistro(arquivo);
                        }
                    }

                    arquivo.Close();
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
                DesativarNavegacaoCaminhos();
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
                txtNome.Focus();  // colocamos o foco no txtNome
            }
            else
            {
                if (arvoreCidades.Raiz != null) // se a arvore nao está vazia
                {
                    if (txtNome.Text != "")
                    {
                        string nome = txtNome.Text;
                        Cidade cidadeAConsultar = new Cidade(nome);

                        if (arvoreCidades.ExisteRegistro(cidadeAConsultar))
                        {
                            txtNome.Text = arvoreCidades.Atual.Info.Nome;
                            udX.Value = arvoreCidades.Atual.Info.X;
                            udY.Value = arvoreCidades.Atual.Info.Y;
                        }
                        else
                        {
                            MessageBox.Show("Essa cidade não está registrada!");
                        }

                        // destacar a cidade atual no mapa - pontinho e texto em vermelho

                        // volta tudo ao normal
                        TelaDeNavegacaoCidades();
                    }
                    else
                        MessageBox.Show("Digite o nome da cidade que deseja consultar!");
                }
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
  
        private void DesativarNavegacaoCaminhos()
        {
            txtOrigem.Enabled = false;
            txtOrigem.ReadOnly = true;
            txtDestino.Enabled = false;
            txtDestino.ReadOnly = true;
            udCusto.Enabled = false;
            udCusto.ReadOnly = true;
            udDistancia.Enabled = false;
            udDistancia.ReadOnly = true;
            udTempo.Enabled = false;
            udTempo.ReadOnly = true;

            btnAlterar.Enabled = false;
            btnExcluirCaminho.Enabled = false;
            btnIncluirCaminho.Enabled = false;
        }

        private void btnEditarCidade_Click(object sender, EventArgs e)
        {
            // se o usuário clicou em editar pela primeira vez
            if (arvoreCidades.SituacaoAtual != Situacao.editando)
            {
                arvoreCidades.SituacaoAtual = Situacao.editando;

                DesativarNavegacaoCaminhos();

                // habilitamos o txtNome para o usuario informar a cidade que deseja editar
                txtNome.ReadOnly = false;
                txtNome.Enabled = true;
                udX.Enabled = true;
                udY.Enabled = true;
                udX.ReadOnly = false;
                udY.ReadOnly = false;

                // setando os botões
                btnIncluirCidade.Enabled = false;
                btnCancelar.Enabled = true;
                btnExcluirCidade.Enabled = false;
                btnEditarCidade.Enabled = true;
                btnExibirCidade.Enabled = false;
                btnSalvar.Enabled = false;

                // pedimos para o usuário digitar os dados novos
                sslMensagem.Text = "Digite o nome da cidade que quer alterar e seus novos dados, depois clique em editar.";
            }
            else
            {
                if (txtNome.Text != "")
                {
                    string nome = txtNome.Text;
                    Cidade cidadeAEditar = new Cidade(nome);

                    if (arvoreCidades.ExisteRegistro(cidadeAEditar))
                    {
                        decimal x = udX.Value, y = udY.Value;

                        arvoreCidades.Atual.Info.X = x;
                        arvoreCidades.Atual.Info.Y = y;     
                    }
                    else
                    {
                        MessageBox.Show("Essa cidade não está registrada!");
                    }

                    // volta tudo ao normal
                    TelaDeNavegacaoCidades(); 
                }
                else
                    MessageBox.Show("Digite o nome da cidade que deseja alterar!");
            }
        }
    }
}
