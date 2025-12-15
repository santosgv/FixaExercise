public class Pessoa
{
    private int _idade;
    public required string Nome { get; set; }
    public int Idade { 
        get => _idade;
        set
        {
            if (value <0 )
                throw new System.ArgumentException("Idade nao pode ser negativa");
            _idade = value;
        }
     }


    public String Apresentar() {
        return $"Ola, Meu nome e {Nome} e tenho {Idade}!";
    }
}   

public class ContaBancaria
{
    public required string NumeroConta { get; set; }
    public decimal Saldo { get; private  set; }

    public void Depositar(decimal valor)
    {
        if(valor < 0)
        {
            throw new System.ArgumentException("Valor do deposito nao pode ser negativo");
        }

        Saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if(valor < 0)
        {
            throw new System.ArgumentException("Valor do saque nao pode ser negativo");
        }
        if(valor > Saldo)
        {
            throw new System.InvalidOperationException("Saldo insuficiente para o saque");
        }

        Saldo -= valor;
    }
}

public class Produtos
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    public Produtos( string nome, decimal preco) {
        Nome = nome;
        Preco = preco; 
    }

    public decimal CalcularDescontos(decimal percentualDesconto) { 
        if(percentualDesconto < 0 || percentualDesconto > 100)
        {
            throw new System.ArgumentException("Percentual de desconto invalido");
        }
        return Preco - (Preco * percentualDesconto / 100);
    }

    public static decimal CalculaTotal(List<Produtos> produtos) {
        decimal total = 0;
        foreach(var produto in produtos) {
            total += produto.Preco;
        }
        return total;
    }

}

public class Veiculo
{

    public string Marca { get; set; }
    public string Modelo { get; set; }
    public Veiculo(string marca, string modelo)
    {
        Marca = marca;
        Modelo = modelo;
    }
    public virtual void Dirigir()
    {
        Console.WriteLine($"Voce esta dirigindo um {Marca} {Modelo} Veiculo");
    }

}

public class Carro : Veiculo
{
    public Carro(string marca, string modelo) : base(marca, modelo)
    {

    }

     public override void Dirigir()
    {
        Console.WriteLine($"Voce esta dirigindo um carro {Marca} {Modelo} Carro");
    }
}

public class Moto : Veiculo
{
    public Moto(string marca, string modelo) : base(marca, modelo)
    {
    }
     public override void Dirigir()
    {
        Console.WriteLine($"Voce esta Pilotando uma moto {Marca} {Modelo} Moto");
    }

}

public interface INotificacao
{
    void Enviar(string mensagem);
}

public class EmailNotificacao : INotificacao
{
    public string Email { get; set; }

    public EmailNotificacao(string email)
    {
        Email = email;
    }

    public void Enviar(string mensagem)
    {
        Console.WriteLine($"Email Enviado para {Email}");
        Console.WriteLine($"Mensagem: {mensagem}");
    }

}

public class SmsNotificacao : INotificacao
{
    public int Sms { get; set; }

    public SmsNotificacao(int sms)
    {
        Sms = sms;
    }

    public void Enviar(string mensagem)
    {
        Console.WriteLine($"SMS evniado para o N°{Sms}");
        Console.WriteLine($"Mensagem: {mensagem}");
    }


}

public class Usuario
{
    private readonly INotificacao _servicoNotificacao;
    public string Nome { get; set; }

    public Usuario(string nome, INotificacao servicoNotificacao)
    {
        Nome = nome;
        _servicoNotificacao = servicoNotificacao;
    }

    public void RecebeMensagem(string mensagem)
    {
        Console.WriteLine($"\n Usuario:{Nome} esta recebendo uma mensagem...");
        _servicoNotificacao.Enviar(mensagem);
    }
}

public class Funcionario
{
    public string Nome { get; set; }
    public decimal Salario { get; set; }

    public Funcionario(string nome, decimal salario)
    {
        Nome = nome;
        Salario = salario;
    }

