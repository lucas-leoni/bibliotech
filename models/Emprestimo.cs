using System;

namespace Models
{
  public class Emprestimo
  {
    public int CodEmprestimo { get; set; }
    public string DtEmprestimo { get; set; }
    public string DtPrevDevolucao { get; set; }
    public string DtRealDevolucao { get; set; }
    public int CodLivro { get; set; }
    public int IdUsuario { get; set; }

    public Emprestimo(
			string dt_emprestimo,
			string dt_prev_devolucao,
			string dt_real_devolucao,
			int cod_livro,
			int id_usuario
    )
    {
      this.DtEmprestimo = dt_emprestimo;
      this.DtPrevDevolucao = dt_prev_devolucao;
      this.DtRealDevolucao = dt_real_devolucao;
      this.CodLivro = cod_livro;
      this.IdUsuario = id_usuario;

      Repositories.EmprestimoRepository.AddEmprestimo(this);
    }

    public void getIndex(int cod_emprestimo)
    {
      this.CodEmprestimo = cod_emprestimo;
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
			string dt_emprestimo,
			string dt_prev_devolucao,
			string dt_real_devolucao,
			int cod_livro,
			int id_usuario
    )
    {
      Emprestimo emprestimo = Emprestimo.GetEmprestimo(cod_emprestimo);
      if (emprestimo != null)
      {
        emprestimo.DtEmprestimo = dt_emprestimo;
        emprestimo.DtPrevDevolucao = dt_prev_devolucao;
        emprestimo.DtRealDevolucao = dt_real_devolucao;
        emprestimo.CodLivro = cod_livro;
        emprestimo.IdUsuario = id_usuario;

        Repositories.EmprestimoRepository.UpdateEmprestimo(cod_emprestimo, emprestimo);
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
      return $"------------------------\n{CodEmprestimo + 1}º empréstimo\nData do empréstimo: {DtEmprestimo}\nData prevista de devolução: {DtPrevDevolucao}\nData real de devolução: {DtRealDevolucao}\nCódigo do livro: {CodLivro}\nID do usuário: {IdUsuario}\n------------------------\n";
    }
  }
}