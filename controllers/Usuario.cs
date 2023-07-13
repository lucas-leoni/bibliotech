using System;
using System.Collections.Generic;

namespace Controllers
{
  public class UsuarioController
  {
    public static void AddUsuario(
      string nome,
      string dt_nascimento,
      string endereco,
      string telefone,
      string email
    )
    {
      new Models.Usuario(
        nome,
        dt_nascimento,
        endereco,
        telefone,
        email
      );
    }

    public static List<Models.Usuario> ListUsuarios()
    {
      return Models.Usuario.ListUsuarios();
    }

    public static void UpdateUsuario(
      int id_usuario,
      string nome,
      string dt_nascimento,
      string endereco,
      string telefone,
      string email
    )
    {
      Models.Usuario.UpdateUsuario(
        id_usuario,
        nome,
        dt_nascimento,
        endereco,
        telefone,
        email
      );
    }

    public static void DeleteUsuario(int id_usuario)
    {
      Models.Usuario.DeleteUsuario(id_usuario);
    }
  }
}