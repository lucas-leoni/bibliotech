using System;
using System.Collections.Generic;

namespace Views
{
  public class EmprestimoView
  {
    public static void AddEmprestimo()
    {
      string dt_emprestimo, dt_prev_devolucao, dt_real_devolucao;
      int cod_livro, id_usuario;

      Console.Write("Informe a data do empréstimo: ");
      dt_emprestimo = Console.ReadLine();
      Console.Write("Informe a data prevista de devolução: ");
      dt_prev_devolucao = Console.ReadLine();
      Console.Write("Informe a data real de devolução: ");
      dt_real_devolucao = Convert.ToString(Console.ReadLine());
      Console.Write("Informe o código do livro: ");
      cod_livro = Convert.ToInt32(Console.ReadLine());
      Console.Write("Informe o índice do usuário: ");
      id_usuario = Convert.ToInt32(Console.ReadLine());

      Controllers.EmprestimoController.AddEmprestimo(
        dt_emprestimo,
				dt_prev_devolucao,
				dt_real_devolucao,
				cod_livro,
				id_usuario
      );

      Console.WriteLine("\n-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }

    public static void ListEmprestimos()
    {
      List<Models.Emprestimo> emprestimos = Controllers.EmprestimoController.ListEmprestimos();

      Console.WriteLine("Segue a lista de empréstimos: \n");
      foreach (var emprestimo in emprestimos)
      {
        Console.WriteLine(emprestimo.ToString());
      }

      Console.WriteLine("-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }

    public static void UpdateEmprestimo()
    {
      int cod_emprestimo, cod_livro, id_usuario;
			string dt_emprestimo, dt_prev_devolucao, dt_real_devolucao;

      Console.WriteLine("Informe o código do empréstimo: ");
      cod_emprestimo = Convert.ToInt32(Console.ReadLine());

      Console.Write("Informe a data do empréstimo: ");
      dt_emprestimo = Console.ReadLine();
      Console.Write("Informe a data prevista de devolução: ");
      dt_prev_devolucao = Console.ReadLine();
      Console.Write("Informe a data real de devolução: ");
      dt_real_devolucao = Convert.ToString(Console.ReadLine());
      Console.Write("Informe o código do livro: ");
      cod_livro = Convert.ToInt32(Console.ReadLine());
      Console.Write("Informe o índice do usuário: ");
      id_usuario = Convert.ToInt32(Console.ReadLine());

      Controllers.EmprestimoController.UpdateEmprestimo(
        cod_emprestimo - 1,
        dt_emprestimo,
        dt_prev_devolucao,
        dt_real_devolucao,
        cod_livro,
				id_usuario
      );

      Console.WriteLine("\n-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }

    public static void DeleteEmprestimo()
    {
      int cod_emprestimo;

      Console.Write("Informe o código do empréstimo: ");
      cod_emprestimo = Convert.ToInt32(Console.ReadLine());

      Controllers.EmprestimoController.DeleteEmprestimo(cod_emprestimo - 1);

      Console.WriteLine("\n-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }
  }
}