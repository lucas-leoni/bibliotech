using System;

namespace Models
{
  public class Livro
  {
    public int CodLivro { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string DtPublicacao { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }
    public string Status { get; set; }
    public Livro(
      string titulo,
      string genero,
      string dt_publicacao,
      string autor,
      string editora
    )
    {
      this.Titulo = titulo;
      this.Genero = genero;
      this.DtPublicacao = dt_publicacao;
      this.Autor = autor;
      this.Editora = editora;
      this.Status = "disponível";

      Repositories.LivroRepository.AddLivro(this);
    }

    public void getIndex(int cod_livro)
    {
      this.CodLivro = cod_livro;
    }

    public static List<Models.Livro> ListLivros()
    {
      return Repositories.LivroRepository.ListLivros();
    }

    public static Livro? GetLivro(int cod_livro)
    {
      return Repositories.LivroRepository.GetLivro(cod_livro);
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
      Livro livro = Livro.GetLivro(cod_livro);
      if (livro != null)
      {
        livro.Titulo = titulo;
        livro.Genero = genero;
        livro.DtPublicacao = dt_publicacao;
        livro.Autor = autor;
        livro.Editora = editora;

        Repositories.LivroRepository.UpdateLivro(cod_livro, livro);
      }
    }

    public static void DeleteLivro(int cod_livro)
    {
      Livro livro = Livro.GetLivro(cod_livro);
      if (livro != null)
      {
        Repositories.LivroRepository.DeleteLivro(cod_livro);
      }
    }

    public override string ToString()
    {
      return $"------------------------\n{CodLivro + 1}º livro\nTítulo: {Titulo}\nGênero: {Genero}\nData de publicação: {DtPublicacao}\nAutor: {Autor}\nEditora: {Editora}\n------------------------\n";
    }
  }
}