using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
/* using System.Collections.Generic; */

namespace Views
{
  public class Usuario : Form
  {
    private Form parent;
    private DataGridView tabela;
    private DataGridViewButtonColumn colunaEditar;
    private DataGridViewButtonColumn colunaExcluir;
    public Usuario(Form parent)
    {
      this.parent = parent;

      // Título da janela
      this.Text = "Usuários";

      // Tamanho da janela
      this.Size = new System.Drawing.Size(1100, 400);

      // Inicializa a tabela
      tabela = new DataGridView();
      tabela.Width = 1075;
      /* tabela.Dock = DockStyle.Fill; */

      // Configurações da tabela
      tabela.AllowUserToAddRows = false;
      tabela.ReadOnly = true;

      // Adicionando as colunas à tabela
      tabela.Columns.Add("Id", "Id");
      tabela.Columns["Id"].Width = 45;
      tabela.Columns.Add("Nome", "Nome");
      tabela.Columns["Nome"].Width = 225;
      tabela.Columns.Add("Data de Nascimento", "Data de Nascimento");
      tabela.Columns["Data de Nascimento"].Width = 140;
      tabela.Columns.Add("Endereço", "Endereço");
      tabela.Columns["Endereço"].Width = 225;
      tabela.Columns.Add("Telefone", "Telefone");
      tabela.Columns["Telefone"].Width = 100;
      tabela.Columns.Add("Email", "Email");
      tabela.Columns["Email"].Width = 175;

      colunaEditar = new DataGridViewButtonColumn();
      colunaEditar.HeaderText = "Editar";
      colunaEditar.Text = "✏️";
      colunaEditar.UseColumnTextForButtonValue = true;
      colunaEditar.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);
      colunaEditar.Width = 50;
      tabela.Columns.Add(colunaEditar);

      colunaExcluir = new DataGridViewButtonColumn();
      colunaExcluir.HeaderText = "Excluir";
      colunaExcluir.Text = "🗑️";
      colunaExcluir.UseColumnTextForButtonValue = true;
      colunaExcluir.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);
      colunaExcluir.Width = 50;
      tabela.Columns.Add(colunaExcluir);

      // Ajuste automático das colunas
      tabela.AutoResizeColumns();

      // Adicionando em tela
      Controls.Add(tabela);

      Select();

      FormClosed += AoFechar;
    }

    public void Select()
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco de dados
          conexao.Open();

          // Consulta SQL para recuperar os registros da tabela de usuários
          string selectQuery = "SELECT * FROM usuario";

          // Cria um comando MySqlCommand com a consulta SQL e a conexão
          MySqlCommand comandoSelect = new MySqlCommand(selectQuery, conexao);

          // Executa o comando e obtém um leitor de dados
          using (MySqlDataReader leitor = comandoSelect.ExecuteReader())
          {
            // Lê cada registro retornado pelo leitor de dados
            while (leitor.Read())
            {
              // Obtém os valores das colunas e os converte para as devidas tipagens
              int id = leitor.GetInt32("id_usuario");
              string nome = leitor.GetString("nome");
              DateTime dt_nascimento = leitor.GetDateTime("dt_nascimento");
              string endereco = leitor.GetString("endereco");
              string telefone = leitor.GetString("telefone");
              string email = leitor.GetString("email");

              // Adiciona os dados à tabela usando uma nova linha
              DataGridViewRow row = new DataGridViewRow();
              row.CreateCells(tabela, id, nome, dt_nascimento, endereco, telefone, email, "✏️", "🗑️");
              tabela.Rows.Add(row);
            }
          }

          conexao.Close();
        }

        catch (Exception ex)
        {
          MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void AoFechar(object sender, FormClosedEventArgs e)
    {
      this.parent.Show();
    }
  }
}