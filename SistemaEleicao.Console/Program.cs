
using System;
using SistemaEleicao.Console;

var eleicao = new EleicaoManager();

bool executando = true;

while (executando)
{
    global::System.Console.WriteLine("\n===== SISTEMA DE ELEIÇÃO =====");
    global::System.Console.WriteLine("1 - Cadastrar candidato");
    global::System.Console.WriteLine("2 - Registrar eleitor");
    global::System.Console.WriteLine("3 - Votar");
    global::System.Console.WriteLine("4 - Apurar votos");
    global::System.Console.WriteLine("0 - Sair");
    global::System.Console.Write("Escolha uma opção: ");

    string? opcao = global::System.Console.ReadLine();

    switch (opcao)
    {
        case "1":
            global::System.Console.Write("Nome do candidato: ");
            string? nome = global::System.Console.ReadLine();

            global::System.Console.Write("Número do candidato: ");
            if (!int.TryParse(global::System.Console.ReadLine(), out int numero))
            {
                global::System.Console.WriteLine("Número inválido.");
                break;
            }

            try
            {
                var candidato = new Candidato(nome ?? "", numero);

                if (eleicao.AdicionarCandidato(candidato))
                    global::System.Console.WriteLine("Candidato cadastrado com sucesso!");
                else
                    global::System.Console.WriteLine("Já existe um candidato com esse número.");
            }
            catch (ArgumentException ex)
            {
                global::System.Console.WriteLine(ex.Message);
            }
            break;

        case "2":
            global::System.Console.Write("Número do título/CPF do eleitor: ");
            string? titulo = global::System.Console.ReadLine();

            if (eleicao.RegistrarEleitor(titulo ?? ""))
                global::System.Console.WriteLine("Eleitor registrado com sucesso!");
            else
                global::System.Console.WriteLine("Título inválido ou eleitor já cadastrado.");
            break;

        case "3":
            global::System.Console.Write("Número do título/CPF do eleitor: ");
            string? tituloVoto = global::System.Console.ReadLine();

            global::System.Console.WriteLine("\nCandidatos disponíveis:");
            foreach (var candidato in eleicao.Candidatos)
                global::System.Console.WriteLine($"{candidato.Numero} - {candidato.Nome}");

            global::System.Console.WriteLine("0 - Voto em branco");
            global::System.Console.Write("Digite o número escolhido: ");

            if (!int.TryParse(global::System.Console.ReadLine(), out int numeroVoto))
            {
                global::System.Console.WriteLine("Entrada inválida. O voto não foi registrado.");
                break;
            }

            bool votoRegistrado = eleicao.Votar(
                tituloVoto ?? "",
                numeroVoto == 0 ? null : numeroVoto
            );

            if (votoRegistrado)
                global::System.Console.WriteLine("Voto registrado com sucesso!");
            else
                global::System.Console.WriteLine("Eleitor não cadastrado ou já votou.");
            break;

        case "4":
            global::System.Console.WriteLine("\n===== APURAÇÃO DE VOTOS =====");

            if (eleicao.Candidatos.Count == 0)
                global::System.Console.WriteLine("Nenhum candidato cadastrado.");

            foreach (var candidato in eleicao.Candidatos)
            {
                global::System.Console.WriteLine(
                    $"{candidato.Numero} - {candidato.Nome}: " +
                    $"{eleicao.ObterVotosCandidato(candidato.Numero)} voto(s)"
                );
            }

            global::System.Console.WriteLine($"Votos nulos: {eleicao.VotosNulos}");
            global::System.Console.WriteLine($"Votos brancos: {eleicao.VotosBrancos}");
            global::System.Console.WriteLine($"Total de votos: {eleicao.TotalVotos}");

            var vencedor = eleicao.ObterVencedor();

            if (vencedor != null)
                global::System.Console.WriteLine($"Vencedor: {vencedor.Nome} ({vencedor.Numero})");
            else
                global::System.Console.WriteLine("Ainda não há vencedor definido.");

            break;

        case "0":
            executando = false;
            global::System.Console.WriteLine("Sistema encerrado.");
            break;

        default:
            global::System.Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}

