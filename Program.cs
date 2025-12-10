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
    public required string Nome { get; set; }
    public decimal Preco { get; set; }

    public decimal CalcularDescontos(decimal percentualDesconto) { 
        if(percentualDesconto < 0 || percentualDesconto > 100)
        {
            throw new System.ArgumentException("Percentual de desconto invalido");
        }
        return Preco - (Preco * percentualDesconto / 100);
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

        //Produtos produto = new Produtos { Nome = "Notebook", Preco = 1000 };
        //decimal precoComDesconto = produto.CalcularDescontos(15);
        //System.Console.WriteLine($"O preco do {produto.Nome} com desconto e: {precoComDesconto}");
    }
}