using System.Collections.Generic;
using System.Linq;

namespace SistemaEleicao.Console;

public class EleicaoManager
{
    private readonly List<Candidato> _candidatos = new();

    public IReadOnlyList<Candidato> Candidatos => _candidatos.AsReadOnly();

    public bool AdicionarCandidato(Candidato candidato)
    {
        if (candidato == null)
            throw new ArgumentNullException(nameof(candidato));

        if (_candidatos.Any(c => c.Numero == candidato.Numero))
            return false;

        _candidatos.Add(candidato);
        return true;
    }
}