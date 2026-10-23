
using SistemaEleicao.Console;
using Xunit;

namespace SistemaEleicao.Tests;

public class CandidatoTests
{
    [Fact]
    public void AdicionarCandidato_NumeroInedito_DeveCadastrar()
    {
        var eleicao = new EleicaoManager();
        var candidato = new Candidato("Maria", 10);

        var resultado = eleicao.AdicionarCandidato(candidato);

        Assert.True(resultado);
        Assert.Single(eleicao.Candidatos);
    }

    [Fact]
    public void AdicionarCandidato_NumeroDuplicado_DeveRecusarCadastro()
    {
        var eleicao = new EleicaoManager();

        var primeiro = new Candidato("Maria", 10);
        var segundo = new Candidato("João", 10);

        Assert.True(eleicao.AdicionarCandidato(primeiro));

        var resultado = eleicao.AdicionarCandidato(segundo);

        Assert.False(resultado);
        Assert.Single(eleicao.Candidatos);
    }

    [Fact]
    public void CriarCandidato_NomeVazio_DeveLancarExcecao()
    {
        Assert.Throws<System.ArgumentException>(
            () => new Candidato("", 10));
    }

    [Fact]
    public void CriarCandidato_NumeroNegativo_DeveLancarExcecao()
    {
        Assert.Throws<System.ArgumentException>(
            () => new Candidato("Maria", -1));
    }
}
