using System;
using System.Collections.Generic;

namespace Controllers
{
  public class EmprestimoController
  {
    public static void AddEmprestimo(
			string dt_emprestimo,
			string dt_prev_devolucao,
			string dt_real_devolucao,
			int cod_livro,
			int id_usuario
    )
    {
      new Models.Emprestimo(
				dt_emprestimo,
				dt_prev_devolucao,
				dt_real_devolucao,
				cod_livro,
				id_usuario
      );
    }

    public static List<Models.Emprestimo> ListEmprestimos()
    {
      return Models.Emprestimo.ListEmprestimos();
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
      Models.Emprestimo.UpdateEmprestimo(
				cod_emprestimo,
				dt_emprestimo,
				dt_prev_devolucao,
				dt_real_devolucao,
				cod_livro,
				id_usuario
      );
    }

    public static void DeleteEmprestimo(int cod_emprestimo)
    {
      Models.Emprestimo.DeleteEmprestimo(cod_emprestimo);
    }
  }
}