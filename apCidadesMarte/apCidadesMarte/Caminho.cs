using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCidadesMarte
{
    public class Caminho : IRegistro, IComparable<Caminho>
    {
        private const byte tamanhoNome = 15;
        private string cidOrigem, cidDestino;
        private int distancia, tempo, custo; 

            const int tamanhoRegistro = tamanhoNome + // tamanho do nome
                                    sizeof(double) + // tamanho da coordenada x
                                    sizeof(double);  // tamanho da coordenada y

        public Cidade() // construtor default (sem parametros)
        {
            this.Nome = "";
            this.X = 0.0;
            this.Y = 0.0;
        }
        public Cidade(string nome, double x, double y) // construtor parametrizado
        {
            this.Nome = nome;
            this.X = x;
            this.Y = y;
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
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public int CompareTo(Cidade outraCidade)
        {
            return nome.CompareTo(outraCidade.Nome);
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

                arquivo.Write(X);                       // escreve os 8 bytes da coordenada X no arquivo 
                arquivo.Write(Y);                       // escreve os 8 bytes da coordenada Y no arquivo 
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
                    umNome = arquivo.ReadChars(tamanhoNome); // lêmos 15 caracteres do arquivo e guardamosno vertor umNome
                    string nomeLido = "";
                    for (int i = 0; i < tamanhoNome; i++) // montamos uma variável string com os caracteres do vetor umNome
                        nomeLido += umNome[i];
                    Nome = nomeLido;                      // armazenamos a string montada acima no campo nome da Cidade
                    MessageBox.Show(Nome);

                    X = arquivo.ReadDouble();     // lê um double de 8 bytes
                    Y = arquivo.ReadDouble();     // lê um double de 8 bytes
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
        }
    }
}
}
