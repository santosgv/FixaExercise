# exercicios

# ✅ Nível 1 — Base de C# e OOP

Objetivo: entender classes, métodos, propriedades, encapsulamento, construtores.

1. Classe Pessoa

Crie uma classe Pessoa com:

nome

idade

método Apresentar()

📌 Desafio extra: valide a idade (não aceitar negativa) → encapsulamento.

2. Classe ContaBancaria

Simular conta bancária com:

número da conta

saldo (somente leitura)

Depositar()

Sacar() (com verificação de saldo)

🔧 Use propriedades automáticas, propriedades privadas, construtor.

3. Sistema de Produtos

Classe Produto com:

nome

preço

método AplicarDesconto(percentual)

📌 Desafio extra: criar uma lista de produtos e calcular total.

# ✅ Nível 2 — Herança, Polimorfismo e Interfaces

Objetivo: pensar em modelos mais flexíveis, igual no Django usando models.

4. Sistema de Veículos

Crie uma classe Veiculo com:

marca

modelo

método Dirigir()

Depois crie:

Carro : Veiculo

Motocicleta : Veiculo

Cada um deve sobrescrever Dirigir().

 📌 Aprende: virtual, override.

5. Interface INotificacao

Crie uma interface:

interface INotificacao {
    void Enviar(string mensagem);
}


Crie implementações:

EmailNotificacao

SmsNotificacao

E depois uma classe Usuario que recebe uma notificação via injeção de dependência manual.

6. Sistema de Funcionários

Classe base Funcionario com CalcularSalario() virtual.
Classes:

FuncionarioCLT

FuncionarioPJ

Cada uma calcula salário de forma diferente.

📌 Isso te prepara bem para regras de negócio no backend do ASP.NET.

# ✅ Nível 3 — Coleções, LINQ, e manipulação funcional

Agora entra a parte que deixa o C# muito produtivo.

7. Lista de Tarefas (TODO)

Crie uma classe Tarefa com:

descrição

prioridade

concluída (bool)

Use:

List<T>

LINQ para filtrar: concluídas, pendentes, alta prioridade.

🔧 LINQ é o que mais lembra os QuerySets do Django.

8. Sistema de Pedidos

Classes:

Cliente

Pedido

ItemPedido

Produto

Simule:

criar pedido

adicionar itens

calcular total

buscar pedidos por cliente usando LINQ

# ✅ Nível 4 — Padrões do ASP.NET Core

Agora exercícios que te deixam pronto para sistemas reais.

9. Implementar um Repositório

Crie uma interface IRepository<T>:

Add, Get, GetAll, Delete

Implemente com uma lista em memória (primeira etapa).

📌 Isso te prepara para usar Entity Framework depois.

10. Mini API de Usuários (sem banco)

Usando apenas C#:

classes User e UserService

UserService deve validar cadastro, autenticação

armazenar em lista estática

senhas com hash (usar SHA256 no início)

Depois você transporta essa lógica para ASP.NET Core.

# 🚀 Nível 5 — Exercício completo estilo “Projeto Django”

Crie um mini-projeto console simulando um blog:

Usuário cria posts (classe Post)

timeline ordenada por data

desafios diários (classe Desafio)

quando o usuário completa desafio, ganha um “Achievement” (classe Conquista)

Use:

herança

interfaces

LINQ

coleções

encapsulamento

polimorfismo