using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            GravarUsandoEntity();
            RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();

        }


        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                List<Produto> produtos = (List<Produto>)repo.Produtos();
                produtos.ForEach((Produto item) => { repo.Remover(item); });
               
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                List<Produto> produtos = (List<Produto>)repo.Produtos();
                Console.WriteLine("Foram encontrados {0} produto(s)", produtos.Count);
                produtos.ForEach((Produto produto) => { Console.WriteLine(produto.Nome); });
                Console.ReadKey();
            }
        }
        private static void AtualizarProduto()
        {
            //Insert Product
            GravarUsandoEntity();
            RecuperarProdutos();
            //Update Product
            using (var repo = new ProdutoDAOEntity())
            {
                Produto primeiro = repo.Produtos().First();
                primeiro.Nome = "Harry Potter Editado";
                repo.Atualizar(primeiro);
            }


            RecuperarProdutos();
        }

        private static void GravarUsandoEntity()
        {
            Produto p1 = new Produto();
            p1.Nome = "Harry Potter e a Ordem da Fênix";
            p1.Categoria = "Livros";
            p1.Preco = 19.89;


            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p1);
              
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
