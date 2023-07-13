using System;
using System.Collections.Generic;

namespace Controllers
{
  public class LivroController
  {
    public static void AddLivro(
      string titulo,
      string genero,
      string dt_publicacao,
      string autor,
      string editora
    )
    {
      new Models.Livro(
        titulo,
        genero,
        dt_publicacao,
        autor,
        editora
      );
    }

    public static List<Models.Livro> ListLivros()
    {
      return Models.Livro.ListLivros();
    }

    public static void UpdateLivro(
      int cod_livro,
      string titulo,
      string genero,
      string dt_publicacao,
      string autor,
      string editora
    )
    {
      Models.Livro.UpdateLivro(
        cod_livro,
        titulo,
        genero,
        dt_publicacao,
        autor,
        editora
      );
    }

    public static void DeleteLivro(int cod_livro)
    {
      Models.Livro.DeleteLivro(cod_livro);
    }
  }
}