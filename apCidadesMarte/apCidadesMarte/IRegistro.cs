using System;
using System.IO;

public interface IRegistro
{
    // lê, do arquivo binário passado como parâmetro, o registro especificado (qualRegistro)
    void LerRegistro(BinaryReader arquivo, long qualRegistro);

    // grava um registro no arquivo binário passado como parâmetro
    void GravarRegistro(BinaryWriter arquivo);

    // pega o tamanho do registro (quantos bytes ocupa aquele dado)
    int TamanhoRegistro { get; }
}
