/* using System;
using System.Collections.Generic;

namespace Repositories
{
  public class UsuarioRepository
  {
    static List<Models.Usuario> usuarios = new List<Models.Usuario>();

    public static void AddUsuario(Models.Usuario usuario)
    {
      usuarios.Add(usuario);
      int id_usuario = usuarios.IndexOf(usuario);
      usuario.getIndex(id_usuario);
    }

    public static List<Models.Usuario> ListUsuarios()
    {
      return usuarios;
    }

    public static Models.Usuario? GetUsuario(int id_usuario)
    {
      if (id_usuario < 0 || id_usuario >= usuarios.Count)
      {
        return null;
      }
      else
      {
        return usuarios[id_usuario];
      }
    }

    public static void UpdateUsuario(int id_usuario, Models.Usuario usuario)
    {
      usuarios[id_usuario] = usuario;
    }

    public static void DeleteUsuario(int id_usuario)
    {
      usuarios.RemoveAt(id_usuario);
    }
  }
} */