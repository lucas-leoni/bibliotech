using System;
using System.Collections.Generic;

namespace Controllers
{
  public class LivroController
  {
    public static void LimparList()
    {
      Models.Livro.LimparList();
    }

    public static void AddLivro(
      string titulo,
      string genero,
      DateTime dt_publicacao,
      int id_autor,
      int id_editora
    )
    {
      new Models.Livro(
        titulo,
        genero,
        dt_publicacao,
        id_autor,
        id_editora
      );
    }

    public static List<Models.Livro> ListLivros()
    {
      return Models.Livro.ListLivros();
    }

    public static Models.Livro? GetLivro(int cod_livro)
    {
      return Models.Livro.GetLivro(cod_livro);
    }

    public static void UpdateLivro(
      int cod_livro,
      Models.Livro livro
    )
    {
      Models.Livro.UpdateLivro(
        cod_livro,
        livro
      );
    }

    public static void DeleteLivro(int cod_livro)
    {
      Models.Livro.DeleteLivro(cod_livro);
    }
  }
}