﻿using apCidadesMarte;
using System;
using System.IO;
using System.Text;

public class ListaSimples<Dado> where Dado : IComparable<Dado>, IRegistro, new()
{
    private NoLista<Dado> primeiro, ultimo, atual, anterior;
    private int quantosNos;
    private bool primeiroAcessoDoPercurso;
    Situacao situacaoAtual; // o que está sendo feito com os dados no momento atual

    public ListaSimples()
    {
        primeiro = ultimo = anterior = atual = null;
        quantosNos = 0;
        primeiroAcessoDoPercurso = false;
        SituacaoAtual = Situacao.navegando;
    }

    public void PercorrerLista()
    {
        atual = primeiro;
        while (atual != null)
        {
            Console.WriteLine(atual.Info);
            atual = atual.Prox;
        }
    }

    public void InserirAntesDoInicio(NoLista<Dado> novoNo)
    {
        if (EstaVazia)       // se a lista está vazia, estamos
            ultimo = novoNo; // incluindo o 1o e o último nós!

        novoNo.Prox = primeiro; // faz o novo nó apontar para o nó
        primeiro = novoNo;      // atualmente no início da lista
        quantosNos++;           // (que pode ser null)
    }

    public void InserirAposFim(NoLista<Dado> novoNo)
    {
        if (EstaVazia)
            primeiro = novoNo;
        else
            ultimo.Prox = novoNo;

        quantosNos++;
        ultimo = novoNo;
        ultimo.Prox = null; // garantimos final lógico da lista
    }

    public bool ExisteDado(Dado outroProcurado)
    {
        anterior = null;
        atual = primeiro;

        //	Em seguida, é verificado se a lista está vazia. Caso esteja, é
        //	retornado false ao local de chamada, indicando que a chave não foi
        //	encontrada, e atual e anterior ficam valendo null

        if (EstaVazia)
            return false;

        // a lista não está vazia, possui nós

        // dado procurado é menor que o primeiro dado da lista:
        // portanto, dado procurado não existe
        if (outroProcurado.CompareTo(primeiro.Info) < 0)
            return false;

        // dado procurado é maior que o último dado da lista:
        // portanto, dado procurado não existe
        if (outroProcurado.CompareTo(ultimo.Info) > 0)
        {
            anterior = ultimo;
            atual = null;
            return false;
        }

        //	caso não tenha sido definido que a chave está fora dos limites de 
        //	chaves da lista, vamos procurar no seu interior

        //	o apontador atual indica o primeiro nó da lista e consideraremos que
        //	ainda não achou a chave procurada nem chegamos ao final da lista

        bool achou = false;
        bool fim = false;

        //	repete os comandos abaixo enquanto não achou o RA nem chegou ao
        //	final da lista

        while (!achou && !fim)
            // se o apontador atual vale null, indica final da lista
            if (atual == null)
                fim = true;
            // se não chegou ao final da lista, verifica o valor da chave atual
            else
            // verifica igualdade entre chave procurada e chave do nó atual
            if (outroProcurado.CompareTo(atual.Info) == 0)
                achou = true;
            else
            // se chave atual é maior que a procurada, significa que
            // a chave procurada não existe na lista ordenada e, assim,
            // termina a pesquisa indicando que não achou. Anterior
            // aponta o anterior ao atual, que foi acessado por
            // último
            if (atual.Info.CompareTo(outroProcurado) > 0)
                fim = true;
            else
            {
                // se não achou a chave procurada nem uma chave > que ela,
                // então a pesquisa continua, de maneira que o apontador
                // anterior deve apontar o nó atual e o apontador atual
                // deve seguir para o nó seguinte

                anterior = atual;
                atual = atual.Prox;
            }
        // por fim, caso a pesquisa tenha terminado, o apontador atual
        // aponta o nó onde está a chave procurada, caso ela tenha sido
        // encontrada, ou o nó onde ela deveria estar para manter a
        // ordenação da lista. O apontador anterior aponta o nó anterior
        // ao atual
        
        return achou;   // devolve o valor da variável achou, que indica
    }                   // se a chave procurada foi ou não encontrado

    public void InserirEmOrdem(Dado dados)
    {
        if (!ExisteDado(dados)) // existeChave configura anterior e atual
        {                       // aqui temos certeza de que a chave não existe
                                // guarda dados no novo nó
            var novo = new NoLista<Dado>(dados, null);
            if (EstaVazia)      // se a lista está vazia, então o 	
              InserirAntesDoInicio(novo);  // novo nó é o primeiro da lista
            else
               // testa se nova chave < primeira chave
               if (anterior == null && atual != null)
              InserirAntesDoInicio(novo); // liga novo antes do primeiro
            else
                 // testa se nova chave > última chave
                 if (anterior != null && atual == null)
              InserirAposFim(novo);
            else
              InserirNoMeio(novo);  // insere entre os nós anterior e atual
        }
    }

