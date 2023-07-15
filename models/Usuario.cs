using System;

namespace Models
{
  public class Usuario
  {
    public int IdUsuario { get; set; }
    public string Nome { get; set; }
    public DateTime DtNascimento { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    
    /* public Usuario() { } */
    public Usuario(
      string nome,
      DateTime dt_nascimento,
      string endereco,
      string telefone,
      string email
    )
    {
      this.Nome = nome;
      this.DtNascimento = dt_nascimento;
      this.Endereco = endereco;
      this.Telefone = telefone;
      this.Email = email;

      Repositories.UsuarioRepository.AddUsuario(this);
    }

    public void getIndex(int id_usuario)
    {
      this.IdUsuario = id_usuario;
    }

    /* public static void Sincronizar()
    {
      Repositories.UsuarioRepository.Sincronizar();
    } */

    public static List<Models.Usuario> ListUsuarios()
    {
      return Repositories.UsuarioRepository.ListUsuarios();
    }

    public static Usuario? GetUsuario(int id_usuario)
    {
      return Repositories.UsuarioRepository.GetUsuario(id_usuario);
    }

    public static void UpdateUsuario(
      int id_usuario,
      string nome,
      DateTime dt_nascimento,
      string endereco,
      string telefone,
      string email
    )
    {
      Usuario usuario = Usuario.GetUsuario(id_usuario);

      if (usuario != null)
      {
        usuario.Nome = nome;
        usuario.DtNascimento = dt_nascimento;
        usuario.Endereco = endereco;
        usuario.Telefone = telefone;
        usuario.Email = email;

        Repositories.UsuarioRepository.UpdateUsuario(id_usuario, usuario);
      }
    }

    public static void DeleteUsuario(int id_usuario)
    {
      Usuario usuario = Usuario.GetUsuario(id_usuario);
      if (usuario != null)
      {
        Repositories.UsuarioRepository.DeleteUsuario(id_usuario);
      }
    }

    public override string ToString()
    {
      return $"------------------------\n{IdUsuario + 1}º usuário\nNome: {Nome}\nData de nascimento: {DtNascimento}\nEndereco: {Endereco}\nTelefone: {Telefone}\nEmail: {Email}\n------------------------\n";
    }
  }
}