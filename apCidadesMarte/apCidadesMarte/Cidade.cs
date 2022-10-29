using System;
using System.IO;
using System.Windows.Forms;

namespace apCidadesMarte
{
    public class Cidade : IComparable<Cidade>, IRegistro, IRegistroNoDeArvore
    {
        private const byte tamanhoNome = 15;
        private string nome;
        private decimal x, y;
        public ListaSimples<Caminho> caminhos;

        const int tamanhoRegistro = tamanhoNome + // tamanho do nome
                                    sizeof(decimal) + // tamanho da coordenada x
                                    sizeof(decimal);  // tamanho da coordenada y

        public Cidade() // construtor default (sem parametros)
        {
            this.Nome = "";
            this.X = 0;
            this.Y = 0;
            this.caminhos = new ListaSimples<Caminho>();
        }
        public Cidade(string nome, decimal x, decimal y, ListaSimples<Caminho> caminhos) // construtor parametrizado
        {
            this.Nome = nome;
            this.X = x;
            this.Y = y;
            this.caminhos = caminhos;
        }

        public Cidade(string nome) // construtor que recebe só a chave (nome) como parâmetro
        {
            this.Nome = nome;
        }

        public int TamanhoRegistro => tamanhoRegistro;
        public string Nome
        {
            get => nome;
            // o nome deve ter exatamente 15 caracteres, portanto,
            // se o value possuir MENOS que 15 caracteres, completamos o nome com espaços em branco
            // se o value possuir MAIS  que 15 caracteres, nome recebe os 15 primeiros chars de value
            set => nome = value.PadRight(tamanhoNome, ' ').Substring(0, tamanhoNome);
        }
        public decimal X { get => x; set => x = value; }
        public decimal Y { get => y; set => y = value; }

        public int CompareTo(Cidade outraCidade)
        {
            return nome.CompareTo(outraCidade.Nome);
        }

        public string ParaExibirNaArvore()
        {
            return Nome + "\n" + caminhos.QuantosNos.ToString();
        }

        public override string ToString()
        {
            return Nome;
        }

        public void GravarRegistro(BinaryWriter arquivo)
        {
            if (arquivo != null)
            {
                char[] umNome = new char[tamanhoNome];  // cria vetor de char para armazenar o nome
                for (int i = 0; i < tamanhoNome; i++)
                    umNome[i] = nome[i];                // copia os caracteres do campo nome para o vetor de char
                arquivo.Write(umNome);                  // grava o vetor de char no arquivo (com tamanho 15)

                arquivo.Write(X);                       // escreve os bytes da coordenada X no arquivo 
                arquivo.Write(Y);                       // escreve os bytes da coordenada Y no arquivo 
            }
        }

        public void LerRegistro(BinaryReader arquivo, long qualRegistro)
        {
            if (arquivo != null)  // arquivo de leitura foi instanciado (já fica aberto)
                try
                {
                    long qtosBytes = qualRegistro * TamanhoRegistro;       // (número de bytes pulados para posicionar no registro desejado)
                    arquivo.BaseStream.Seek(qtosBytes, SeekOrigin.Begin);  // posicionamento no byte inicial do registro

                    // lemos cada um dos campos do registro separadamente
                    char[] umNome = new char[tamanhoNome];   // criamos um vetor de 15 caracteres 
                    umNome = arquivo.ReadChars(tamanhoNome); // lemos 15 caracteres do arquivo e guardamosno vetor umNome
                    string nomeLido = "";
                    for (int i = 0; i < tamanhoNome; i++) // montamos uma variável string com os caracteres do vetor umNome
                        nomeLido += umNome[i];
                    Nome = nomeLido;                      // armazenamos a string montada acima no campo nome da Cidade

                    X = arquivo.ReadDecimal();     // lê um decimal de 16 bytes
                    Y = arquivo.ReadDecimal();     // lê um decimal de 16 bytes
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
        }
    }
}
