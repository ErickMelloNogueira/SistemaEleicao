
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEleicao.Console;

public class EleicaoManager
{
    private readonly List<Candidato> _candidatos = new();
    private readonly HashSet<string> _eleitores = new();
    private readonly HashSet<string> _eleitoresQueVotaram = new();
    private readonly Dictionary<int, int> _votosPorCandidato = new();

    public IReadOnlyList<Candidato> Candidatos =>
        _candidatos.AsReadOnly();

    public int VotosNulos { get; private set; }

    public int VotosBrancos { get; private set; }

    public int TotalVotos =>
        VotosNulos + VotosBrancos + _votosPorCandidato.Values.Sum();

    public bool AdicionarCandidato(Candidato candidato)
    {
        if (candidato == null)
            throw new ArgumentNullException(nameof(candidato));

        if (_candidatos.Any(c => c.Numero == candidato.Numero))
            return false;

        _candidatos.Add(candidato);
        _votosPorCandidato[candidato.Numero] = 0;

        return true;
    }

    public bool RegistrarEleitor(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            return false;

        return _eleitores.Add(titulo.Trim());
    }

    public bool Votar(string tituloEleitor, int? numeroCandidato)
    {
        if (string.IsNullOrWhiteSpace(tituloEleitor))
            return false;

        string titulo = tituloEleitor.Trim();

        if (!_eleitores.Contains(titulo))
            return false;

        if (!_eleitoresQueVotaram.Add(titulo))
            return false;

        if (numeroCandidato == null)
        {
            VotosBrancos++;
            return true;
        }

        if (!_votosPorCandidato.ContainsKey(numeroCandidato.Value))
        {
            VotosNulos++;
            return true;
        }

        _votosPorCandidato[numeroCandidato.Value]++;
        return true;
    }

    public int ObterVotosCandidato(int numeroCandidato)
    {
        return _votosPorCandidato.TryGetValue(
            numeroCandidato, out int votos) ? votos : 0;
    }

    public Candidato? ObterVencedor()
    {
        if (_candidatos.Count == 0)
            return null;

        int maiorQuantidade = _candidatos.Max(
            c => _votosPorCandidato[c.Numero]);

        if (maiorQuantidade == 0)
            return null;

        return _candidatos.First(
            c => _votosPorCandidato[c.Numero] == maiorQuantidade);
    }
}
