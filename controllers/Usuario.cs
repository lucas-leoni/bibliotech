using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controllers
{
  public class UsuarioController
  {
    public static void LimparList()
    {
      Models.Usuario.LimparList();
    }

    public static void AddUsuario(
      string nome,
      DateTime dt_nascimento,
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

    public static Models.Usuario? GetUsuario(int id_usuario)
    {
      return Models.Usuario.GetUsuario(id_usuario);
    }

    public static void UpdateUsuario(
      int id_usuario,
      Models.Usuario usuario
    /* string nome,
    DateTime dt_nascimento,
    string endereco,
    string telefone,
    string email */
    )
    {
      // Exibir o ID obtido para verificar se está correto
      MessageBox.Show("ID Obtido: " + id_usuario);

      Models.Usuario.UpdateUsuario(
        id_usuario,
        usuario
      /* nome,
      dt_nascimento,
      endereco,
      telefone,
      email */
      );
    }

    public static void DeleteUsuario(int id_usuario)
    {
      Models.Usuario.DeleteUsuario(id_usuario);
    }
  }
}