    public virtual decimal CalcularSalario(decimal salario)
    {
        return Salario;
    }

}

public class FuncionarioCLT : Funcionario
{
    public FuncionarioCLT(string nome, decimal salario) : base(nome, salario)
    {
    }
    public override decimal CalcularSalario(decimal salario)
    {
        decimal desconto = Salario * 0.2m; 
        return Salario - desconto;
    }
}

public class FuncionarioPJ : Funcionario
{
       public FuncionarioPJ(string nome, decimal salario) : base(nome, salario)
    {
    }
    public override decimal CalcularSalario(decimal salario)
    {
        return Salario; 
    }

}

public class Tarefa
{
    public string Descricao { get; set; }
    public string Prioridade { get; set; }
    public bool  Concluida { get; set; }  

    public Tarefa(string descricao, string prioridade, bool concluida)
    {
        Descricao = descricao;
        Prioridade = prioridade;
        Concluida = concluida;
    }
}

public class Cliente
{
    public string Nome { get; set; }
    public string Email { get; set; }

    public Cliente(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }   

}

public class  Pedido
{
    public Cliente Cliente { get; set; }
    public List<ItemPedido> Itens { get; set; }

    public Pedido(Cliente cliente)
    {
        Cliente = cliente;
        Itens = new List<ItemPedido>();
    }

}

public class ItemPedido
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
    public ItemPedido(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }

    public decimal CalcularSubtotal()
    {
        return Produto.Preco * Quantidade;
    }

}

