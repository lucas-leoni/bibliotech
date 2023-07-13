using System;
using System.Collections.Generic;

namespace Repositories
{
  public class EmprestimoRepository
  {
    static List<Models.Emprestimo> emprestimos = new List<Models.Emprestimo>();

    public static void AddEmprestimo(Models.Emprestimo emprestimo)
    {
      emprestimos.Add(emprestimo);
      int cod_emprestimo = emprestimos.IndexOf(emprestimo);
      emprestimo.getIndex(cod_emprestimo);
    }

    public static List<Models.Emprestimo> ListEmprestimos()
    {
      return emprestimos;
    }

    public static Models.Emprestimo? GetEmprestimo(int cod_emprestimo)
    {
      if (cod_emprestimo < 0 || cod_emprestimo >= emprestimos.Count)
      {
        return null;
      }
      else
      {
        return emprestimos[cod_emprestimo];
      }
    }

    public static void UpdateEmprestimo(int cod_emprestimo, Models.Emprestimo emprestimo)
    {
      emprestimos[cod_emprestimo] = emprestimo;
    }

    public static void DeleteEmprestimo(int cod_emprestimo)
    {
      emprestimos.RemoveAt(cod_emprestimo);
    }

  }
}