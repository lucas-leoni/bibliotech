using System;
using System.Windows.Forms;

namespace Views
{
  public class Usuario : UserControl
  {
    private DataGridView tabela;
    private DataGridViewButtonColumn colunaEditar;
    private DataGridViewButtonColumn colunaExcluir;
    public Usuario()
    {
      // Título da janela
      this.Text = "Usuários";

      // Tamanho da janela
      this.Size = new System.Drawing.Size(1100, 400);

      // Inicializa a tabela
      tabela = new DataGridView();
      tabela.Width = 1075;
      /* tabela.Dock = DockStyle.Fill; */

      // Configurações da tabela
      tabela.AllowUserToAddRows = true;
      tabela.ReadOnly = false;

      // Adicionando as colunas à tabela
      tabela.Columns.Add("Id", "Id");
      tabela.Columns["Id"].Width = 45;
      tabela.Columns["Id"].ReadOnly = true;
      tabela.Columns.Add("Nome", "Nome");
      tabela.Columns["Nome"].Width = 225;
      tabela.Columns.Add("DtNascimento", "Data de Nascimento");
      tabela.Columns["DtNascimento"].Width = 140;
      tabela.Columns.Add("Endereco", "Endereço");
      tabela.Columns["Endereco"].Width = 225;
      tabela.Columns.Add("Telefone", "Telefone");
      tabela.Columns["Telefone"].Width = 100;
      tabela.Columns.Add("Email", "Email");
      tabela.Columns["Email"].Width = 175;

      colunaEditar = new DataGridViewButtonColumn();
      colunaEditar.Name = "Editar";
      colunaEditar.HeaderText = "Editar";
      colunaEditar.Text = "✏️";
      colunaEditar.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFC107");
      colunaEditar.DefaultCellStyle.ForeColor = Color.Black;
      colunaEditar.FlatStyle = FlatStyle.Flat;
      colunaEditar.UseColumnTextForButtonValue = true;
      colunaEditar.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);
      colunaEditar.Width = 50;
      tabela.Columns.Add(colunaEditar);

      colunaExcluir = new DataGridViewButtonColumn();
      colunaExcluir.Name = "Excluir";
      colunaExcluir.HeaderText = "Excluir";
      colunaExcluir.Text = "🗑️";
      colunaExcluir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DC3545");
      colunaExcluir.DefaultCellStyle.ForeColor = Color.White;
      colunaExcluir.FlatStyle = FlatStyle.Flat;
      colunaExcluir.UseColumnTextForButtonValue = true;
      colunaExcluir.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);
      colunaExcluir.Width = 50;
      tabela.Columns.Add(colunaExcluir);

      // Ajuste automático das colunas
      tabela.AutoResizeColumns();

      // Adicionando em tela
      Controls.Add(tabela);

      GetUsuarios();

      tabela.CellContentClick += Update;
    }

    private void GetUsuarios()
    {
      Controllers.UsuarioController.LimparList();
      List<Models.Usuario> usuarios = Controllers.UsuarioController.ListUsuarios();

      foreach (var usuario in usuarios)
      {
        PopulaTabela(
          usuario.IdUsuario,
          usuario.Nome,
          usuario.DtNascimento,
          usuario.Endereco,
          usuario.Telefone,
          usuario.Email
        );
      }
    }

    public void PopulaTabela(
      int id,
      string nome,
      DateTime dt_nascimento,
      string endereco,
      string telefone,
      string email
    )
    {
      // Adiciona os dados à tabela usando uma nova linha
      DataGridViewRow row = new DataGridViewRow();
      row.CreateCells(tabela, id, nome, dt_nascimento, endereco, telefone, email, "✏️", "🗑️");
      tabela.Rows.Add(row);
    }

    public void Update(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && e.ColumnIndex == tabela.Columns["Editar"].Index)
      {
        DataGridViewRow row = tabela.Rows[e.RowIndex];

        // Obtém o valor do campo Id
        int id_usuario = Convert.ToInt32(row.Cells["Id"].Value);

        // Subtrai 1 do id do usuário para ajustar o índice, pois o índice da LIST começa em 0
        id_usuario -= 1;

        // Obtém os valores das outras colunas
        string nome = row.Cells["Nome"].Value.ToString();
        DateTime dt_nascimento = Convert.ToDateTime(row.Cells["DtNascimento"].Value);
        string endereco = row.Cells["Endereco"].Value.ToString();
        string telefone = row.Cells["Telefone"].Value.ToString();
        string email = row.Cells["Email"].Value.ToString();

        // Obtém o objeto Usuario
        Models.Usuario usuario = Controllers.UsuarioController.GetUsuario(id_usuario);

        if (usuario != null)
        {
          // Atualiza as propriedades do objeto usuario existente
          usuario.Nome = nome;
          usuario.DtNascimento = dt_nascimento;
          usuario.Endereco = endereco;
          usuario.Telefone = telefone;
          usuario.Email = email;

          // Chama o método de update passando o id e o objeto usuario
          Controllers.UsuarioController.UpdateUsuario(id_usuario, usuario);

          // Exibe o MessageBox de usuário atualizado com sucesso
          MessageBox.Show(
            "Usuário atualizado com sucesso!",
            "Sucesso!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
          );

          // Atualiza a tabela
          tabela.Refresh();
        }
        else
        {
          MessageBox.Show(
            "Usuário não encontrado!",
            "Erro!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
          );
        }
      }
    }

    public override void Refresh()
    {
      GetUsuarios();
    }
  }
}