public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        #region Classes e Propriedades
        //Pessoa pessoa = new Pessoa();
        //pessoa.Nome = "João";
        //pessoa.Idade = -1;
        //System.Console.WriteLine(pessoa.Apresentar());


        //ContaBancaria conta = new ContaBancaria { NumeroConta = "12345" };
        //conta.Depositar(1000);
        //Console.WriteLine("Nº da Conta e ",conta.NumeroConta);
        //Console.WriteLine("Saldo em Conta",conta.Saldo);
        //conta.Sacar(500);
        //Console.WriteLine(conta.Saldo); 

        //Produtos produto1 = new Produtos("Notebook", 5000);

        //decimal precoComDesconto = produto1.CalcularDescontos(15);
        //System.Console.WriteLine($"O preco do {produto1.Nome} com desconto e: {precoComDesconto}");

        //List<Produtos> listaCompras = new List<Produtos>();

        //listaCompras.Add(new Produtos("Notebook", 5000));
        //listaCompras.Add(new Produtos("Mouse", 150));
        //listaCompras.Add(new Produtos("Teclado", 350));
        //listaCompras.Add(new Produtos("Monitor", 1200));

        //// Calculando o total usando o método estático da classe Produto
        //decimal totalCompra = Produtos.CalculaTotal(listaCompras);
        //Console.WriteLine($"Total da compra: {totalCompra:C}");


        //// OU usando LINQ (mais moderno)
        //decimal totalComLinq = listaCompras.Sum(p => p.Preco);
        //Console.WriteLine($"Total com LINQ: {totalComLinq:C}");

        //// Exibindo todos os produtos
        //Console.WriteLine("\nLista de Produtos:");
        //foreach (var produto in listaCompras)
        //{
        //    Console.WriteLine($"- {produto.Nome}: {produto.Preco:C}");
        //}
        #endregion
        #region Polimorfismo e Herança
        // Polimorfismo e herança

        //Veiculo veiculo = new Veiculo("Ford", "Genérico");
        //veiculo.Dirigir();

        //Carro carro = new Carro("Ford", "Fiesta");
        //carro.Dirigir();

        //Moto moto = new Moto("Honda", "hornet");
        //moto.Dirigir();
        #endregion
        #region Iterfaces e infejao de dependencia
        //INotificacao email = new EmailNotificacao("santosgomesv@gmail.com");
        //email.Enviar("Esse email foi enviado atravez de Interface");

        //INotificacao sms = new SmsNotificacao(40028922);
        //sms.Enviar("Segue em anexo Assunto da reuniao!");

        // Injeçao de dependencia de Interface
        //INotificacao notificacaoEmail = new EmailNotificacao("jose@email.com");

        //Usuario usuarioEmail = new Usuario("Vitor", notificacaoEmail);
        //usuarioEmail.RecebeMensagem("Seja bem vindo");

        //Funcionario funcionarioCLT = new FuncionarioCLT("Maria", 5000);
        //decimal salarioCLT = funcionarioCLT.CalcularSalario(funcionarioCLT.Salario);
        //System.Console.WriteLine($"Salario CLT de {funcionarioCLT.Nome}: {salarioCLT}");

        //Funcionario funcionarioPJ = new FuncionarioPJ("Carlos", 5000);
        //decimal salarioPJ = funcionarioPJ.CalcularSalario(funcionarioPJ.Salario);
        //System.Console.WriteLine($"Salario PJ de {funcionarioPJ.Nome}: {salarioPJ}");
        #endregion
        #region Linq Lista de Tarefas
        //List<Tarefa> listaTarefas = new List<Tarefa>();
        //listaTarefas.Add( new Tarefa("Estudar C#", "Media", false));
        //listaTarefas.Add( new Tarefa("Fazer compras","baixa", false));
        //listaTarefas.Add( new Tarefa("Limpar a casa", "Alta",true));
        //listaTarefas.Add( new Tarefa("Pagar contas","Alta",true));
        //listaTarefas.Add( new Tarefa("Pagar matricula", "Media", false));

        //var listaOrdenada = listaTarefas.OrderBy(t => 
        //    t.Prioridade == "Alta" ? 1 : 
        //    t.Prioridade == "Media" ? 2 : 3);

        //int quantidade = listaOrdenada.Count();

        //System.Console.WriteLine("Lista de Tarefas Ordenadas por Prioridade:");
        //foreach(var tarefa in listaOrdenada) {
        //    Console.WriteLine($"Descrição: {tarefa.Descricao}, Prioridade: {tarefa.Prioridade}, Concluída: {tarefa.Concluida}");
        //}

        //Console.WriteLine($"Quantidade de Tarefas: {quantidade}");

        //int tarefasConcluidas = listaOrdenada.Count(t => t.Concluida);
        //Console.WriteLine($"Quantidade de Tarefas Concluidas: {tarefasConcluidas}");

        //int tarefasPendentes = listaOrdenada.Count(t => !t.Concluida);
        //Console.WriteLine($"Quantidade de Tarefas Pendentes: {tarefasPendentes}");

        #endregion
        #region Sistema de Pedidos
        //Cliente cliente = new Cliente("Vitor", "email@email");

        //Produto produto = new Produto("pizza", 50);
        //Produto produto1 = new Produto("Coca-cola", 10);

        //ItemPedido item1 = new ItemPedido(produto1, 2);
        //ItemPedido item2 = new ItemPedido(produto, 1);

        //Pedido pedido = new Pedido(cliente);
        //pedido.Itens.Add(item1);
        //pedido.Itens.Add(item2);

        //Console.Write($"Pedido do cliente: {pedido.Cliente.Nome}\nItens do Pedido:\n");
        //Console.Write($" - {item1.Quantidade}x {item1.Produto.Nome} - R$ {item1.Produto.Preco}\n");
        //Console.Write($" - Subtotal.: {item1.CalcularSubtotal()}\n");
        //Console.Write($" - {item2.Quantidade}x {item2.Produto.Nome} - R$ {item2.Produto.Preco} total.: {item2.CalcularSubtotal()}\n");
        //Console.Write($" - Subtotal.: {item2.CalcularSubtotal()}\n");

        #endregion
        System.Console.ReadKey();

    }
}