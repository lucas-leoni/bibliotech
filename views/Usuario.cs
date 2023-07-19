using System;
using System.Windows.Forms;

namespace Views
{
  public class Usuario : UserControl
  {
    private DataGridView tabela;
    private DataGridViewButtonColumn colunaEditar;
    private DataGridViewButtonColumn colunaExcluir;
    private Panel painelPrincipal;
    public Usuario(Panel painelPrincipal)
    {
      this.painelPrincipal = painelPrincipal;

      // Inicializa a tabela
      tabela = new DataGridView();

      // Define as dimensões mínimas da tabela
      tabela.MinimumSize = new System.Drawing.Size(1070, 275);

      // Define as dimensões máximas da tabela
      tabela.MaximumSize = new System.Drawing.Size(1200, 275);

      // Calcula a posição horizontal central
      int x = (painelPrincipal.Width - tabela.Width) / 2;

      // Calcula a posição vertical central
      int y = (painelPrincipal.Height - tabela.Height) / 2;

      // Define a posição da tabela
      tabela.Location = new System.Drawing.Point(x, y);

      // Define a cor de fundo da tabela
      tabela.BackgroundColor = SystemColors.Control;

      // Configurações da tabela
      tabela.AllowUserToAddRows = false;
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
      colunaEditar.ToolTipText = "Editar Usuário";
      colunaEditar.UseColumnTextForButtonValue = true;
      colunaEditar.DefaultCellStyle.Padding = new Padding(2);
      colunaEditar.Width = 50;
      tabela.Columns.Add(colunaEditar);

      colunaExcluir = new DataGridViewButtonColumn();
      colunaExcluir.Name = "Excluir";
      colunaExcluir.HeaderText = "Excluir";
      colunaExcluir.Text = "🗑️";
      colunaExcluir.ToolTipText = "Excluir Usuário";
      colunaExcluir.UseColumnTextForButtonValue = true;
      colunaExcluir.DefaultCellStyle.Padding = new Padding(2);
      colunaExcluir.Width = 50;
      tabela.Columns.Add(colunaExcluir);

      // Ajuste automático das colunas
      tabela.AutoResizeColumns();

      // Adicionando em tela
      Controls.Add(tabela);

      GetUsuarios();

      tabela.CellContentClick += Update;
      tabela.CellContentClick += Delete;
      tabela.CellMouseEnter += tabela_CellMouseEnter;
      Load += Form_Load;
    }

    private void Form_Load(object sender, EventArgs e)
    {
      // Verifica se há usuários cadastrados no Load do formulário
      if (tabela.Rows.Count == 0)
      {
        MessageBox.Show(
          "Não há usuários cadastrados no banco de dados.",
          "Informação",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information
        );
      }
    }

    private void GetUsuarios()
    {
      Controllers.UsuarioController.LimparList();
      List<Models.Usuario> usuarios = Controllers.UsuarioController.ListUsuarios();

      // Limpa todas as linhas da tabela antes de adicionar os novos dados
      tabela.Rows.Clear();

      if (usuarios.Count > 0)
      {
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

      // Atualiza a tabela
      tabela.Refresh();
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
      row.CreateCells(tabela, id, nome, dt_nascimento.ToString("dd/MM/yyyy"), endereco, telefone, email, "✏️", "🗑️");
      tabela.Rows.Add(row);
    }

    public void Update(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && e.ColumnIndex == tabela.Columns["Editar"].Index)
      {
        // Exibe a confirmação de edição
        DialogResult result = MessageBox.Show(
          "Tem certeza de que deseja editar este usuário?",
          "Confirmação",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
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

            // Atualiza a tabela
            Refresh();

            // Exibe o MessageBox de usuário atualizado com sucesso
            MessageBox.Show(
              "Usuário editado com sucesso!",
              "Sucesso!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information
            );
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
        else
        {
          // Atualiza a tabela
          Refresh();
        }
      }
    }

    public void Delete(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && e.ColumnIndex == tabela.Columns["Excluir"].Index)
      {
        DialogResult result = MessageBox.Show(
          "Tem certeza de que deseja excluir este usuário?",
          "Confirmação",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
        {
          DataGridViewRow row = tabela.Rows[e.RowIndex];

          // Obtém o valor do campo Id
          int id_usuario = Convert.ToInt32(row.Cells["Id"].Value);

          // Subtrai 1 do id do usuário para ajustar o índice, pois o índice da LIST começa em 0
          id_usuario -= 1;

          // Obtém o objeto Usuario
          Models.Usuario usuario = Controllers.UsuarioController.GetUsuario(id_usuario);

          if (usuario != null)
          {
            // Chama o método de exclusão passando o id do usuário
            Controllers.UsuarioController.DeleteUsuario(id_usuario);

            // Remove a linha da tabela
            tabela.Rows.RemoveAt(e.RowIndex);

            // Atualiza a tabela
            Refresh();

            MessageBox.Show(
              "Usuário excluído com sucesso!",
              "Sucesso",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information
            );

            // Verifica se há usuários cadastrados
            if (tabela.Rows.Count == 0)
            {
              MessageBox.Show(
                "Não há usuários cadastrados no banco de dados.",
                "Informação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
              );
            }
          }
          else
          {
            MessageBox.Show(
              "Usuário não encontrado!",
              "Erro",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
          }
        }
      }
    }

    private void tabela_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && (e.ColumnIndex == tabela.Columns["Editar"].Index || e.ColumnIndex == tabela.Columns["Excluir"].Index))
      {
        string tooltipText = "";

        if (e.ColumnIndex == tabela.Columns["Editar"].Index)
        {
          tooltipText = "Editar Usuário";
        }
        else if (e.ColumnIndex == tabela.Columns["Excluir"].Index)
        {
          tooltipText = "Excluir Usuário";
        }

        tabela.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = tooltipText;
      }
    }

    public override void Refresh()
    {
      GetUsuarios();
    }
  }
}