    private void InserirNoMeio(NoLista<Dado> novo)
    {
        // existeDado() encontrou intervalo de inclusão do novo nó

        anterior.Prox = novo;   // liga anterior ao novo
        novo.Prox = atual;      // e novo no atual

        if (anterior == ultimo)  // se incluiu ao final da lista,
        ultimo = novo;           // atualiza o apontador ultimo
        quantosNos++;            // incrementa número de nós da lista 							 
    }

    public bool RemoverDado(Dado dados)
    {
        if (ExisteDado(dados))
        {
            // existeDado posicionou atual e anterior
            RemoverNo(ref atual, ref anterior);
            return true;
        }

        return false;
    }

    private void RemoverNo(ref NoLista<Dado> atual, ref NoLista<Dado> anterior)
    {
        if (!EstaVazia)
        {
            if (atual == primeiro)
            {
                primeiro = primeiro.Prox;
                if (EstaVazia)
                    ultimo = null;
            }
            else
                if (atual == ultimo)
                {
                    ultimo = anterior;
                    ultimo.Prox = null;
                }
                else
                    anterior.Prox = atual.Prox;

            quantosNos--;
        }
    }

    public void IniciarPercursoSequencial()
    {
        primeiroAcessoDoPercurso = true;
        atual = primeiro;
        anterior = null;
    }

    public bool PodePercorrer()
    {
        if (!primeiroAcessoDoPercurso)
        {
            anterior = atual;
            atual = atual.Prox;
        }
        else
            primeiroAcessoDoPercurso = false;

        return atual != null;
    }
    private void ProcurarMenorDado
        (ref NoLista<Dado> menorAteAgora,
         ref NoLista<Dado> anteriorAoMenor)
    {
        menorAteAgora = primeiro;
        anteriorAoMenor = null;

        IniciarPercursoSequencial();
        while (PodePercorrer())
        {
            if (atual.Info.CompareTo(menorAteAgora.Info) < 0)
            {
                anteriorAoMenor = anterior;
                menorAteAgora = atual;
            }
        }
    }
    public void Ordenar()
    {
        ListaSimples<Dado> ordenada = new ListaSimples<Dado>();
        NoLista<Dado> menorDeTodos = null,
                    antesDoMenor = null;

        while (!EstaVazia)
        {
            ProcurarMenorDado(ref menorDeTodos, ref antesDoMenor);

            NoLista<Dado> novoNo = menorDeTodos;
            this.RemoverNo(ref menorDeTodos, ref antesDoMenor);

            ordenada.InserirAposFim(novoNo);
        }

    }

    public bool EstaVazia
    {
        get => (primeiro == null);
    }

    public NoLista<Dado> Primeiro
    {
        get
        {
            return primeiro;
        }
        set
        {
            primeiro = value;
        }
    }

    public NoLista<Dado> Atual
    {
        get
        {
            return atual;
        }
    }
    public NoLista<Dado> Ultimo
    {
        get
        {
            return ultimo;
        }
    }

    public int QuantosNos
    {
        get
        {
            return quantosNos;
        }
    }

    public Situacao SituacaoAtual { get => situacaoAtual; set => situacaoAtual = value; }

    // inverter
    public void Inverter()
    {
        if (quantosNos > 1)
        {
            NoLista<Dado> um = primeiro;
            ultimo = primeiro;
            NoLista<Dado> dois = primeiro.Prox;
            NoLista<Dado> tres = null;
            while (dois != null)
            {
                tres = dois.Prox;
                dois.Prox = um;
                um = dois;
                dois = tres;
            }
            primeiro = um;
            ultimo.Prox = null;
        }
    }

    public void LerArquivoDeRegistros(string nomeArquivo)
    {
        Dado dado = new Dado();
        FileStream origem = new FileStream(nomeArquivo, FileMode.OpenOrCreate);
        BinaryReader arquivo = new BinaryReader(origem);

        int quantosRegistros = (int) arquivo.BaseStream.Length / dado.TamanhoRegistro;
        int i = 0;

        for (int registroDesejado = 0; registroDesejado < quantosRegistros; registroDesejado++)
        {
            dado.LerRegistro(arquivo, registroDesejado);
            InserirEmOrdem(dado);
        }

        origem.Close();
    }

    public void GravarArquivoDeRegistros(string nomeArquivo)
    {
        FileStream destino = new FileStream(nomeArquivo, FileMode.OpenOrCreate);
        BinaryWriter arquivo = new BinaryWriter(destino);
        
        IniciarPercursoSequencial();
        while (PodePercorrer())
        {
            atual.Info.GravarRegistro(arquivo);
        }

        arquivo.Close();
    }
}
