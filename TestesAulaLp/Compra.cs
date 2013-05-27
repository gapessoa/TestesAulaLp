using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestesAulaLp
{
    class Compra
    {
        private DateTime data;
        private List<Pedido> pedidos = new List<Pedido>();
        private Loja loja;
        private NotaFiscal notaFiscal;
        private Cliente cliente;

        public Compra(Loja loja)
        {
            this.data = DateTime.Now;
            
            this.loja = loja;
            loja.AddCompra(this);
        }

        public void AddPedido(Pedido pedido)
        {
            this.pedidos.Add(pedido);
        }

        public void AddPedidos(List<Pedido> pedidos)
        {
            this.pedidos = pedidos;
        }

        public void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public NotaFiscal EmitirNotaFiscal()
        {
            double tempValor = 0;
            foreach (Pedido item in pedidos)
            {
                tempValor += item.ValorTotal();
            }
            this.notaFiscal = new NotaFiscal(tempValor, this.cliente.Cpf);
            return this.notaFiscal;
        }

        public void Imprime()
        {
            foreach (Pedido pedido in pedidos)
            {
                Console.WriteLine("Compra da Data {0}\n", this.data);
                Console.WriteLine("Compra feito na Loja {0}, Matriz {1}", loja.Nome, loja.Matriz.Nome);
                Console.WriteLine("Endereço Matriz: {0}, {1}, {2} - Cidade {3} - Estado {4}", loja.Matriz.Endereco.Logradouro, loja.Matriz.Endereco.Numero, loja.Matriz.Endereco.Cep, loja.Matriz.Endereco.Cidade.Nome, loja.Matriz.Endereco.Cidade.Estado.Nome);
                Console.WriteLine("Endereço Loja: {0}, {1}, {2} - Cidade {3} - Estado {4}", loja.Endereco.Logradouro, loja.Endereco.Numero, loja.Endereco.Cep, loja.Endereco.Cidade.Nome, loja.Endereco.Cidade.Estado.Nome);

                foreach (ItemPedido item in pedido.GetItensPedido())
                {
                    Console.WriteLine("Item: {0}, Quantidade: {1}, Preço: {2}, Subtotal: {3}", item.Produto.Nome, item.Quantidade, item.Produto.Valor, item.Quantidade * item.Produto.Valor);
                }
                Console.WriteLine("Total do Pedido: {0}\n", pedido.ValorTotal());
            }
        }
    }

    class NotaFiscal
    {
        private double valor;
        private string cpf;

        public NotaFiscal(double valor, string cpf)
        {
            this.valor = valor;
            this.cpf = cpf;
        }

        public double Valor { get { return this.valor; } }
        public string Cpf { get { return this.cpf; } }
    }

    class Pedido
    {
        private double valorTotal;
        private List<ItemPedido> itensPedido = new List<ItemPedido>();

        public double ValorTotal()
        {
            double tempTotal = 0;
            foreach (ItemPedido item in itensPedido)
            {
                tempTotal += item.Produto.Valor * item.Quantidade;
            }
            this.valorTotal = tempTotal;
            return tempTotal;
        }

        public void ItensPedido(List<ItemPedido> itensPedido)
        {
            this.itensPedido = itensPedido;
        }

        public void AddItem(ItemPedido item)
        {
            itensPedido.Add(item);
        }

        public List<ItemPedido> GetItensPedido()
        {
            return this.itensPedido;
        }
    }

    class ItemPedido
    {
        private int quantidade;
        private Produto produto;

        public ItemPedido(int quantidade, Produto produto)
        {
            this.quantidade = quantidade;
            this.produto = produto;
        }

        public int Quantidade { get { return this.quantidade; } }
        public Produto Produto { get { return this.produto; } }
    }

    class Produto
    {
        private string nome;
        private string descricao;
        private double valor;

        public Produto(string nome, string descricao, double valor)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.valor = valor;
        }

        public string Nome { get { return this.nome; } }
        public string Descricao { get { return this.descricao; } }
        public double Valor { get { return this.valor; } }
    }

    class Cliente
    {
        private string nome;
        private string cpf;
        private List<Compra> compras = new List<Compra>();

        public Cliente( string nome, string cpf)
        {
            this.nome = nome;
            this.cpf = cpf;
        }

        public string Nome { get { return this.nome; } }
        public string Cpf { get { return this.cpf; } }

        public void AddCompra(Compra compra, List<Pedido> itens)
        {
            compras.Add(compra);
            compra.AddPedidos(itens);
            compra.SetCliente(this);
        }

        public void AddCompra(Compra compra, Pedido pedido)
        {
            compras.Add(compra);
            compra.AddPedido(pedido);
            compra.SetCliente(this);
        }

        public void ImprimeCompras()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("Compra do Cliente: {0}, CPF: {1}\n\n", this.nome, this.cpf);
            foreach (Compra compra in compras)
            {
                Console.WriteLine("Dados da NF:");
                Console.WriteLine("CPF: {0} Valor: R${1}", compra.EmitirNotaFiscal().Cpf, compra.EmitirNotaFiscal().Valor);
                compra.Imprime();
            }
        }
    }

    class Estado
    {
        private string nome;
        private List<Cidade> cidades = new List<Cidade>();

        public Estado (string nome)
        {
            this.nome = nome;
        }

        public void AddCidade(Cidade cidade)
        {
            this.cidades.Add(cidade);
        }

        public List<Cidade> GetCidades()
        {
            return this.cidades;
        }

        public string Nome { get { return this.nome; } }
    }

    class Cidade
    {
        private string nome;
        private Estado estado;
        private List<Endereco> enderecos = new List<Endereco>();

        public Cidade(string nome, Estado estado)
        {
            this.nome = nome;
            this.estado = estado;
            this.estado.AddCidade(this);
        }

        public void AddEndereco(Endereco endereco)
        {
            this.enderecos.Add(endereco);
        }

        public List<Endereco> GetEnderecos()
        {
            return this.enderecos;
        }

        public string Nome { get { return this.nome; } }
        public Estado Estado { get { return this.estado; } }
    }

    class Endereco
    {
        private string logradouro;
        private string numero;
        private string cep;
        private Cidade cidade;

        public Endereco (string logradouro, string numero, string cep, Cidade cidade)
        {
            this.logradouro = logradouro;
            this.numero = numero;
            this.cep = cep;
            this.cidade = cidade;
            cidade.AddEndereco(this);
        }

        public string Logradouro { get { return this.logradouro; } }
        public string Numero { get { return this.numero; } }
        public string Cep { get { return this.cep; } }
        public Cidade Cidade { get { return this.cidade; } }
    }

    class Matriz
    {
        private string nome;
        private List<Loja> lojas = new List<Loja>();
        private Endereco endereco;

        public Matriz(string nome, Endereco endereco)
        {
            this.nome = nome;
            this.endereco = endereco;
        }

        public void AddLoja(Loja loja)
        {
            this.lojas.Add(loja);
        }

        public List<Loja> GetLojas()
        {
            return this.lojas;
        }

        public string Nome { get { return this.nome; } }
        public Endereco Endereco { get { return this.endereco; } } 
    }

    class Loja
    {
        private string nome;
        private Endereco endereco;
        private Matriz matriz;
        private List<Compra> compras = new List<Compra>();

        public Loja(string nome, Endereco endereco, Matriz matriz)
        {
            this.nome = nome;
            this.endereco = endereco;
            this.matriz = matriz;
            matriz.AddLoja(this);
        }

        public void AddCompra(Compra compra)
        {
            this.compras.Add(compra);
        }

        public List<Compra> GetCompras()
        {
            return this.compras;
        }

        public string Nome { get { return this.nome; } }
        public Endereco Endereco { get { return this.endereco; } }
        public Matriz Matriz { get { return this.matriz; } }
    }
}
