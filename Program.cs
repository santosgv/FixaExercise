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

public interface IRepository<T> where T : class
{
    // Similar ao .create() do Django ORM
    void Add(T entity);

    // Similar ao .get(id=id) do Django
    T Get(int id);

    // Similar ao .all() do Django
    IEnumerable<T> GetAll();

    // Similar ao .delete() do Django
    void Delete(int id);

    // Bônus: métodos úteis que temos no Django
    void Update(T entity);
    bool Exists(int id);
    int Count();
}

public abstract class Entity
{
    public int Id { get; protected set; } // Similar ao 'id' autoincrement do Django

    // Método para definir ID (normalmente o repositório faz isso)
    public void SetId(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID deve ser maior que zero");
        Id = id;
    }

    // Método para comparar entidades (similar ao __eq__ do Django)
    public override bool Equals(object obj)
    {
        if (obj is Entity other)
            return Id == other.Id;
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

public class Item : Entity
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }

    // Construtor
    public Item(string nome, decimal preco, int estoque)
    {
        Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        Preco = preco;
        Estoque = estoque;
    }

    // Método de negócio
    public void AplicarDesconto(decimal percentual)
    {
        if (percentual < 0 || percentual > 100)
            throw new ArgumentException("Percentual deve estar entre 0 e 100");

        Preco -= Preco * percentual / 100;
    }

    // Override do ToString para exibição
    public override string ToString()
    {
        return $"Produto [ID: {Id}, Nome: {Nome}, Preço: R${Preco:F2}, Estoque: {Estoque}]";
    }
}

public class InMemoryRepository<T> : IRepository<T> where T : Entity
{
    // Dicionário em memória (similar a usar um dict como banco temporário)
    private readonly Dictionary<int, T> _database = new Dictionary<int, T>();
    private int _nextId = 1; // Contador para IDs

    // Similar ao .create() do Django ORM
    public void Add(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        // Atribui um ID automático (como o auto-increment do Django)
        entity.SetId(_nextId++);

        // Adiciona ao "banco em memória"
        _database[entity.Id] = entity;

        Console.WriteLine($"✅ {typeof(T).Name} adicionado com ID: {entity.Id}");
    }

    // Similar ao .get(id=id) - pode lançar exceção se não encontrar
    public T Get(int id)
    {
        if (!_database.TryGetValue(id, out T entity))
            throw new KeyNotFoundException($"{typeof(T).Name} com ID {id} não encontrado");

        return entity;
    }

    // Similar ao .get(id=id) mas retorna null em vez de exceção
    public T GetOrDefault(int id)
    {
        _database.TryGetValue(id, out T entity);
        return entity;
    }

    // Similar ao .all() do Django
    public IEnumerable<T> GetAll()
    {
        return _database.Values;
    }

    // Similar ao .delete() do Django
    public void Delete(int id)
    {
        if (!_database.ContainsKey(id))
            throw new KeyNotFoundException($"{typeof(T).Name} com ID {id} não encontrado");

        _database.Remove(id);
        Console.WriteLine($"🗑️ {typeof(T).Name} com ID {id} removido");
    }

    // Similar ao .save() do Django (mas aqui é Update separado)
    public void Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        if (!_database.ContainsKey(entity.Id))
            throw new KeyNotFoundException($"{typeof(T).Name} com ID {entity.Id} não encontrado");

        _database[entity.Id] = entity;
        Console.WriteLine($"✏️ {typeof(T).Name} com ID {entity.Id} atualizado");
    }

    // Similar ao .exists() do Django QuerySet
    public bool Exists(int id)
    {
        return _database.ContainsKey(id);
    }

    // Similar ao .count() do Django QuerySet
    public int Count()
    {
        return _database.Count;
    }

    // Método adicional: buscar por condição (similar ao .filter() do Django)
    public IEnumerable<T> Find(Func<T, bool> predicate)
    {
        return _database.Values.Where(predicate);
    }
}

public class ItemService
{
    private readonly IRepository<Item> _repository;

    // Injeção de dependência do repositório
    public ItemService(IRepository<Item> repository)
    {
        _repository = repository;
    }

    // Métodos de negócio
    public void CadastrarProduto(string nome, decimal preco, int estoque)
    {
        var item = new Item(nome, preco, estoque);
        _repository.Add(item);
    }

    public Item BuscarPorId(int id)
    {
        return _repository.Get(id);
    }

    public IEnumerable<Item> ListarTodos()
    {
        return _repository.GetAll();
    }

