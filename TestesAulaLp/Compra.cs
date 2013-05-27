using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestesAulaLp
{
    class Compra
    {
        private DateTime data;
        private List<Item> itens = new List<Item>();
        private Loja loja;

        public Compra(Loja loja)
        {
            this.data = DateTime.Now;
            this.loja = loja;
            loja.AddCompra(this);
        }

        public void AddItem(Item item)
        {
            itens.Add(item);
        }

        public void AddItens(List<Item> itens)
        {
            this.itens = itens;
        }

        public double Total()
        {
            double temp = 0;
            foreach (Item item in itens)
            {
                temp += item.Preco * item.Quantidade;
            }
            return temp;
        }

        public void Imprime()
        {
            Console.WriteLine("Pedido da Data {0}\n", this.data);
            Console.WriteLine("Pedido feito na Loja {0}, Matriz {1}", loja.Nome, loja.Matriz.Nome);
            Console.WriteLine("Endereço Matriz: {0}, {1}, {2} - Cidade {3} - Estado {4}", loja.Matriz.Endereco.Logradouro, loja.Matriz.Endereco.Numero, loja.Matriz.Endereco.Cep, loja.Matriz.Endereco.Cidade.Nome, loja.Matriz.Endereco.Cidade.Estado.Nome);
            Console.WriteLine("Endereço Loja: {0}, {1}, {2} - Cidade {3} - Estado {4}", loja.Endereco.Logradouro, loja.Endereco.Numero, loja.Endereco.Cep, loja.Endereco.Cidade.Nome, loja.Endereco.Cidade.Estado.Nome);
            foreach (Item item in itens)
            {
                double subtotal = 0;
                subtotal = item.Preco * item.Quantidade;
                Console.WriteLine("Item: {0}, Quantidade: {1}, Preço: {2}, Subtotal: {3}", item.Nome, item.Quantidade, item.Preco, subtotal);
            }
            Console.WriteLine("Total do Pedido: {0}\n", this.Total());
        }
    }

    class Item
    {
        private string nome;
        private double preco;
        private int quantidade;

        public Item(string nome, double preco, int quantidade)
        {
            this.nome = nome;
            this.preco = preco;
            this.quantidade = quantidade;
        }

        public string Nome { get { return this.nome; } }
        public double Preco { get { return this.preco; } }
        public int Quantidade { get { return this.quantidade; } }
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

        public void AddCompra(Compra compra, List<Item> itens)
        {
            compras.Add(compra);
            compra.AddItens(itens);
        }

        public void ImprimeCompras()
        {
            Console.Write("Compra do Cliente: {0}, CPF: {1}\n\n", this.nome, this.cpf);
            foreach (Compra compra in compras)
            {
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
