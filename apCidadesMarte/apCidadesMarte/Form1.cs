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
    }
}
