using System;
/* using MySql.Data.MySqlClient; */

namespace bibliotech;

static class Program
{
  /// <summary>
  ///  The main entry point for the application.
  /// </summary>
  [STAThread]
  static void Main()
  {
    /* TestarSelect(); */

    // To customize application configuration such as set high DPI settings or default font,
    // see https://aka.ms/applicationconfiguration.
    ApplicationConfiguration.Initialize();
    Application.Run(new Views.Login());
  }

  /* static void TestarSelect()
  {
    using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
    {
      try
      {
        conexao.Open();
        Console.WriteLine("Conexão bem-sucedida!");

        string selectQuery = "SELECT * FROM usuario";

        MySqlCommand comandoSelect = new MySqlCommand(selectQuery, conexao);

        using (MySqlDataReader leitor = comandoSelect.ExecuteReader())
        {
          while (leitor.Read())
          {
            int id = leitor.GetInt32("id_usuario");
            string nome = leitor.GetString("nome");
            string dt_nascimento = leitor.GetString("dt_nascimento");
            string endereco = leitor.GetString("endereco");
            string telefone = leitor.GetString("telefone");
            string email = leitor.GetString("email");

            MessageBox.Show(
              $"Id: {id}, Nome: {nome}, Data de nascimento: {dt_nascimento}, Endereço: {endereco}, Telefone: {telefone}, Email: {email}",
              "Tabela usuário:",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information
            );
          }
        }

        conexao.Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  } */
}