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



public class Program
{
    public static void Main(string[] args)
    {
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

        // Polimorfismo e herança

        //Veiculo veiculo = new Veiculo("Ford", "Genérico");
        //veiculo.Dirigir();

        //Carro carro = new Carro("Ford", "Fiesta");
        //carro.Dirigir();

        //Moto moto = new Moto("Honda", "hornet");
        //moto.Dirigir();

        //INotificacao email = new EmailNotificacao("santosgomesv@gmail.com");
        //email.Enviar("Esse email foi enviado atravez de Interface");

        //INotificacao sms = new SmsNotificacao(40028922);
        //sms.Enviar("Segue em anexo Assunto da reuniao!");

        // Injeçao de dependencia de Interface
        //INotificacao notificacaoEmail = new EmailNotificacao("jose@email.com");

        //Usuario usuarioEmail = new Usuario("Vitor", notificacaoEmail);
        //usuarioEmail.RecebeMensagem("Seja bem vindo");

        System.Console.ReadKey();

    }
}