    public IEnumerable<Item> BuscarPorNome(string termo)
    {
        return _repository.GetAll()
            .Where(p => p.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase));
    }

    public void AplicarDescontoEmTodos(decimal percentual)
    {
        var produtos = _repository.GetAll();
        foreach (var produto in produtos)
        {
            produto.AplicarDesconto(percentual);
            _repository.Update(produto);
        }
    }

    public void RemoverProduto(int id)
    {
        _repository.Delete(id);
    }

    public decimal CalcularValorTotalEstoque()
    {
        return _repository.GetAll()
            .Sum(p => p.Preco * p.Estoque);
    }
}

public class InMemoryUserRepository
{
    private readonly List<User> _users = new List<User>();

    public void Add(User user)
    {
        _users.Add(user);
    }
    public User GetByUsername(string username)
    {
        return _users.FirstOrDefault(u => u.Username == username);
    }
    public IEnumerable<User> GetAll()
    {
        return _users;
    }
}

public class User
{
    public  string Username { get; set; }
    public  string Email { get; set; }
    public  string Password { get; set; }

    public User(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}

public class UserService
{
    private static List<User> _users = new List<User>();

    public bool Cadastrar(string nome,string email, string senha)
    {
        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha) )
        {
            Console.Write("Os campos nao podem ser vazios");
            return false;
        }

        if (_users.Any(u => u.Email == email))
        {
            Console.Write("Email ja cadastrado");
            return false;
        }

