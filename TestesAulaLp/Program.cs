using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestesAulaLp
{
    class Program
    {
        static void Main(string[] args)
        {
            Estado EstadoSaoPaulo = new Estado("São Paulo");
            Cidade SaoPaulo = new Cidade("São Paulo", EstadoSaoPaulo);
            Cidade Guarulhos = new Cidade("Guarulhos", EstadoSaoPaulo);

            Endereco EndMatrix = new Endereco("Rua Frei Vicente do Salvador", "120", "02019-000", SaoPaulo);
            Endereco EndPizzaria = new Endereco("Rua Bento Arruda", "111", "02323-323", SaoPaulo);
            Endereco EndPastelaria = new Endereco("Rua Fulana", "34", "32444-434", Guarulhos);

            Matriz MatrizPrincipal = new Matriz("Principal", EndMatrix);

            Loja Pizzaria = new Loja("Pizzaria do Zé", EndPizzaria, MatrizPrincipal);
            Loja Pastelaria = new Loja("Pastelaria do João", EndPastelaria, MatrizPrincipal);

            Produto Pizza = new Produto("Pizza", "Sabor Calabreza", 2);
            Produto Pastel = new Produto("Pastel", "Sabor Carne", 5);
            Produto Refrigerante = new Produto("Refrigerante", "Garrafa 2 Litros", 10);

            Cliente Gabriel = new Cliente("Gabriel Pessoa", "315.633.778.10");

            Pedido pedido = new Pedido();
            pedido.AddItem(new ItemPedido(2, Pizza));
            pedido.AddItem(new ItemPedido(3, Refrigerante));

            Pedido pedido2 = new Pedido();
            pedido2.AddItem(new ItemPedido(3, Refrigerante));
            pedido2.AddItem(new ItemPedido(5, Pastel));

            List<Pedido> pedidosGabriel = new List<Pedido>();
            pedidosGabriel.Add(pedido);
            pedidosGabriel.Add(pedido2);

            Compra compra = new Compra(Pizzaria);
            Gabriel.AddCompra(compra,pedidosGabriel);

            Cliente Israel = new Cliente("Israel Florentino", "333.333.333.10");

            Pedido pedido3 = new Pedido();

            pedido3.AddItem(new ItemPedido(2, Pastel));
            pedido3.AddItem(new ItemPedido(4, Refrigerante));

            Compra compra2 = new Compra(Pastelaria);

            Israel.AddCompra(compra2, pedido3);

            Gabriel.ImprimeCompras();
            Israel.ImprimeCompras();

            Console.ReadKey();
        }
    }
}
