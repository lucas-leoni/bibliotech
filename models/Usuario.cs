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

    public Usuario() { }

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

    public static void LimparList()
    {
      Repositories.UsuarioRepository.LimparList();
    }

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
      Usuario usuario
    )
    {
      // Obtém o usuário existente no banco de dados
      Usuario usuarioExistente = GetUsuario(id_usuario);

      if (usuarioExistente != null)
      {
        // Atualiza as propriedades do usuário existente com os novos valores
        usuarioExistente.Nome = usuario.Nome;
        usuarioExistente.DtNascimento = usuario.DtNascimento;
        usuarioExistente.Endereco = usuario.Endereco;
        usuarioExistente.Telefone = usuario.Telefone;
        usuarioExistente.Email = usuario.Email;

        // Chama o método de update do repository
        Repositories.UsuarioRepository.UpdateUsuario(id_usuario, usuarioExistente);
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
      return $"------------------------\nNome: {Nome}\nData de nascimento: {DtNascimento}\nEndereco: {Endereco}\nTelefone: {Telefone}\nEmail: {Email}\n------------------------\n";
    }
  }
}