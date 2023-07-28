using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Views
{
  public class Emprestimo : UserControl
  {
    private DataGridView tabela;
    private bool isTableCentered = false;
    private int tabelaX;
    private int tabelaY;
    private DataGridViewButtonColumn colunaEditar;
    private DataGridViewButtonColumn colunaExcluir;
    private DataGridViewButtonColumn colunaDevolver;
    private Panel formConteiner;
    private Label lblLivro;
    private TextBox inpLivro;
    private Label lblUsuario;
    private TextBox inpUsuario;
    private Label lblDtEmprestimo;
    private DateTimePicker inpDtEmprestimo;
    private Label lblDtPrevDevolucao;
    private DateTimePicker inpDtPrevDevolucao;
    private Button btnLimpar;
    private Button btnAdd;

    public Emprestimo()
    {
      // Inicializa a tabela
      tabela = new DataGridView();

      // Define as dimensões mínimas da tabela
      tabela.MinimumSize = new System.Drawing.Size(1130, 275);

      // Ajuste automático das colunas
      tabela.AutoResizeColumns();

      // Define as dimensões máximas da tabela
      tabela.MaximumSize = new System.Drawing.Size(1200, 275);

      // Define a cor de fundo da tabela
      tabela.BackgroundColor = SystemColors.Control;

      // Configurações da tabela
      tabela.AllowUserToAddRows = false;
      tabela.ReadOnly = false;

      // Adicionando as colunas à tabela
      tabela.Columns.Add("Id", "Id");
      tabela.Columns["Id"].Width = 46;
      tabela.Columns["Id"].ReadOnly = true;
      tabela.Columns.Add("DtEmprestimo", "Data de Empréstimo");
      tabela.Columns["DtEmprestimo"].Width = 140;
      tabela.Columns["DtEmprestimo"].ReadOnly = true;
      tabela.Columns.Add("DtPrevDevolucao", "Data Prevista Devolução");
      tabela.Columns["DtPrevDevolucao"].Width = 160;
      tabela.Columns["DtPrevDevolucao"].ReadOnly = true;
      tabela.Columns.Add("DtRealDevolucao", "Data Real Devolução");
      tabela.Columns["DtRealDevolucao"].Width = 140;
      tabela.Columns["DtRealDevolucao"].ReadOnly = true;
      tabela.Columns.Add("Livro", "Livro");
      tabela.Columns["Livro"].Width = 212;
      tabela.Columns.Add("Usuario", "Usuário");
      tabela.Columns["Usuario"].Width = 212;

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

      colunaDevolver = new DataGridViewButtonColumn();
      colunaDevolver.Name = "Devolver";
      colunaDevolver.HeaderText = "Devolver";
      colunaDevolver.Text = "✔️";
      colunaDevolver.ToolTipText = "Devolver Livro";
      colunaDevolver.UseColumnTextForButtonValue = true;
      colunaDevolver.DefaultCellStyle.Padding = new Padding(2);
      colunaDevolver.Width = 60;
      tabela.Columns.Add(colunaDevolver);

      formConteiner = new Panel();
      formConteiner.AutoSize = true;

      lblLivro = new Label();
      inpLivro = new TextBox();
      lblUsuario = new Label();
      inpUsuario = new TextBox();
      lblDtEmprestimo = new Label();
      inpDtEmprestimo = new DateTimePicker();
      lblDtPrevDevolucao = new Label();
      inpDtPrevDevolucao = new DateTimePicker();
      btnLimpar = new Button();
      btnAdd = new Button();

      int margin_r = 51;
      int margin_b = 23;

      lblLivro.Text = "Código do Livro:";
      lblLivro.ForeColor = Color.White;
      lblLivro.Location = new System.Drawing.Point(0, 0);

      inpLivro.MaxLength = 11;
      inpLivro.Width = 110;
      inpLivro.Location = new System.Drawing.Point(lblLivro.Location.X, margin_b);

      lblUsuario.Text = "Código do Usuário:";
      lblUsuario.ForeColor = Color.White;
      lblUsuario.Width = 110;
      lblUsuario.Location = new System.Drawing.Point(inpLivro.Right + margin_r, 0);

      inpUsuario.MaxLength = 11;
      inpUsuario.Width = 110;
      inpUsuario.Location = new System.Drawing.Point(lblUsuario.Location.X, margin_b);

      lblDtEmprestimo.Text = "Data de Empréstimo:";
      lblDtEmprestimo.Width = 140;
      lblDtEmprestimo.ForeColor = Color.White;
      lblDtEmprestimo.Location = new System.Drawing.Point(inpUsuario.Right + margin_r, 0);

      inpDtEmprestimo.Format = DateTimePickerFormat.Custom;
      inpDtEmprestimo.CustomFormat = "dd/MM/yyyy |dddd";
      inpDtEmprestimo.Width = 180;
      inpDtEmprestimo.Enabled = false;
      inpDtEmprestimo.Location = new System.Drawing.Point(lblDtEmprestimo.Location.X, margin_b);

      lblDtPrevDevolucao.Text = "Data Prevista Devolução:";
      lblDtPrevDevolucao.Width = 140;
      lblDtPrevDevolucao.ForeColor = Color.White;
      lblDtPrevDevolucao.Location = new System.Drawing.Point(inpDtEmprestimo.Right + margin_r, 0);

      inpDtPrevDevolucao.Format = DateTimePickerFormat.Custom;
      inpDtPrevDevolucao.CustomFormat = "dd/MM/yyyy |dddd";
      inpDtPrevDevolucao.Width = 180;
      inpDtPrevDevolucao.Enabled = false;
      inpDtPrevDevolucao.Value = inpDtEmprestimo.Value.AddDays(7);
      inpDtPrevDevolucao.Location = new System.Drawing.Point(lblDtPrevDevolucao.Location.X, margin_b);

      btnLimpar.Text = "Limpar";
      btnLimpar.Location = new System.Drawing.Point(0, 75);
      btnLimpar.Click += btnLimpar_Click;

      btnAdd.Text = "Emprestar";
      int btnAddX = inpDtPrevDevolucao.Left + inpDtPrevDevolucao.Width - btnAdd.Width;
      btnAdd.Location = new System.Drawing.Point(btnAddX, 75);
      btnAdd.Click += btnAdd_Click;

      // Adicionando em tela
      Controls.Add(tabela);
      formConteiner.Controls.Add(lblLivro);
      formConteiner.Controls.Add(inpLivro);
      formConteiner.Controls.Add(lblUsuario);
      formConteiner.Controls.Add(inpUsuario);
      formConteiner.Controls.Add(lblDtEmprestimo);
      formConteiner.Controls.Add(inpDtEmprestimo);
      formConteiner.Controls.Add(lblDtPrevDevolucao);
      formConteiner.Controls.Add(inpDtPrevDevolucao);
      formConteiner.Controls.Add(btnLimpar);
      formConteiner.Controls.Add(btnAdd);
      Controls.Add(formConteiner);

      GetEmprestimos();

      tabela.CellContentClick += Update;
      tabela.CellContentClick += Delete;
      tabela.CellContentClick += Devolver;
      tabela.CellMouseEnter += tabela_CellMouseEnter;

      // Adiciona um evento para validação do campo livro
      inpLivro.KeyPress += inpLivro_KeyPress;

      // Adiciona um evento para validação do campo usuário
      inpUsuario.KeyPress += inpUsuario_KeyPress;

      Load += Form_Load;
    }

    private void Form_Load(object sender, EventArgs e)
    {
      // Verifica se o UserControl tem um Panel pai
      if (this.Parent is Panel painelGeral && !isTableCentered)
      {
        // Calcula a posição horizontal central para a tabela
        tabelaX = (painelGeral.Width - tabela.Width) / 2;

        // Calcula a posição vertical central para a tabela
        tabelaY = (painelGeral.Height - tabela.Height) / 2;

        // Atualiza a posição da tabela
        tabela.Location = new System.Drawing.Point(tabelaX, tabelaY);

        int formX = (painelGeral.Width - formConteiner.Width) / 2; ;
        int alturaDisponivelAbaixoTabela = painelGeral.Height - tabela.Bottom;
        int formY = (alturaDisponivelAbaixoTabela - formConteiner.Height) / 2;
        formY += tabela.Bottom;
        formConteiner.Location = new Point(formX, formY);

        // Define a flag como true para que a centralização só ocorra uma vez
        isTableCentered = true;
      }

      // Verifica se há empréstimos cadastrados no Load do formulário
      if (tabela.Rows.Count == 0)
      {
        MessageBox.Show(
          "Não há empréstimos cadastrados no banco de dados.",
          "Informação",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information
        );
      }
    }

    private void GetEmprestimos()
    {
      Controllers.EmprestimoController.LimparList();
      List<Models.Emprestimo> emprestimos = Controllers.EmprestimoController.ListEmprestimos();

      // Limpa todas as linhas da tabela antes de adicionar os novos dados
      tabela.Rows.Clear();

      if (emprestimos.Count > 0)
      {
        foreach (var emprestimo in emprestimos)
        {
          PopulaTabela(
            emprestimo.CodEmprestimo,
            emprestimo.DtEmprestimo,
            emprestimo.DtPrevDevolucao,
            emprestimo.DtRealDevolucao,
            emprestimo.CodLivro,
            emprestimo.IdUsuario
          );
        }
      }

      // Atualiza a tabela
      tabela.Refresh();
    }

    public void PopulaTabela(
      int id,
      DateTime dt_emprestimo,
      DateTime dt_prev_devolucao,
      DateTime? dt_real_devolucao,
      int cod_livro,
      int id_usuario
    )
    {
      // Adiciona os dados à tabela usando uma nova linha
      DataGridViewRow row = new DataGridViewRow();
      row.CreateCells(
        tabela,
        id,
        dt_emprestimo.ToString("dd/MM/yyyy"),
        dt_prev_devolucao.ToString("dd/MM/yyyy"),
        // Verifica se dt_real_devolucao é nula antes de exibir no DataGridView
        dt_real_devolucao.HasValue ? dt_real_devolucao.Value.ToString("dd/MM/yyyy") : "",
        cod_livro,
        id_usuario,
        "✏️",
        "🗑️",
        "✔️"
      );
      tabela.Rows.Add(row);
    }

    private void tabela_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      tabela.Cursor = Cursors.Default;

      if (e.RowIndex >= 0 && (e.ColumnIndex == tabela.Columns["Editar"].Index ||
      e.ColumnIndex == tabela.Columns["Excluir"].Index ||
      e.ColumnIndex == tabela.Columns["Devolver"].Index))
      {
        string tooltipText = "";

        if (e.ColumnIndex == tabela.Columns["Editar"].Index)
        {
          DataGridViewRow row = tabela.Rows[e.RowIndex];
          if (!string.IsNullOrEmpty(row.Cells["DtRealDevolucao"].Value.ToString()))
          {
            tabela.Cursor = Cursors.No;
            tooltipText = "🚫";
          }
          else
          {
            tooltipText = "Editar Empréstimo";
            tabela.Cursor = Cursors.Default;
          }
        }
        else if (e.ColumnIndex == tabela.Columns["Excluir"].Index)
        {
          tooltipText = "Excluir Empréstimo";
          tabela.Cursor = Cursors.Default;
        }
        else if (e.ColumnIndex == tabela.Columns["Devolver"].Index)
        {
          DataGridViewRow row = tabela.Rows[e.RowIndex];

          if (!string.IsNullOrEmpty(row.Cells["DtRealDevolucao"].Value.ToString()))
          {
            tabela.Cursor = Cursors.No;
            tooltipText = "🚫";
          }
          else
          {
            tooltipText = "Devolver Livro";
            tabela.Cursor = Cursors.Default;
          }
        }

        tabela.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = tooltipText;
      }
    }

    private void inpLivro_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Verifica se a tecla pressionada é Backspace, Tab ou Enter
      if (char.IsControl(e.KeyChar))
      {
        return;
      }

      // Verifica se o comprimento máximo foi atingido (11 caracteres)
      if (inpLivro.Text.Length >= 11)
      {
        e.Handled = true;
      }

      // Utiliza a expressão regular para permitir apenas números
      string allowedCharsPattern = "^[0-9]+$";
      if (!Regex.IsMatch(e.KeyChar.ToString(), allowedCharsPattern))
      {
        e.Handled = true;
      }
    }

    public bool LivroValido(string livro)
    {
      // Verifica se o livro não está vazio ou preenchido apenas com espaços em branco
      if (string.IsNullOrWhiteSpace(livro))
      {
        return false;
      }

      // Define o tamanho mínimo do campo livro para 1 caractere
      int tamanhoMin = 1;

      // Verifica se o livro possui o tamanho mínimo exigido
      if (livro.Length < tamanhoMin)
      {
        return false;
      }

      // Expressão regular para verificar se o livro contém apenas números
      Regex regex = new Regex("^[0-9]+$");

      // Verifica se o livro corresponde à expressão regular
      if (!regex.IsMatch(livro))
      {
        return false;
      }

      return true;
    }

    private void inpUsuario_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Verifica se a tecla pressionada é Backspace, Tab ou Enter
      if (char.IsControl(e.KeyChar))
      {
        return;
      }

      // Verifica se o comprimento máximo foi atingido (11 caracteres)
      if (inpUsuario.Text.Length >= 11)
      {
        e.Handled = true;
      }

      // Utiliza a expressão regular para permitir apenas números
      string allowedCharsPattern = "^[0-9]+$";
      if (!Regex.IsMatch(e.KeyChar.ToString(), allowedCharsPattern))
      {
        e.Handled = true;
      }
    }

    public bool UsuarioValido(string usuario)
    {
      // Verifica se o usuario não está vazio ou preenchido apenas com espaços em branco
      if (string.IsNullOrWhiteSpace(usuario))
      {
        return false;
      }

      // Define o tamanho mínimo do campo usuario para 1 caractere
      int tamanhoMin = 1;

      // Verifica se o usuario possui o tamanho mínimo exigido
      if (usuario.Length < tamanhoMin)
      {
        return false;
      }

      // Expressão regular para verificar se o usuario contém apenas números
      Regex regex = new Regex("^[0-9]+$");

      // Verifica se o usuario corresponde à expressão regular
      if (!regex.IsMatch(usuario))
      {
        return false;
      }

      return true;
    }

    private bool ValidarCampos()
    {
      string livro = inpLivro.Text;
      string usuario = inpUsuario.Text;

      if (!LivroValido(livro))
      {
        MessageBox.Show(
          "Código do livro inválido! Insira um código com no mínimo 1 e no máximo 11 caracteres numéricos.",
          "Erro",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        // Limpa o campo livro
        inpLivro.Text = string.Empty;

        // Define o foco para o campo livro
        inpLivro.Focus();

        return false;
      }
      if (!UsuarioValido(usuario))
      {
        MessageBox.Show(
          "Código do usuário inválido! Insira um código com no mínimo 1 e no máximo 11 caracteres numéricos.",
          "Erro",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        // Limpa o campo usuário
        inpUsuario.Text = string.Empty;

        // Define o foco para o campo usuário
        inpUsuario.Focus();

        return false;
      }

      // Se todas as validações passaram, retorna true para indicar que todos os campos são válidos
      return true;
    }

    public void btnLimpar_Click(object sender, EventArgs e)
    {
      Limpar();
    }

    public void Limpar()
    {
      // Limpando o texto dos inputs
      inpLivro.Clear();
      inpUsuario.Clear();
    }

    public void btnAdd_Click(object sender, EventArgs e)
    {
      Emprestar();
    }

    public void Emprestar()
    {
      if (ValidarCampos())
      {
        // Obtém os valores do form
        DateTime dt_emprestimo = DateTime.Today;
        /* DateTime dt_emprestimo = inpDtEmprestimo.Value; */
        DateTime dt_prev_devolucao = dt_emprestimo.AddDays(7);
        /* DateTime dt_prev_devolucao = inpDtPrevDevolucao.Value; */
        DateTime? dt_real_devolucao = null;
        int cod_livro = Convert.ToInt32(inpLivro.Text);
        int id_usuario = Convert.ToInt32(inpUsuario.Text);

        // Constrói um objeto Emprestimo
        Controllers.EmprestimoController.Emprestar(
          dt_emprestimo,
          dt_prev_devolucao,
          dt_real_devolucao,
          cod_livro,
          id_usuario
        );

        // Atualiza a tabela
        Refresh();

        // Limpando o texto dos inputs
        Limpar();

        // Exibe o MessageBox de livro emprestado com sucesso
        MessageBox.Show(
          "Livro emprestado com sucesso!",
          "Sucesso!",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information
        );
      }
    }

    public void Update(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && e.ColumnIndex == tabela.Columns["Editar"].Index)
      {
        DataGridViewRow row = tabela.Rows[e.RowIndex];

        if (!string.IsNullOrEmpty(row.Cells["DtRealDevolucao"].Value.ToString()))
        {
          tabela.Cursor = Cursors.Default;

          // Atualiza a tabela
          Refresh();

          MessageBox.Show(
            "Este livro já foi devolvido, não é mais possível editar este empréstimo!",
            "Aviso!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
          );
        }
        else
        {
          // Exibe a confirmação de edição
          DialogResult result = MessageBox.Show(
            "Tem certeza de que deseja editar este empréstimo?",
            "Confirmação",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
          );

          if (result == DialogResult.Yes)
          {
            // Obtém o valor do campo Id
            int cod_emprestimo = Convert.ToInt32(row.Cells["Id"].Value);

            // Obtém os valores das outras colunas
            DateTime dt_emprestimo = Convert.ToDateTime(row.Cells["DtEmprestimo"].Value);
            DateTime dt_prev_devolucao = Convert.ToDateTime(row.Cells["DtPrevDevolucao"].Value);

            // Verifica se a célula "DtRealDevolucao" é uma string vazia e define o valor apropriado
            DateTime? dt_real_devolucao = null;
            if (!string.IsNullOrEmpty(row.Cells["DtRealDevolucao"].Value.ToString()))
            {
              dt_real_devolucao = Convert.ToDateTime(row.Cells["DtRealDevolucao"].Value);
            }

            int cod_livro = Convert.ToInt32(row.Cells["Livro"].Value);
            int id_usuario = Convert.ToInt32(row.Cells["Usuario"].Value);

            // Obtém o objeto Emprestimo
            Models.Emprestimo emprestimo = Controllers.EmprestimoController.GetEmprestimo(cod_emprestimo);

            if (emprestimo != null)
            {
              // Atualiza as propriedades do objeto emprestimo existente
              emprestimo.DtEmprestimo = dt_emprestimo;
              emprestimo.DtPrevDevolucao = dt_prev_devolucao;
              emprestimo.DtRealDevolucao = dt_real_devolucao;
              emprestimo.CodLivro = cod_livro;
              emprestimo.IdUsuario = id_usuario;

              // Chama o método de update passando o id e o objeto emprestimo
              Controllers.EmprestimoController.UpdateEmprestimo(cod_emprestimo, emprestimo);

              // Atualiza a tabela
              Refresh();

              // Exibe o MessageBox de empréstimo editado com sucesso
              MessageBox.Show(
                "Empréstimo editado com sucesso!",
                "Sucesso!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
              );
            }
            else
            {
              MessageBox.Show(
                "Empréstimo não encontrado!",
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
    }

    public void Devolver(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && e.ColumnIndex == tabela.Columns["Devolver"].Index)
      {
        DataGridViewRow row = tabela.Rows[e.RowIndex];

        if (!string.IsNullOrEmpty(row.Cells["DtRealDevolucao"].Value.ToString()))
        {
          tabela.Cursor = Cursors.Default;

          // Atualiza a tabela
          Refresh();
          
          MessageBox.Show(
            "Este livro já foi devolvido!",
            "Aviso!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
          );
        }
        else
        {
          // Exibe a confirmação de devolução
          DialogResult result = MessageBox.Show(
            "Tem certeza de que deseja devolver este livro?",
            "Confirmação",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
          );

          if (result == DialogResult.Yes)
          {
            // Obtém o valor do campo Id
            int cod_emprestimo = Convert.ToInt32(row.Cells["Id"].Value);

            // Obtém os valores das outras colunas
            DateTime dt_emprestimo = Convert.ToDateTime(row.Cells["DtEmprestimo"].Value);
            DateTime dt_prev_devolucao = Convert.ToDateTime(row.Cells["DtPrevDevolucao"].Value);
            DateTime dt_real_devolucao = DateTime.Today;
            int cod_livro = Convert.ToInt32(row.Cells["Livro"].Value);
            int id_usuario = Convert.ToInt32(row.Cells["Usuario"].Value);

            // Obtém o objeto Emprestimo
            Models.Emprestimo emprestimo = Controllers.EmprestimoController.GetEmprestimo(cod_emprestimo);

            if (emprestimo != null)
            {
              // Atualiza as propriedades do objeto emprestimo existente
              emprestimo.DtEmprestimo = dt_emprestimo;
              emprestimo.DtPrevDevolucao = dt_prev_devolucao;
              emprestimo.DtRealDevolucao = dt_real_devolucao;
              emprestimo.CodLivro = cod_livro;
              emprestimo.IdUsuario = id_usuario;

              // Chama o método de update passando o id e o objeto emprestimo
              Controllers.EmprestimoController.UpdateEmprestimo(cod_emprestimo, emprestimo);

              // Atualiza a tabela
              Refresh();

              // Exibe o MessageBox de livro devolvido com sucesso
              MessageBox.Show(
                "Livro devolvido com sucesso!",
                "Sucesso!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
              );
            }
            else
            {
              MessageBox.Show(
                "Empréstimo não encontrado!",
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
    }

    public void Delete(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && e.ColumnIndex == tabela.Columns["Excluir"].Index)
      {
        DialogResult result = MessageBox.Show(
          "Tem certeza de que deseja excluir este empréstimo?",
          "Confirmação",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
        {
          DataGridViewRow row = tabela.Rows[e.RowIndex];

          // Obtém o valor do campo Id
          int cod_emprestimo = Convert.ToInt32(row.Cells["Id"].Value);

          // Obtém o objeto Emprestimo
          Models.Emprestimo emprestimo = Controllers.EmprestimoController.GetEmprestimo(cod_emprestimo);

          if (emprestimo != null)
          {
            // Chama o método de exclusão passando o código do emprestimo
            Controllers.EmprestimoController.DeleteEmprestimo(cod_emprestimo);

            // Remove a linha da tabela
            tabela.Rows.RemoveAt(e.RowIndex);

            // Atualiza a tabela
            Refresh();

            MessageBox.Show(
              "Empréstimo excluído com sucesso!",
              "Sucesso",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information
            );

            // Verifica se há empréstimos cadastrados
            if (tabela.Rows.Count == 0)
            {
              MessageBox.Show(
                "Não há empréstimos cadastrados no banco de dados.",
                "Informação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
              );
            }
          }
          else
          {
            MessageBox.Show(
              "Empréstimo não encontrado!",
              "Erro",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
          }
        }
      }
    }

    public override void Refresh()
    {
      GetEmprestimos();
    }
  }
}
