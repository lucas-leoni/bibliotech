using System;
using System.Collections.Generic;

namespace Views
{
  public class LivroView
  {
    public static void AddLivro()
    {
      string titulo, genero, dt_publicacao, autor, editora;

      Console.Write("Informe o título do livro: ");
      titulo = Console.ReadLine();
      Console.Write("Informe o gênero do livro: ");
      genero = Console.ReadLine();
      Console.Write("Informe a data de publicação do livro: ");
      dt_publicacao = Console.ReadLine();
      Console.Write("Informe o autor do livro: ");
      autor = Console.ReadLine();
      Console.Write("Informe a editora do livro: ");
      editora = Console.ReadLine();

      Controllers.LivroController.AddLivro(
        titulo,
        genero,
        dt_publicacao,
        autor,
        editora
      );

      Console.WriteLine("\n-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }
    public static void ListLivros()
    {
      List<Models.Livro> livros = Controllers.LivroController.ListLivros();

      Console.WriteLine("Segue a lista de livros: \n");
      foreach (var livro in livros)
      {
        Console.WriteLine(livro.ToString());
      }

      Console.WriteLine("-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }
    public static void UpdateLivro()
    {
      int cod_livro;
			string titulo, genero, dt_publicacao, autor, editora;

      Console.Write("Informe o código do livro: ");
      cod_livro = Convert.ToInt32(Console.ReadLine());

      Console.Write("Informe o título do livro: ");
      titulo = Console.ReadLine();
      Console.Write("Informe o gênero do livro: ");
      genero = Console.ReadLine();
      Console.Write("Informe a data de publicação do livro: ");
      dt_publicacao = Console.ReadLine();
      Console.Write("Informe o autor do livro: ");
      autor = Console.ReadLine();
      Console.Write("Informe a editora do livro: ");
      editora = Console.ReadLine();

      Controllers.LivroController.UpdateLivro(
        cod_livro - 1,
        titulo,
        genero,
        dt_publicacao,
        autor,
        editora
      );

      Console.WriteLine("\n-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }

    public static void DeleteLivro()
    {
      int cod_livro;

      Console.Write("Informe o código do livro: ");
      cod_livro = Convert.ToInt32(Console.ReadLine());

      Controllers.LivroController.DeleteLivro(cod_livro - 1);

      Console.WriteLine("\n-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }
  }
}