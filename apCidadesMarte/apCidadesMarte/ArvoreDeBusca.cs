﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace apCidadesMarte
{
    public enum Situacao
    {
        incluindo, exibindo, editando, excluindo, navegando
    }

    class ArvoreDeBusca<Dado>  // : IComparable<NoArvore<Dado>> 
                                where Dado : IComparable<Dado>, IRegistro,
                                             new()  // indica que a classe específica terá um construtor vazio
    {
        NoArvore<Dado> raiz,
                       atual,       // indica o nó que está sendo visitado no momento
                       antecessor;  // indica o nó ancestral daquele que está sendo visitado no momento

        int quantosNos;
        Situacao situacaoAtual;  // o que está sendo feito com os dados no momento atual

        public Panel painelArvore;

        public Panel OndeExibir
        {
            get => painelArvore;
            set => painelArvore = value;
        }

        public ArvoreDeBusca()
        {
            raiz = null;
            atual = null;
            antecessor = null;
            quantosNos = 0;
            SituacaoAtual = Situacao.navegando;
        }

        public NoArvore<Dado> Raiz
        {
            get => raiz; set => raiz = value;
        }

        public string InOrdem  // propriedade que gera a string do percurso in-ordem da árvore
        {
            get { return FazInOrdem(raiz); }
        }

        public string PreOrdem  // propriedade que gera a string do percurso pre-ordem da árvore
        {
            get { return FazPreOrdem(raiz); }
        }

        public string PosOrdem  // propriedade que gera a string do percurso pos-ordem da árvore
        {
            get { return FazPosOrdem(raiz); }
        }

        public NoArvore<Dado> Atual { get => atual; set => atual = value; }
        public Situacao SituacaoAtual { get => situacaoAtual; set => situacaoAtual = value; }

        private string FazInOrdem(NoArvore<Dado> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia

            return FazInOrdem(r.Esq) + " " +
                   r.Info.ToString() + " " +
                   FazInOrdem(r.Dir);
        }

        private string FazPreOrdem(NoArvore<Dado> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia

            return r.Info.ToString() + " " +
                   FazPreOrdem(r.Esq) + " " +
                   FazPreOrdem(r.Dir);
        }

        private string FazPosOrdem(NoArvore<Dado> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia

            return FazPosOrdem(r.Esq) + " " +
                   FazPosOrdem(r.Dir) + " " +
                   r.Info.ToString();
        }

        private bool Eq(NoArvore<Dado> atualA,
                        NoArvore<Dado> atualB)
        {
            if (atualA == null && atualB == null)
                return true;

            if ((atualA == null) != (atualB == null)) // apenas um dos nós é
                return false; // um é nulo e outro não é

            // os dois nós não são nulos
            if (atualA.Info.CompareTo(atualB.Info) != 0)
                return false; // Infos diferentes

            return Eq(atualA.Esq, atualB.Esq) &&
                   Eq(atualA.Dir, atualB.Dir);
        }

        public bool EquivaleA(ArvoreDeBusca<Dado> outraArvore)
        {
            /* . ambas são vazias
            ou
            .. Info(A) = Info(B) e
            ... Esq(A) eq Esq(B) e Dir(A) eq Dir(B)
            */
            return Eq(this.raiz, outraArvore.raiz);
        }

        private int QtosNos(NoArvore<Dado> noAtual)
        {
            if (noAtual == null)  // árvore vazia ou descendente de folha
                return 0;

            return 1 +                 // conta o nó atual
                QtosNos(noAtual.Esq) + // conta nós da subárvore esquerda
                QtosNos(noAtual.Dir);  // conta nós da subárvore direita
        }

        public int QtosNos()
        {
            return QtosNos(raiz);
        }

        private int QtasFolhas(NoArvore<Dado> noAtual)
        {
            if (noAtual == null)
                return 0;
            if (noAtual.Esq == null && noAtual.Dir == null) // noAtual é folha
                return 1;

            // noAtual não é folha, portanto procuramos as folhas de cada ramo e as contamos
            return QtasFolhas(noAtual.Esq) + // conta folhas da subárvore esquerda
                   QtasFolhas(noAtual.Dir); // conta folhas da subárvore direita
        }

        public int QtasFolhas()
        {
            return QtasFolhas(raiz);
        }
        private bool EstritamenteBinaria(NoArvore<Dado> noAtual)
        {
            if (noAtual == null)
                return true;

            // noAtual não é nulo
            if (noAtual.Esq == null && noAtual.Dir == null)
                return true;

            // um dos descendentes é nulo e o outro não é
            if (noAtual.Esq == null && noAtual.Dir != null)
                return false;
            if (noAtual.Esq != null && noAtual.Dir == null)
                return false;

            // se chegamos aqui, nenhum dos descendentes é nulo, dai testamos a
            // "estrita binariedade" das duas subárvores descendentes do nó atual
            return EstritamenteBinaria(noAtual.Esq) &&
                   EstritamenteBinaria(noAtual.Dir);
        }

        public bool EstritamenteBinaria()
        {
            return EstritamenteBinaria(raiz);
        }
        private int Altura(NoArvore<Dado> noAtual)
        {
            int alturaEsquerda,
                alturaDireita;
            if (noAtual == null)
                return 0;
            alturaEsquerda = Altura(noAtual.Esq);
            alturaDireita = Altura(noAtual.Dir);
            if (alturaEsquerda >= alturaDireita)
                return 1 + alturaEsquerda;
            return 1 + alturaDireita;
        }

        public int Altura()
        {
            return Altura(raiz);
        }

        private string EntreParenteses(NoArvore<Dado> noAtual)
        {
            string saida = "(";
            if (noAtual != null)
                saida += noAtual.Info + ":" +
                EntreParenteses(noAtual.Esq) +
                "," +
                EntreParenteses(noAtual.Dir);
            saida += ")";
            return saida;
        }

        public string EntreParenteses()
        {
            return EntreParenteses(raiz);
        }

        private void Trocar(NoArvore<Dado> noAtual)
        {
            if (noAtual != null)
            {
                NoArvore<Dado> auxiliar = noAtual.Esq;
                noAtual.Esq = noAtual.Dir;
                noAtual.Dir = auxiliar;
                Trocar(noAtual.Esq);
                Trocar(noAtual.Dir);
            }
        }

        public void Trocar()
        {
            Trocar(raiz);
        }

        private string PercursoPorNiveis(NoArvore<Dado> noAtual)
        {
            string saida = "";
            // Filalista<NoArvore<Dado>> umaFila = new FilaLista<NoArvore<Dado>>();

            var umaFila = new Queue<NoArvore<Dado>>();
            while (noAtual != null)
            {
                if (noAtual.Esq != null)
                    umaFila.Enqueue(noAtual.Esq);
                if (noAtual.Dir != null)
                    umaFila.Enqueue(noAtual.Dir);
                saida += " " + noAtual.Info;
                if (umaFila.Count == 0)
                    noAtual = null;
                else
                    noAtual = umaFila.Dequeue();
            }
            return saida;
        }

        public string PercursoPorNiveis()
        {
            return PercursoPorNiveis(raiz);
        }

        int[] quantosNoNivel = new int[1000]; // GLOBAL NA CLASSE
        private int Largura(NoArvore<Dado> noAtual)
        {
            for (int i = 0; i < 1000; i++)
                quantosNoNivel[i] = 0;
            ContarNosNosNiveis(noAtual, 0);
            // acha o nível com o maior contador de nós
            int indiceMaior = 0;
            for (int i = 0; i < 1000; i++)
                if (quantosNoNivel[i] > quantosNoNivel[indiceMaior])
                    indiceMaior = i;
            return quantosNoNivel[indiceMaior];
        }

        public int Largura()
        {
            return Largura(raiz);
        }
        public void ContarNosNosNiveis(NoArvore<Dado> noAtual, int qualNivel)
        {
            if (noAtual != null)
            {
                ++quantosNoNivel[qualNivel];
                ContarNosNosNiveis(noAtual.Esq, qualNivel + 1);
                ContarNosNosNiveis(noAtual.Dir, qualNivel + 1);
            }
        }

        bool achou = false;
        private string EscreverAntecessores(NoArvore<Dado> atual, Dado procurado)
        {
            string saida = "";
            if (atual != null)
            {
                if (!achou)
                    EscreverAntecessores(atual.Esq, procurado);
                if (!achou)
                    EscreverAntecessores(atual.Dir, procurado);
                if (atual.Info.CompareTo(procurado) == 0)
                    achou = true;
                if (achou)
                    saida += " " + atual.Info;
            }
            return saida;
        }

        public string PreparaEscritaDosAntecessores(Dado procurado)
        {
            achou = false;
            return EscreverAntecessores(Raiz, procurado);
        }

        public void DesenharArvore(bool primeiraVez, NoArvore<Dado> raiz,
                                   int x, int y, double angulo, double incremento,
                                   double comprimento, Graphics g)
        {
            int xf, yf;
            if (raiz != null)
            {
                Pen caneta = new Pen(Color.Red);
                xf = (int)Math.Round(x + Math.Cos(angulo) * comprimento);
                yf = (int)Math.Round(y + Math.Sin(angulo) * comprimento);

                if (primeiraVez)
                    yf = 25;

                g.DrawLine(caneta, x, y, xf, yf);
                Thread.Sleep(200);
                DesenharArvore(false, raiz.Esq, xf, yf, Math.PI / 2 + incremento,
                                       incremento * 0.60, comprimento * 0.8, g);
                DesenharArvore(false, raiz.Dir, xf, yf, Math.PI / 2 - incremento,
                                        incremento * 0.6, comprimento * 0.8, g);
                Thread.Sleep(100);
                SolidBrush preenchimento = new SolidBrush(Color.MediumAquamarine);
                g.FillEllipse(preenchimento, xf - 25, yf - 15, 42, 30);
                g.DrawString(Convert.ToString(raiz.Info.ToString()),
                             new Font("Comic Sans", 10),
                             new SolidBrush(Color.Black), xf - 23, yf - 7);
            }
        }

        private bool ExisteRec(NoArvore<Dado> local, Dado procurado)
        {
            // se a árvore tá vazia, o dado claramente não existe
            if (local == null)
                return false;

            if (local.Info.CompareTo(procurado) == 0)
            {
                atual = local;
                return true;
            }

            antecessor = local;
            if (procurado.CompareTo(local.Info) < 0)
                return ExisteRec(local.Esq, procurado);	 // Desloca apontador na 
            else                                         // próxima instância do 
                return ExisteRec(local.Dir, procurado);	 // método
        }

        public bool ExisteRegistro(Dado procurado)
        {
            return ExisteRec(raiz, procurado);
        }

        public void LerArquivoDeRegistros(string nomeArquivo)
        {
            raiz = null;
            Dado dado = new Dado();
            var origem = new FileStream(nomeArquivo, FileMode.OpenOrCreate);
            var arquivo = new BinaryReader(origem);
            int posicaoFinal = (int)origem.Length / dado.TamanhoRegistro - 1;
            Particionar(0, posicaoFinal, ref raiz);
            origem.Close();

            void Particionar(long inicio, long fim, ref NoArvore<Dado> atual)
            {
                if (inicio <= fim)
                {
                    long meio = (inicio + fim) / 2;

                    dado = new Dado();                          // cria um objeto para armazenar os dados
                    dado.LerRegistro(arquivo, meio);
                    atual = new NoArvore<Dado>(dado);
                    var novoEsq = atual.Esq;
                    Particionar(inicio, meio - 1, ref novoEsq); // Particiona à esquerda 
                    atual.Esq = novoEsq;
                    var novoDir = atual.Dir;
                    Particionar(meio + 1, fim, ref novoDir);    // Particiona à direita  
                    atual.Dir = novoDir;
                }
            }

        }

        public void GravarArquivoDeRegistros(string nomeArquivo)
        {
            var destino = new FileStream(nomeArquivo, FileMode.Create);
            var arquivo = new BinaryWriter(destino);
            GravarInOrdem(raiz);
            arquivo.Close();

            void GravarInOrdem(NoArvore<Dado> r)
            {
                if (r != null)
                {
                    GravarInOrdem(r.Esq);

                    r.Info.GravarRegistro(arquivo);

                    GravarInOrdem(r.Dir);
                }
            }
        }

        public bool ApagarNo(Dado registroARemover)
        {
            atual = raiz;
            antecessor = null;
            bool ehFilhoEsquerdo = true;
            while (atual.Info.CompareTo(registroARemover) != 0)  // enqto não acha a chave a remover
            {
                antecessor = atual;
                if (atual.Info.CompareTo(registroARemover) > 0)
                {
                    ehFilhoEsquerdo = true;
                    atual = atual.Esq;
                }
                else
                {
                    ehFilhoEsquerdo = false;
                    atual = atual.Dir;
                }

                if (atual == null)  // neste caso, a chave a remover não existe e não pode
                    return false;   // ser excluída, dai retornamos falso indicando isso
            }  // fim do while

            // se fluxo de execução vem para este ponto, a chave a remover foi encontrada
            // e o ponteiro atual indica o nó que contém essa chave

            if ((atual.Esq == null) && (atual.Dir == null))  // é folha, nó com 0 filhos
            {
                if (atual == raiz)
                    raiz = null;   // exclui a raiz e a árvore fica vazia
                else
                    if (ehFilhoEsquerdo)        // se for filho esquerdo, o antecessor deixará 
                    antecessor.Esq = null;  // de ter um descendente esquerdo
                else                        // se for filho direito, o antecessor deixará de 
                    antecessor.Dir = null;  // apontar para esse filho

                atual = antecessor;  // feito para atual apontar um nó válido ao sairmos do método
            }
            else   // verificará as duas outras possibilidades, exclusão de nó com 1 ou 2 filhos
                if (atual.Dir == null)   // neste caso, só tem o filho esquerdo
            {
                if (atual == raiz)
                    raiz = atual.Esq;
                else
                    if (ehFilhoEsquerdo)
                    antecessor.Esq = atual.Esq;
                else
                    antecessor.Dir = atual.Esq;
                atual = antecessor;
            }
            else
                    if (atual.Esq == null)  // neste caso, só tem o filho direito
            {
                if (atual == raiz)
                    raiz = atual.Dir;
                else
                    if (ehFilhoEsquerdo)
                    antecessor.Esq = atual.Dir;
                else
                    antecessor.Dir = atual.Dir;
                atual = antecessor;
            }
            else // tem os dois descendentes
            {
                NoArvore<Dado> menorDosMaiores = ProcuraMenorDosMaioresDescendentes(atual);
                atual.Info = menorDosMaiores.Info;
                menorDosMaiores = null; // para liberar o nó trocado da memória
            }
            return true;
        }

        public NoArvore<Dado> ProcuraMenorDosMaioresDescendentes(NoArvore<Dado> noAExcluir)
        {
            NoArvore<Dado> paiDoSucessor = noAExcluir;
            NoArvore<Dado> sucessor = noAExcluir;
            NoArvore<Dado> atual = noAExcluir.Dir;   // vai ao ramo direito do nó a ser excluído, pois este ramo contém
            // os descendentes que são maiores que o nó a ser excluído 
            while (atual != null)
            {
                if (atual.Esq != null)
                    paiDoSucessor = atual;
                sucessor = atual;
                atual = atual.Esq;
            }

            if (sucessor != noAExcluir.Dir)
            {
                paiDoSucessor.Esq = sucessor.Dir;
                sucessor.Dir = noAExcluir.Dir;
            }
            return sucessor;
        }

        public int AlturaArvore(NoArvore<Dado> atual, ref bool balanceada)
        {
            int alturaDireita, alturaEsquerda, result;
            if (atual != null && balanceada)
            {
                alturaEsquerda = 1 + AlturaArvore(atual.Esq, ref balanceada);
                alturaDireita = 1 + AlturaArvore(atual.Dir, ref balanceada);
                result = Math.Max(alturaEsquerda, alturaDireita);

                //if (alturaDireita > alturaEsquerda)
                //    result = alturaDireita;
                //else
                //  result = alturaEsquerda;

                if (Math.Abs(alturaDireita - alturaEsquerda) > 1)
                    balanceada = false;
            }
            else
                result = 0;
            return result;
        }

        public int GetAltura(NoArvore<Dado> no)
        {
            if (no != null)
                return no.Altura;
            else
                return -1;
        }

        public void InserirBalanceado(Dado item)
        {
            raiz = InserirBalanceado(item, raiz);
        }

        private NoArvore<Dado> InserirBalanceado(Dado item, NoArvore<Dado> noAtual)
        {
            if (noAtual == null)
                noAtual = new NoArvore<Dado>(item);
            else
            {
                if (item.CompareTo(noAtual.Info) < 0)
                {
                    noAtual.Esq = InserirBalanceado(item, noAtual.Esq);
                    if (GetAltura(noAtual.Esq) - GetAltura(noAtual.Dir) == 2) // getAltura testa nulo
                        if (item.CompareTo(noAtual.Esq.Info) < 0)
                            noAtual = RotacaoSimplesComFilhoEsquerdo(noAtual);
                        else
                            noAtual = RotacaoDuplaComFilhoEsquerdo(noAtual);
                }
                else
                if (item.CompareTo(noAtual.Info) > 0)
                {
                    noAtual.Dir = InserirBalanceado(item, noAtual.Dir);
                    if (GetAltura(noAtual.Dir) - GetAltura(noAtual.Esq) == 2) // getAltura testa nulo
                        if (item.CompareTo(noAtual.Dir.Info) > 0)
                            noAtual = RotacaoSimplesComFilhoDireito(noAtual);
                        else
                            noAtual = RotacaoDuplaComFilhoDireito(noAtual);
                }
                //else ; - não faz nada, valor duplicado
                noAtual.Altura = Math.Max(GetAltura(noAtual.Esq), GetAltura(noAtual.Dir)) + 1;
            }
            return noAtual;
        }

        private NoArvore<Dado> RotacaoSimplesComFilhoEsquerdo(NoArvore<Dado> no)
        {
            NoArvore<Dado> temp = no.Esq;
            no.Esq = temp.Dir;
            temp.Dir = no;
            no.Altura = Math.Max(GetAltura(no.Esq), GetAltura(no.Dir)) + 1;
            temp.Altura = Math.Max(GetAltura(temp.Esq), GetAltura(no)) + 1;
            return temp;
        }

        private NoArvore<Dado> RotacaoSimplesComFilhoDireito(NoArvore<Dado> no)
        {
            NoArvore<Dado> temp = no.Dir;
            no.Dir = temp.Esq;
            temp.Esq = no;
            no.Altura = Math.Max(GetAltura(no.Esq), GetAltura(no.Dir)) + 1;
            temp.Altura = Math.Max(GetAltura(temp.Dir), GetAltura(no)) + 1;
            return temp;
        }
        private NoArvore<Dado> RotacaoDuplaComFilhoEsquerdo(NoArvore<Dado> no)
        {
            no.Esq = RotacaoSimplesComFilhoDireito(no.Esq);
            return RotacaoSimplesComFilhoEsquerdo(no);
        }
        private NoArvore<Dado> RotacaoDuplaComFilhoDireito(NoArvore<Dado> no)
        {
            no.Dir = RotacaoSimplesComFilhoEsquerdo(no.Dir);
            return RotacaoSimplesComFilhoDireito(no);
        }
    }
}