using System;

namespace Models
{
  public class Emprestimo
  {
    public int CodEmprestimo { get; set; }
    public DateTime DtEmprestimo { get; set; }
    public DateTime DtPrevDevolucao { get; set; }
    public DateTime? DtRealDevolucao { get; set; }
    public int CodLivro { get; set; }
    public int IdUsuario { get; set; }

    public Emprestimo() { }

    public Emprestimo(
			DateTime dt_emprestimo,
			DateTime dt_prev_devolucao,
			DateTime? dt_real_devolucao,
			int cod_livro,
			int id_usuario
    )
    {
      this.DtEmprestimo = dt_emprestimo;
      this.DtPrevDevolucao = dt_prev_devolucao;
      this.DtRealDevolucao = dt_real_devolucao;
      this.CodLivro = cod_livro;
      this.IdUsuario = id_usuario;

      Repositories.EmprestimoRepository.Emprestar(this);
    }

    public static void LimparList()
    {
      Repositories.EmprestimoRepository.LimparList();
    }

    public static List<Models.Emprestimo> ListEmprestimos()
    {
      return Repositories.EmprestimoRepository.ListEmprestimos();
    }

    public static Emprestimo? GetEmprestimo(int cod_emprestimo)
    {
      return Repositories.EmprestimoRepository.GetEmprestimo(cod_emprestimo);
    }

    public static void UpdateEmprestimo(
      int cod_emprestimo,
      Emprestimo emprestimo
    )
    {
      // Obtém o empréstimo existente no banco de dados
      Emprestimo emprestimo_existente = GetEmprestimo(cod_emprestimo);

      if (emprestimo_existente != null)
      {
        // Atualiza as propriedades do empréstimo existente com os novos valores
        emprestimo_existente.DtEmprestimo = emprestimo.DtEmprestimo;
        emprestimo_existente.DtPrevDevolucao = emprestimo.DtPrevDevolucao;
        emprestimo_existente.DtRealDevolucao = emprestimo.DtRealDevolucao;
        emprestimo_existente.CodLivro = emprestimo.CodLivro;
        emprestimo_existente.IdUsuario = emprestimo.IdUsuario;

        // Chama o método de update do repository
        Repositories.EmprestimoRepository.UpdateEmprestimo(cod_emprestimo, emprestimo_existente);
      }
    }

    public static void DeleteEmprestimo(int cod_emprestimo)
    {
      Emprestimo emprestimo = Emprestimo.GetEmprestimo(cod_emprestimo);
      if (emprestimo != null)
      {
        Repositories.EmprestimoRepository.DeleteEmprestimo(cod_emprestimo);
      }
    }

    public override string ToString()
    {
      return $"------------------------\nData do empréstimo: {DtEmprestimo}\nData prevista de devolução: {DtPrevDevolucao}\nData real de devolução: {DtRealDevolucao}\nCódigo do livro: {CodLivro}\nID do usuário: {IdUsuario}\n------------------------\n";
    }
  }
}