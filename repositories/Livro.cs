using System;
using System.Collections.Generic;

namespace Repositories
{
  public class LivroRepository
  {
    static List<Models.Livro> livros = new List<Models.Livro>();

    public static void AddLivro(Models.Livro livro)
    {
      livros.Add(livro);
      int cod_livro = livros.IndexOf(livro);
      livro.getIndex(cod_livro);
    }

    public static List<Models.Livro> ListLivros()
    {
      return livros;
    }

    public static Models.Livro? GetLivro(int cod_livro)
    {
      if (cod_livro < 0 || cod_livro >= livros.Count)
      {
        return null;
      }
      else
      {
        return livros[cod_livro];
      }
    }

    public static void UpdateLivro(int cod_livro, Models.Livro livro)
    {
      livros[cod_livro] = livro;
    }

    public static void DeleteLivro(int cod_livro)
    {
      livros.RemoveAt(cod_livro);
    }
  }
}