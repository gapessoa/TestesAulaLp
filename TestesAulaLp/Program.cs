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

            Item Pizza = new Item("Pizza", 2, 2);
            Item Pastel = new Item("Pastel", 5, 3);
            Item Refrigerante = new Item("Refrigerante", 10, 1);

            Cliente Gabriel = new Cliente("Gabriel", "315.633.778.10");

            List<Item> Itens2 = new List<Item>();
            Itens2.Add(Pizza);
            Itens2.Add(Refrigerante);

            Gabriel.AddCompra(new Compra(Pizzaria), Itens2);

            List<Item> Itens = new List<Item>();
            Itens.Clear();
            Itens.Add(Pastel);
            Itens.Add(Refrigerante);

            Gabriel.AddCompra(new Compra(Pastelaria), Itens);

            Gabriel.ImprimeCompras();

            
            Console.ReadKey();
        }
    }
}
