using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Views
{
  public class Usuario : UserControl
  {
    private DataGridView tabela;
    private bool isTableCentered = false;
    private int tabelaX;
    private int tabelaY;
    private DataGridViewButtonColumn colunaEditar;
    private DataGridViewButtonColumn colunaExcluir;
    private Panel formConteiner;
    private Label lblNome;
    private TextBox inpNome;
    private Label lblDtNascimento;
    private DateTimePicker inpDtNascimento;
    private Label lblEndereco;
    private TextBox inpEndereco;
    private Label lblTelefone;
    private MaskedTextBox inpTelefone;
    private Label lblEmail;
    private TextBox inpEmail;
    private Button btnLimpar;
    private Button btnAdd;

    public Usuario()
    {
      // Inicializa a tabela
      tabela = new DataGridView();

      // Define as dimensões mínimas da tabela
      tabela.MinimumSize = new System.Drawing.Size(1070, 275);

      // Define as dimensões máximas da tabela
      tabela.MaximumSize = new System.Drawing.Size(1200, 275);

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

      formConteiner = new Panel();
      formConteiner.AutoSize = true;

      lblNome = new Label();
      inpNome = new TextBox();
      lblDtNascimento = new Label();
      inpDtNascimento = new DateTimePicker();
      lblEndereco = new Label();
      inpEndereco = new TextBox();
      lblTelefone = new Label();
      inpTelefone = new MaskedTextBox();
      lblEmail = new Label();
      inpEmail = new TextBox();
      btnAdd = new Button();
      btnLimpar = new Button();

      int margin_r = 51;
      int margin_b = 23;

      lblNome.Text = "Nome:";
      lblNome.Location = new System.Drawing.Point(0, 0);

      inpNome.MaxLength = 120;
      inpNome.Width = 225;
      inpNome.Location = new System.Drawing.Point(lblNome.Location.X, margin_b);

      lblDtNascimento.Text = "Data de Nascimento:";
      lblDtNascimento.Width = 140;
      lblDtNascimento.Location = new System.Drawing.Point(inpNome.Right + margin_r, 0);

      inpDtNascimento.Format = DateTimePickerFormat.Custom;
      inpDtNascimento.CustomFormat = "dd/MM/yyyy";
      inpDtNascimento.Width = 140;
      inpDtNascimento.Location = new System.Drawing.Point(lblDtNascimento.Location.X, margin_b);

      lblEndereco.Text = "Endereço:";
      lblEndereco.Location = new System.Drawing.Point(inpDtNascimento.Right + margin_r, 0);

      inpEndereco.MaxLength = 120;
      inpEndereco.Width = 225;
      inpEndereco.Location = new System.Drawing.Point(lblEndereco.Location.X, margin_b);

      lblTelefone.Text = "Telefone:";
      lblTelefone.Location = new System.Drawing.Point(inpEndereco.Right + margin_r, 0);

      inpTelefone.Width = 100;
      inpTelefone.Location = new System.Drawing.Point(lblTelefone.Location.X, margin_b);

      // Define a máscara inicial para telefone fixo
      SetTelefoneMask("(00) 0000-0000");

      lblEmail.Text = "Email:";
      lblEmail.Location = new System.Drawing.Point(inpTelefone.Right + margin_r, 0);

      inpEmail.MaxLength = 50;
      inpEmail.Width = 175;
      inpEmail.Location = new System.Drawing.Point(lblEmail.Location.X, margin_b);

      btnLimpar.Text = "Limpar";
      btnLimpar.Location = new System.Drawing.Point(0, 75);
      btnLimpar.Click += btnLimpar_Click;

      btnAdd.Text = "Adicionar";
      int btnAddX = tabela.Left + tabela.Width - btnAdd.Width;
      btnAdd.Location = new System.Drawing.Point(btnAddX, 75);
      btnAdd.BackColor = Color.FromArgb(0, 123, 255); // Cor azul do Bootstrap (btn-primary)
      btnAdd.ForeColor = Color.White;
      btnAdd.FlatAppearance.BorderColor = Color.FromArgb(0, 123, 255);
      btnAdd.Click += btnAdd_Click;

      // Adicionando em tela
      Controls.Add(tabela);
      formConteiner.Controls.Add(lblNome);
      formConteiner.Controls.Add(inpNome);
      formConteiner.Controls.Add(lblDtNascimento);
      formConteiner.Controls.Add(inpDtNascimento);
      formConteiner.Controls.Add(lblEndereco);
      formConteiner.Controls.Add(inpEndereco);
      formConteiner.Controls.Add(lblTelefone);
      formConteiner.Controls.Add(inpTelefone);
      formConteiner.Controls.Add(lblEmail);
      formConteiner.Controls.Add(inpEmail);
      formConteiner.Controls.Add(btnLimpar);
      formConteiner.Controls.Add(btnAdd);
      Controls.Add(formConteiner);

      GetUsuarios();

      tabela.CellContentClick += Update;
      tabela.CellContentClick += Delete;
      tabela.CellMouseEnter += tabela_CellMouseEnter;

      // Adiciona um evento para validação do campo nome
      inpNome.KeyPress += inpNome_KeyPress;

      // Adiciona um evento para validação do campo endereço
      inpEndereco.KeyPress += InpEndereco_KeyPress;

      // Adiciona um evento para validar o campo telefone
      inpTelefone.KeyPress += inpTelefone_KeyPress;

      // Adiciona um evento para controlar a máscara de acordo com o valor digitado
      inpTelefone.TextChanged += inpTelefone_TextChanged;

      btnAdd.MouseHover += btnAdd_MouseHover;
      btnAdd.MouseLeave += btnAdd_MouseLeave;
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

      // Verifica se o UserControl tem um Panel pai
      if (this.Parent is Panel painelGeral && !isTableCentered)
      {
        // Calcula a posição horizontal central para a tabela
        tabelaX = (painelGeral.Width - tabela.Width) / 2;

        // Calcula a posição vertical central para a tabela
        tabelaY = (painelGeral.Height - tabela.Height) / 2;

        // Atualiza a posição da tabela
        tabela.Location = new System.Drawing.Point(tabelaX, tabelaY);

        int formX = tabelaX;
        int alturaDisponivelAbaixoTabela = painelGeral.Height - tabela.Bottom;
        int formY = (alturaDisponivelAbaixoTabela - formConteiner.Height) / 2;
        formY += tabela.Bottom;
        formConteiner.Location = new Point(formX, formY);

        // Define a flag como true para que a centralização só ocorra uma vez
        isTableCentered = true;
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

    private void inpNome_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Verifica se a tecla pressionada é Backspace, Tab ou Enter
      if (char.IsControl(e.KeyChar))
      {
        return;
      }

      // Verifica se o comprimento máximo foi atingido (120 caracteres)
      if (inpNome.Text.Length >= 120)
      {
        e.Handled = true;
      }

      // Utiliza a expressão regular para permitir apenas letras e espaços em branco
      string allowedCharsPattern = "^[a-zA-Z ]$";
      if (!Regex.IsMatch(e.KeyChar.ToString(), allowedCharsPattern))
      {
        e.Handled = true;
      }
    }

    public bool NomeValido(string nome)
    {
      // Verifica se o nome não está vazio ou preenchido apenas com espaços em branco
      if (string.IsNullOrWhiteSpace(nome))
      {
        return false;
      }

      // Define o tamanho mínimo do campo de nome para 3 caracteres
      int tamanhoMin = 3;

      // Verifica se o nome possui o tamanho mínimo exigido
      if (nome.Length < tamanhoMin)
      {
        return false;
      }

      // Expressão regular para verificar se o nome contém apenas letras e espaços em branco
      Regex regex = new Regex("^[a-zA-Z ]+$");

      // Verifica se o nome corresponde à expressão regular
      if (!regex.IsMatch(nome))
      {
        return false;
      }

      return true;
    }

    private void InpEndereco_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Verifica se a tecla pressionada é Backspace, Tab ou Enter
      if (char.IsControl(e.KeyChar))
        return;

      // Verifica se o comprimento máximo foi atingido (120 caracteres)
      if (inpEndereco.Text.Length >= 120)
        e.Handled = true;

      // Utiliza uma expressão regular para permitir apenas letras, números, vírgulas e traços
      string allowedCharsPattern = @"^[a-zA-Z0-9, -]$";
      if (!Regex.IsMatch(e.KeyChar.ToString(), allowedCharsPattern))
        e.Handled = true;
    }

    private bool EnderecoValido(string endereco)
    {
      // Verifica se o endereço não está vazio ou preenchido apenas com espaços em branco
      if (string.IsNullOrWhiteSpace(endereco))
      {
        return false;
      }

      // Define o tamanho mínimo do campo de endereço para 10 caracteres
      int tamanhoMin = 10;

      // Verifica se o endereço possui o tamanho mínimo exigido
      if (endereco.Length < tamanhoMin)
      {
        return false;
      }

      // Utiliza a expressão regular para validar o endereço completo
      string allowedCharsPattern = @"^[a-zA-Z0-9, -]{1,120}$";
      if (!Regex.IsMatch(endereco, allowedCharsPattern))
      {
        return false;
      }

      return true;
    }

    private void SetTelefoneMask(string mask)
    {
      inpTelefone.Mask = mask;
    }

    private void inpTelefone_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Verifica se é um número ou tecla de controle (Backspace, Delete, etc.)
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true; // Ignora o caractere digitado
      }

      string telefone = inpTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
      int totalDigitos = telefone.Length + 1; // +1 porque o evento ainda não atualizou o texto

      // Verifica se atingiu o número máximo de dígitos permitido (11)
      if (totalDigitos > 11)
      {
        e.Handled = true; // Ignora o caractere digitado
      }
    }

    private void inpTelefone_TextChanged(object sender, EventArgs e)
    {
      string telefone = inpTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

      if (telefone.Length > 10)
      {
        // Telefone celular
        SetTelefoneMask("(00) 00000-0000");
      }
      else
      {
        // Telefone fixo
        SetTelefoneMask("(00) 0000-0000");
      }
    }

    private bool TelefoneValido(string telefone)
    {
      // Verifica se o telefone não está vazio ou preenchido apenas com espaços em branco
      if (string.IsNullOrWhiteSpace(telefone))
      {
        return false;
      }

      // Remove caracteres não numéricos do telefone
      telefone = new string(telefone.Where(char.IsDigit).ToArray());

      // Verifica se o telefone possui o tamanho mínimo exigido
      int tamanhoMin = 10;
      if (telefone.Length < tamanhoMin)
      {
        return false;
      }

      // Verifica se o telefone possui o tamanho máximo permitido para celular
      int tamanhoMaxCelular = 11;
      if (telefone.Length == tamanhoMaxCelular)
      {
        // Formato de telefone celular: (00) 9 0000-0000
        return Regex.IsMatch(telefone, @"^\(\d{2}\)\s9\s\d{4}-\d{4}$");
      }
      else
      {
        // Formato de telefone fixo: (00) 0000-0000
        return Regex.IsMatch(telefone, @"^\(\d{2}\)\s\d{4}-\d{4}$");
      }
    }

    private bool ValidarCampos()
    {
      string nome = inpNome.Text;
      string endereco = inpEndereco.Text;
      string telefone = inpTelefone.Text;

      if (!NomeValido(nome))
      {
        MessageBox.Show(
          "Nome inválido! Insira um nome válido com pelo menos 3 caracteres e apenas letras.",
          "Erro",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        // Limpa o campo nome
        inpNome.Text = string.Empty;

        // Define o foco para o campo nome
        inpNome.Focus();

        return false;
      }

      if (!EnderecoValido(endereco))
      {
        MessageBox.Show(
          "Endereço inválido! Insira um endereço válido com até 120 caracteres e apenas letras, números, vírgulas e traços.",
          "Erro",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        // Limpa o campo endereço
        inpEndereco.Text = string.Empty;

        // Define o foco para o campo endereço
        inpEndereco.Focus();

        return false;
      }

      if (!TelefoneValido(telefone))
      {
        MessageBox.Show(
          "Telefone inválido! Por favor, insira um telefone válido no formato (00) 0000-0000 ou (00) 00000-0000.",
          "Erro",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        // Limpa o campo telefone
        inpTelefone.Text = string.Empty;

        // Define o foco para o campo telefone
        inpTelefone.Focus();

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
      inpNome.Clear();
      inpDtNascimento.Value = DateTime.Now;
      inpEndereco.Clear();
      inpTelefone.Clear();
      inpEmail.Clear();
    }

    private void btnAdd_MouseHover(object sender, EventArgs e)
    {
      btnAdd.BackColor = Color.FromArgb(0, 86, 179); // Cor de hover do Bootstrap btn-primary
      btnAdd.ForeColor = Color.White;
      btnAdd.FlatAppearance.BorderColor = Color.FromArgb(0, 86, 179);
    }

    private void btnAdd_MouseLeave(object sender, EventArgs e)
    {
      btnAdd.BackColor = Color.FromArgb(0, 123, 255); // Cor normal do Bootstrap btn-primary
      btnAdd.ForeColor = Color.White;
      btnAdd.FlatAppearance.BorderColor = Color.FromArgb(0, 123, 255);
    }

    public void btnAdd_Click(object sender, EventArgs e)
    {
      Insert();
      Limpar();
    }

    public void Insert()
    {
      if (ValidarCampos())
      {
        // Se todos os campos são válidos, continue com a lógica de salvamento ou outras ações.
        MessageBox.Show(
          "Todos os campos válidos!",
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

    public override void Refresh()
    {
      GetUsuarios();
    }
  }
}