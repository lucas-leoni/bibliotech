using System;
using System.Collections.Generic;

namespace Controllers
{
  public class EmprestimoController
  {
    public static void LimparList()
    {
      Models.Emprestimo.LimparList();
    }
    
    public static void Emprestar(
			DateTime dt_emprestimo,
			DateTime dt_prev_devolucao,
			DateTime? dt_real_devolucao,
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

    public static Models.Emprestimo? GetEmprestimo(int cod_emprestimo)
    {
      return Models.Emprestimo.GetEmprestimo(cod_emprestimo);
    }

    public static void UpdateEmprestimo(
			int cod_emprestimo,
      Models.Emprestimo emprestimo
    )
    {
      Models.Emprestimo.UpdateEmprestimo(
				cod_emprestimo,
        emprestimo
      );
    }

    public static void DeleteEmprestimo(int cod_emprestimo)
    {
      Models.Emprestimo.DeleteEmprestimo(cod_emprestimo);
    }
  }
}