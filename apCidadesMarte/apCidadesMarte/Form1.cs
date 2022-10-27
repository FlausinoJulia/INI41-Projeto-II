using System;
using System.IO;
using System.Windows.Forms;

namespace apCidadesMarte
{
    public partial class frmCidadesMarte : Form
    {
        string nomeDoArquivo;
        ArvoreDeBusca<Cidade> arvoreCidades;
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
                    MessageBox.Show("O arquivo indicado não existe!");
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
                }
                catch (Exception ex) // se o registro já existe na árvore
                {
                    MessageBox.Show("Essa cidade já está cadastrada!");
                }
            }            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // salvar a ultima alteração
            if (nomeDoArquivo != "" && nomeDoArquivo != null)
                arvoreCidades.GravarArquivoDeRegistros(nomeDoArquivo);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // gravar os dados da árvore no arquivo
            if (nomeDoArquivo != "" && nomeDoArquivo != null)
                arvoreCidades.GravarArquivoDeRegistros(nomeDoArquivo);
        }

        private void frmCidadesMarte_FormClosing(object sender, FormClosingEventArgs e)
        {
            // gravar os dados da árvore no arquivo
            if (nomeDoArquivo != "" && nomeDoArquivo != null)
                arvoreCidades.GravarArquivoDeRegistros(nomeDoArquivo);
        }
    }
}