        string senhahash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(senha));
        Console.WriteLine($"O hash da senha e ={senhahash}");

        var user = new User(nome,email,senhahash);

        _users.Add(user);
        return true;

    }

    public User Login( string email, string senha)
    {
        string senhahash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(senha));
        Console.WriteLine($"a senha e {senha} O hash da senha para login e ={senhahash}");
        var user = _users.FirstOrDefault(u => u.Email == email && u.Password == senhahash);
        return user;
    }
    public IEnumerable<User> GetAllUsers()
    {
        return _users;
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
        //Cliente cliente1 = new Cliente("Gabriel", "email@email");
        //Cliente cliente2 = new Cliente("Silva", "email@email");

        //Produto produto = new Produto("pizza", 50);
        //Produto produto1 = new Produto("Coca-cola", 10);

        //ItemPedido item1 = new ItemPedido(produto1, 2);
        //ItemPedido item2 = new ItemPedido(produto, 1);

        //Pedido pedido = new Pedido(cliente);
        //pedido.Itens.Add(item1);
        //pedido.Itens.Add(item2);

        //Pedido pedido2 = new Pedido(cliente1);
        //Pedido pedido3 = new Pedido(cliente2);
        //pedido2.Itens.Add(new ItemPedido(new Produto("Hamburguer", 30), 3));   
        //pedido3.Itens.Add(new ItemPedido(new Produto("Batata Frita", 20), 1));


        //var pedidos = new List<Pedido> { pedido, pedido2, pedido3 };
        //foreach(var p in pedidos) {
        //    Console.WriteLine($"Pedido do cliente: {p.Cliente.Nome}");
        //    Console.WriteLine("Itens do Pedido:");
        //    foreach(var item in p.Itens) {
        //        Console.WriteLine($" - {item.Quantidade}x {item.Produto.Nome} - R$ {item.Produto.Preco} total.: {item.CalcularSubtotal()}");
        //    }
        //}

        //string clienteNome = "Vitor";
        //var pedidoCliente = pedidos.Where(p => p.Cliente.Nome == clienteNome).FirstOrDefault();
        //Console.Write($"\nDetalhes do pedido do cliente {clienteNome}:\n");
        //Console.Write($"Itens do Pedido:\n");
        //foreach(var item in pedidoCliente.Itens) {
        //    Console.Write($" - {item.Quantidade}x {item.Produto.Nome} - R$ {item.Produto.Preco} total.: {item.CalcularSubtotal()}\n");
        //}

        //Console.Write($"Pedido do cliente: {pedido.Cliente.Nome}\nItens do Pedido:\n");
        //Console.Write($" - {item1.Quantidade}x {item1.Produto.Nome} - R$ {item1.Produto.Preco}\n");
        //Console.Write($" - Subtotal.: {item1.CalcularSubtotal()}\n");
        //Console.Write($" - {item2.Quantidade}x {item2.Produto.Nome} - R$ {item2.Produto.Preco} total.: {item2.CalcularSubtotal()}\n");
        //Console.Write($" - Subtotal.: {item2.CalcularSubtotal()}\n");

        #endregion
        #region Repository Pattern - Sistema de Produtos
        //Console.WriteLine("=== SISTEMA DE PRODUTOS (Repository Pattern) ===\n");

        //// 1. Criar o repositório (in-memory)
        //IRepository<Item> repository = new InMemoryRepository<Item>();

        //// 2. Criar o serviço que usa o repositório
        //var produtoService = new ItemService(repository);

        //// 3. Popular com alguns dados iniciais
        //Console.WriteLine("📦 Cadastrando produtos iniciais...");
        //produtoService.CadastrarProduto("Notebook Dell", 4500.00m, 10);
        //produtoService.CadastrarProduto("Mouse Logitech", 150.00m, 50);
        //produtoService.CadastrarProduto("Teclado Mecânico", 350.00m, 30);
        //produtoService.CadastrarProduto("Monitor 24\"", 1200.00m, 15);

        //// 4. Listar todos os produtos
        //Console.WriteLine("\n📋 Lista de todos os produtos:");
        //foreach (var produto in produtoService.ListarTodos())
        //{
        //    Console.WriteLine($"  {produto}");
        //}

        //// 5. Buscar um produto específico
        //Console.WriteLine("\n🔍 Buscando produto com ID 2:");
        //try
        //{
        //    var produto = produtoService.BuscarPorId(2);
        //    Console.WriteLine($"  Encontrado: {produto}");
        //}
        //catch (KeyNotFoundException ex)
        //{
        //    Console.WriteLine($"  Erro: {ex.Message}");
        //}

        //// 6. Buscar por nome
        //Console.WriteLine("\n🔎 Buscando produtos com 'mouse':");
        //var produtosMouse = produtoService.BuscarPorNome("mouse");
        //foreach (var produto in produtosMouse)
        //{
        //    Console.WriteLine($"  {produto}");
        //}

        //// 7. Aplicar desconto
        //Console.WriteLine("\n💰 Aplicando 10% de desconto em todos os produtos...");
        //produtoService.AplicarDescontoEmTodos(10);

        //// 8. Listar novamente para ver descontos
        //Console.WriteLine("\n📋 Produtos após desconto:");
        //foreach (var produto in produtoService.ListarTodos())
        //{
        //    Console.WriteLine($"  {produto}");
        //}

        //// 9. Calcular valor total do estoque
        //decimal valorTotal = produtoService.CalcularValorTotalEstoque();
        //Console.WriteLine($"\n💵 Valor total em estoque: R${valorTotal:F2}");

        //// 10. Remover um produto
        //Console.WriteLine("\n🗑️ Removendo produto com ID 3...");
        //produtoService.RemoverProduto(3);

        //// 11. Contar produtos restantes
        //Console.WriteLine($"\n📊 Total de produtos no sistema: {repository.Count()}");

        //// 12. Verificar se um produto existe
        //Console.WriteLine($"\n❓ Produto com ID 1 existe? {repository.Exists(1)}");
        //Console.WriteLine($"❓ Produto com ID 99 existe? {repository.Exists(99)}");

        #endregion
        #region Sistema de Usuarios - Cadastro e Login
        //UserService userService = new UserService();

        //Console.WriteLine("=== TESTE DO SISTEMA ===");

        //// Teste 1: Cadastro
        //Console.WriteLine("\n1. Cadastrando usuário...");
        //bool cadastrado = userService.Cadastrar("João Silva", "joao@email.com", "123456");
        //Console.WriteLine($"Cadastro: {(cadastrado ? "SUCESSO" : "FALHA")}");

        //bool cadastrado2 = userService.Cadastrar("Maria Souza", "joao22@email.com", "12353234");
        //bool cadastrado3 = userService.Cadastrar("Maria eduardo", "maria@email.com", "136554");


        //// Teste 2: Login correto
        //Console.WriteLine("\n2. Tentando login com credenciais corretas...");
        //var user = userService.Login("joao@email.com", "123456");
        //Console.WriteLine($"Login: {(user != null ? "SUCESSO" : "FALHA")}");

        //// Teste 3: Login com senha errada
        //Console.WriteLine("\n3. Tentando login com senha errada...");
        //user = userService.Login("joao@email.com", "senhaerrada");
        //Console.WriteLine($"Login: {(user != null ? "SUCESSO" : "FALHA")}");

        //// Teste 5: Cadastro com email duplicado
        //Console.WriteLine("\n5. Tentando cadastrar email duplicado...");
        //cadastrado = userService.Cadastrar("Outro João", "joao@email.com", "654321");
        //Console.WriteLine($"Cadastro: {(cadastrado ? "SUCESSO" : "FALHA")}");

        //// Teste 6: Listar todos os usuários
        //var allUsers = userService.GetAllUsers();
        //Console.WriteLine("\nLista de todos os usuários cadastrados:");

        //foreach (var u in allUsers)
        //{
        //    Console.WriteLine($"- Nome: {u.Username}, Email: {u.Email}");
        //}

        //Console.WriteLine("\n=== FIM DOS TESTES ===");
        #endregion
        Console.ReadKey();

    }
}