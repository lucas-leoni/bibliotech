using System;

namespace Models
{
  public class Livro
  {
    public int CodLivro { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public DateTime DtPublicacao { get; set; }
    public string Status { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }

    public Livro() { }

    public Livro(
      string titulo,
      string genero,
      DateTime dt_publicacao,
      string autor,
      string editora
    )
    {
      this.Titulo = titulo;
      this.Genero = genero;
      this.DtPublicacao = dt_publicacao;
      this.Status = "Disponível";
      this.Autor = autor;
      this.Editora = editora;

      Repositories.LivroRepository.AddLivro(this);
    }

    public static void LimparList()
    {
      Repositories.LivroRepository.LimparList();
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
      Livro livro
    )
    {
      // Obtém o livro existente no banco de dados
      Livro livro_existente = GetLivro(cod_livro);

      if (livro_existente != null)
      {
        // Atualiza as propriedades do livro existente com os novos valores
        livro_existente.Titulo = livro.Titulo;
        livro_existente.Genero = livro.Genero;
        livro_existente.DtPublicacao = livro.DtPublicacao;
        livro_existente.Status = livro.Status;
        livro_existente.Autor = livro.Autor;
        livro_existente.Editora = livro.Editora;

        // Chama o método de update do repository
        Repositories.LivroRepository.UpdateLivro(cod_livro, livro_existente);
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
      return $"------------------------\nTítulo: {Titulo}\nGênero: {Genero}\nData de publicação: {DtPublicacao}\nStatus: {Status}\nAutor: {Autor}\nEditora: {Editora}\n------------------------\n";
    }
  }
}