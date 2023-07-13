using System;
using System.Collections.Generic;

namespace Views
{
  public class UsuarioView
  {
    public static void AddUsuario()
    {
      string nome, dt_nascimento, endereco, telefone, email;

      Console.Write("Informe o nome do usuário: ");
      nome = Console.ReadLine();
      Console.Write("Informe a data de nascimento do usuário: ");
      dt_nascimento = Console.ReadLine();
      Console.Write("Informe o endereço do usuário: ");
      endereco = Console.ReadLine();
      Console.Write("Informe o telefone do usuário: ");
      telefone = Console.ReadLine();
      Console.Write("Informe o email do usuário: ");
      email = Console.ReadLine();

      Controllers.UsuarioController.AddUsuario(
        nome,
        dt_nascimento,
        endereco,
        telefone,
        email
      );

      Console.WriteLine("\n-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }

    public static void ListUsuarios()
    {
      List<Models.Usuario> usuarios = Controllers.UsuarioController.ListUsuarios();

      Console.WriteLine("Segue a lista de usuários: \n");
      foreach (var usuario in usuarios)
      {
        Console.WriteLine(usuario.ToString());
      }

      Console.WriteLine("-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }

    public static void UpdateUsuario()
    {
      int id_usuario;
      string nome, dt_nascimento, endereco, telefone, email;

      Console.Write("Informe o índice do usuário: ");
      id_usuario = Convert.ToInt32(Console.ReadLine());

      Console.Write("Informe o nome do usuário: ");
      nome = Console.ReadLine();
      Console.Write("Informe a data de nascimento do usuário: ");
      dt_nascimento = Console.ReadLine();
      Console.Write("Informe o endereço do usuário: ");
      endereco = Console.ReadLine();
      Console.Write("Informe o telefone do usuário: ");
      telefone = Console.ReadLine();
      Console.Write("Informe o email do usuário: ");
      email = Console.ReadLine();

      Controllers.UsuarioController.UpdateUsuario(
        id_usuario - 1,
				nome,
				dt_nascimento,
				endereco,
				telefone,
				email
      );

      Console.WriteLine("\n-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }

    public static void DeleteUsuario()
    {
      int id_usuario;

      Console.Write("Informe o índice do usuário: ");
      id_usuario = Convert.ToInt32(Console.ReadLine());

      Controllers.UsuarioController.DeleteUsuario(id_usuario - 1);

      Console.WriteLine("\n-----------------------------------------");
      Console.Write("Aperte qualquer tecla para continuar... ");
      Console.ReadKey();
      Console.Clear();
    }
  }
}