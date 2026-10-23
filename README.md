# SistemaEleicao

Sistema de eleição desenvolvido em C# com .NET 10, com cadastro e validação de candidatos, processo de votação e testes automatizados utilizando xUnit.

## Funcionalidades

- Cadastro de candidatos.
- Validação das regras de cadastro.
- Sistema de votação.
- Menu interativo no console.
- Testes automatizados para verificar as regras de negócio.

## Tecnologias utilizadas

- C#
- .NET 10
- xUnit
- Git e GitHub

## Pré-requisitos

- .NET 10 SDK instalado.
- Git instalado.

## Como executar

Clone o repositório:

```bash
git clone https://github.com/ErickMelloNogueira/SistemaEleicao.git
```

Entre na pasta do projeto:

```bash
cd SistemaEleicao
```

Execute a aplicação:

```bash
dotnet run --project ./SistemaEleicao.Console/
```

## Como executar os testes

Na pasta raiz do projeto, execute:

```bash
dotnet test
```

Os testes automatizados verificam as regras de validação implementadas no sistema.

## Estrutura do projeto

```text
SistemaEleicao/
├── SistemaEleicao.Console/
├── SistemaEleicao.Tests/
├── README.md
└── LICENSE
```

## Licença

Este projeto está disponibilizado sob a licença MIT. Consulte o arquivo `LICENSE` para obter os detalhes.
