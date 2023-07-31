using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Views
{
  public class Livro : UserControl
  {
    private DataGridView tabela;
    private bool isTableCentered = false;
    private int tabelaX;
    private int tabelaY;
    private DataGridViewButtonColumn colunaEditar;
    private DataGridViewButtonColumn colunaExcluir;
    private Panel formConteiner;
    private Label lblTitulo;
    private TextBox inpTitulo;
    private Label lblGenero;
    private TextBox inpGenero;
    private Label lblDtPublicacao;
    private DateTimePicker inpDtPublicacao;
    private Label lblAutor;
    private TextBox inpAutor;
    private Label lblEditora;
    private TextBox inpEditora;
    private Button btnLimpar;
    private Button btnAdd;

    public Livro()
    {
      // Inicializa a tabela
      tabela = new DataGridView();

      // Define as dimensões mínimas da tabela
      tabela.MinimumSize = new System.Drawing.Size(1189, 275);

      // Define as dimensões máximas da tabela
      tabela.MaximumSize = new System.Drawing.Size(1206, 275);

      // Define a cor de fundo da tabela
      tabela.BackgroundColor = SystemColors.Control;

      // Configurações da tabela
      tabela.AllowUserToAddRows = false;
      tabela.ReadOnly = false;

      // Adicionando as colunas à tabela
      tabela.Columns.Add("Id", "Id");
      tabela.Columns["Id"].Width = 45;
      tabela.Columns["Id"].ReadOnly = true;
      tabela.Columns.Add("Titulo", "Título do Livro");
      tabela.Columns["Titulo"].Width = 212;
      tabela.Columns.Add("Genero", "Gênero do Livro");
      tabela.Columns["Genero"].Width = 140;
      tabela.Columns.Add("DtPublicacao", "Data de Publicação");
      tabela.Columns["DtPublicacao"].Width = 140;
      tabela.Columns.Add("Status", "Status");
      tabela.Columns["Status"].Width = 85;
      tabela.Columns["Status"].ReadOnly = true;
      tabela.Columns.Add("Autor", "Nome do Autor");
      tabela.Columns["Autor"].Width = 212;
      tabela.Columns.Add("Editora", "Nome da Editora");
      tabela.Columns["Editora"].Width = 212;

      colunaEditar = new DataGridViewButtonColumn();
      colunaEditar.Name = "Editar";
      colunaEditar.HeaderText = "Editar";
      colunaEditar.Text = "✏️";
      colunaEditar.ToolTipText = "Editar Livro";
      colunaEditar.UseColumnTextForButtonValue = true;
      colunaEditar.DefaultCellStyle.Padding = new Padding(2);
      colunaEditar.Width = 50;
      tabela.Columns.Add(colunaEditar);

      colunaExcluir = new DataGridViewButtonColumn();
      colunaExcluir.Name = "Excluir";
      colunaExcluir.HeaderText = "Excluir";
      colunaExcluir.Text = "🗑️";
      colunaExcluir.ToolTipText = "Excluir Livro";
      colunaExcluir.UseColumnTextForButtonValue = true;
      colunaExcluir.DefaultCellStyle.Padding = new Padding(2);
      colunaExcluir.Width = 50;
      tabela.Columns.Add(colunaExcluir);

      // Ajuste automático das colunas
      tabela.AutoResizeColumns();

      formConteiner = new Panel();
      formConteiner.AutoSize = true;

      lblTitulo = new Label();
      inpTitulo = new TextBox();
      lblGenero = new Label();
      inpGenero = new TextBox();
      lblDtPublicacao = new Label();
      inpDtPublicacao = new DateTimePicker();
      lblAutor = new Label();
      inpAutor = new TextBox();
      lblEditora = new Label();
      inpEditora = new TextBox();
      btnAdd = new Button();
      btnLimpar = new Button();

      int margin_r = 89;
      int margin_b = 23;

      lblTitulo.Text = "Título do Livro:";
      lblTitulo.ForeColor = Color.White;
      lblTitulo.Location = new System.Drawing.Point(0, 0);

      inpTitulo.MaxLength = 50;
      inpTitulo.Width = 212;
      inpTitulo.Location = new System.Drawing.Point(lblTitulo.Location.X, margin_b);

      lblGenero.Text = "Gênero do Livro:";
      lblGenero.ForeColor = Color.White;
      lblGenero.Location = new System.Drawing.Point(inpTitulo.Right + margin_r, 0);

      inpGenero.MaxLength = 50;
      inpGenero.Width = 140;
      inpGenero.Location = new System.Drawing.Point(lblGenero.Location.X, margin_b);

      lblDtPublicacao.Text = "Data de Publicação:";
      lblDtPublicacao.Width = 140;
      lblDtPublicacao.ForeColor = Color.White;
      lblDtPublicacao.Location = new System.Drawing.Point(inpGenero.Right + margin_r, 0);

      inpDtPublicacao.Format = DateTimePickerFormat.Custom;
      inpDtPublicacao.CustomFormat = "dd/MM/yyyy";
      inpDtPublicacao.Width = 141;
      inpDtPublicacao.Location = new System.Drawing.Point(lblDtPublicacao.Location.X, margin_b);

      lblAutor.Text = "Autor";
      lblAutor.ForeColor = Color.White;
      lblAutor.Location = new System.Drawing.Point(inpDtPublicacao.Right + margin_r, 0);

      inpAutor.MaxLength = 120;
      inpAutor.Width = 170;
      inpAutor.Location = new System.Drawing.Point(lblAutor.Location.X, margin_b);

      lblEditora.Text = "Editora";
      lblEditora.ForeColor = Color.White;
      lblEditora.Location = new System.Drawing.Point(inpAutor.Right + margin_r, 0);

      inpEditora.MaxLength = 50;
      inpEditora.Width = 170;
      inpEditora.Location = new System.Drawing.Point(lblEditora.Location.X, margin_b);

      btnLimpar.Text = "Limpar";
      btnLimpar.Location = new System.Drawing.Point(0, 75);
      btnLimpar.Click += btnLimpar_Click;

      btnAdd.Text = "Adicionar";
      int btnAddX = tabela.Left + tabela.Width - btnAdd.Width;
      btnAdd.Location = new System.Drawing.Point(btnAddX, 75);
      btnAdd.Click += btnAdd_Click;

      // Adicionando em tela
      Controls.Add(tabela);
      formConteiner.Controls.Add(lblTitulo);
      formConteiner.Controls.Add(inpTitulo);
      formConteiner.Controls.Add(lblGenero);
      formConteiner.Controls.Add(inpGenero);
      formConteiner.Controls.Add(lblDtPublicacao);
      formConteiner.Controls.Add(inpDtPublicacao);
      formConteiner.Controls.Add(lblAutor);
      formConteiner.Controls.Add(inpAutor);
      formConteiner.Controls.Add(lblEditora);
      formConteiner.Controls.Add(inpEditora);
      formConteiner.Controls.Add(btnLimpar);
      formConteiner.Controls.Add(btnAdd);
      Controls.Add(formConteiner);

      GetLivros();

      tabela.CellContentClick += Update;
      tabela.CellContentClick += Delete;
      tabela.CellMouseEnter += tabela_CellMouseEnter;

      // Adiciona um evento para validação do campo titulo
      inpTitulo.KeyPress += InpTitulo_KeyPress;

      // Adiciona um evento para validação do campo genero
      inpGenero.KeyPress += InpGenero_KeyPress;

      // Adiciona um evento para validação do campo autor
      inpAutor.KeyPress += Autor_KeyPress;

      // Adiciona um evento para validação do campo editora
      inpEditora.KeyPress += Editora_KeyPress;

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

        int formX = tabelaX;
        int alturaDisponivelAbaixoTabela = painelGeral.Height - tabela.Bottom;
        int formY = (alturaDisponivelAbaixoTabela - formConteiner.Height) / 2;
        formY += tabela.Bottom;
        formConteiner.Location = new Point(formX, formY);

        // Define a flag como true para que a centralização só ocorra uma vez
        isTableCentered = true;
      }

      // Verifica se há livros cadastrados no Load do formulário
      if (tabela.Rows.Count == 0)
      {
        MessageBox.Show(
          "Não há livros cadastrados no banco de dados.",
          "Informação",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information
        );
      }
    }

    private void GetLivros()
    {
      Controllers.LivroController.LimparList();
      List<Models.Livro> livros = Controllers.LivroController.ListLivros();

      // Limpa todas as linhas da tabela antes de adicionar os novos dados
      tabela.Rows.Clear();

      if (livros.Count > 0)
      {
        foreach (var livro in livros)
        {
          PopulaTabela(
            livro.CodLivro,
            livro.Titulo,
            livro.Genero,
            livro.DtPublicacao,
            livro.Status,
            livro.Autor,
            livro.Editora
          );
        }
      }

      // Atualiza a tabela
      tabela.Refresh();
    }

    public void PopulaTabela(
      int id,
      string titulo,
      string genero,
      DateTime dt_publicacao,
      string status,
      string autor,
      string editora
    )
    {
      // Adiciona os dados à tabela usando uma nova linha
      DataGridViewRow row = new DataGridViewRow();
      row.CreateCells(
        tabela,
        id,
        titulo,
        genero,
        dt_publicacao.ToString("dd/MM/yyyy"),
        status,
        autor,
        editora,
        "✏️",
        "🗑️"
      );
      tabela.Rows.Add(row);
    }

    private void tabela_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && (e.ColumnIndex == tabela.Columns["Editar"].Index || e.ColumnIndex == tabela.Columns["Excluir"].Index))
      {
        string tooltipText = "";

        if (e.ColumnIndex == tabela.Columns["Editar"].Index)
        {
          tooltipText = "Editar Livro";
        }
        else if (e.ColumnIndex == tabela.Columns["Excluir"].Index)
        {
          tooltipText = "Excluir Livro";
        }

        tabela.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = tooltipText;
      }
    }

    private void InpTitulo_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Verifica se a tecla pressionada é Backspace, Tab ou Enter
      if (char.IsControl(e.KeyChar))
      {
        return;
      }

      // Verifica se o caractere digitado é aspas simples
      if (e.KeyChar == '\'')
      {
        // Verifica se já existem aspas simples consecutivas
        string titulo = inpTitulo.Text;
        if (titulo.EndsWith("'"))
        {
          // Ignora a entrada de aspas simples
          e.Handled = true;
        }
      }

      // Verifica se o comprimento máximo foi atingido (50 caracteres)
      if (inpTitulo.Text.Length >= 50)
      {
        e.Handled = true;
      }

      // Utiliza a expressão regular para permitir apenas letras e espaços em branco
      string allowedCharsPattern = "^[a-zA-ZÀ-ÿ' ]+$";
      if (!Regex.IsMatch(e.KeyChar.ToString(), allowedCharsPattern))
      {
        e.Handled = true;
      }
    }

    public bool TituloValido(string titulo)
    {
      // Verifica se o titulo não está vazio ou preenchido apenas com espaços em branco
      if (string.IsNullOrWhiteSpace(titulo))
      {
        return false;
      }

      // Define o tamanho mínimo do campo de titulo para 3 caracteres
      int tamanhoMin = 3;

      // Verifica se o titulo possui o tamanho mínimo exigido
      if (titulo.Length < tamanhoMin)
      {
        return false;
      }

      // Expressão regular para verificar se o titulo contém apenas letras e espaços em branco
      Regex regex = new Regex("^[a-zA-ZÀ-ÿ' ]+$");

      // Verifica se o titulo corresponde à expressão regular
      if (!regex.IsMatch(titulo))
      {
        return false;
      }

      return true;
    }

    private void InpGenero_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Verifica se a tecla pressionada é Backspace, Tab ou Enter
      if (char.IsControl(e.KeyChar))
      {
        return;
      }

      // Verifica se o caractere digitado é aspas simples
      if (e.KeyChar == '\'')
      {
        // Verifica se já existem aspas simples consecutivas
        string genero = inpGenero.Text;
        if (genero.EndsWith("'"))
        {
          // Ignora a entrada de aspas simples
          e.Handled = true;
        }
      }

      // Verifica se o comprimento máximo foi atingido (50 caracteres)
      if (inpGenero.Text.Length >= 50)
      {
        e.Handled = true;
      }

      // Utiliza a expressão regular para permitir apenas letras e espaços em branco
      string allowedCharsPattern = "^[a-zA-ZÀ-ÿ' ]+$";
      if (!Regex.IsMatch(e.KeyChar.ToString(), allowedCharsPattern))
      {
        e.Handled = true;
      }
    }

    public bool GeneroValido(string genero)
    {
      // Verifica se o genero não está vazio ou preenchido apenas com espaços em branco
      if (string.IsNullOrWhiteSpace(genero))
      {
        return false;
      }

      // Define o tamanho mínimo do campo de genero para 3 caracteres
      int tamanhoMin = 3;

      // Verifica se o genero possui o tamanho mínimo exigido
      if (genero.Length < tamanhoMin)
      {
        return false;
      }

      // Expressão regular para verificar se o genero contém apenas letras e espaços em branco
      Regex regex = new Regex("^[a-zA-ZÀ-ÿ' ]+$");

      // Verifica se o genero corresponde à expressão regular
      if (!regex.IsMatch(genero))
      {
        return false;
      }

      return true;
    }

    private bool IsDataValida(int dia, int mes, int ano)
    {
      // Verifica se o mês é válido
      if (mes < 1 || mes > 12)
      {
        return false;
      }

      // Verifica se o dia é válido para o mês especificado
      int[] diasPorMes = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
      bool anoBissexto = (ano % 4 == 0 && (ano % 100 != 0 || ano % 400 == 0));
      if (dia < 1 || (dia > diasPorMes[mes] && !(mes == 2 && dia == 29 && anoBissexto)))
      {
        return false;
      }

      // Verifica se o ano é válido
      if (ano < 1)
      {
        return false;
      }

      return true;
    }

    private bool DtPublicacaoValida(string dt_publicacao)
    {
      // Verifica se a data possui o formato "dd/MM/yyyy" usando regex
      string regexPattern = @"^(0[1-9]|[1-2][0-9]|3[0-1])/(0[1-9]|1[0-2])/\d{4}$";
      if (!Regex.IsMatch(dt_publicacao, regexPattern))
      {
        return false;
      }

      // Converte a string de data para o tipo DateTime
      if (!DateTime.TryParseExact(
        dt_publicacao,
        "dd/MM/yyyy",
        null,
        System.Globalization.DateTimeStyles.None,
        out DateTime data
      ))
      {
        return false;
      }

      // Obtém os componentes da data
      int dia = data.Day;
      int mes = data.Month;
      int ano = data.Year;

      // Verifica se a data é válida, considerando os dias impossíveis em certos meses
      if (!IsDataValida(dia, mes, ano))
      {
        return false;
      }

      // Verifica se a data é maior ou igual à data atual
      if (data >= DateTime.Today)
      {
        return false;
      }

      return true;
    }

    private void Autor_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Verifica se a tecla pressionada é Backspace, Tab ou Enter
      if (char.IsControl(e.KeyChar))
      {
        return;
      }

      // Verifica se o caractere digitado é aspas simples
      if (e.KeyChar == '\'')
      {
        // Verifica se já existem aspas simples consecutivas
        string autor = inpAutor.Text;
        if (autor.EndsWith("'"))
        {
          // Ignora a entrada de aspas simples
          e.Handled = true;
        }
      }

      // Verifica se o comprimento máximo foi atingido (120 caracteres)
      if (inpAutor.Text.Length >= 120)
      {
        e.Handled = true;
      }

      // Utiliza a expressão regular para permitir apenas letras e espaços em branco
      string allowedCharsPattern = "^[a-zA-ZÀ-ÿ' ]+$";
      if (!Regex.IsMatch(e.KeyChar.ToString(), allowedCharsPattern))
      {
        e.Handled = true;
      }
    }

    public bool AutorValido(string autor)
    {
      // Verifica se o autor não está vazio ou preenchido apenas com espaços em branco
      if (string.IsNullOrWhiteSpace(autor))
      {
        return false;
      }

      // Define o tamanho mínimo do campo de autor para 3 caracteres
      int tamanhoMin = 3;

      // Verifica se o autor possui o tamanho mínimo exigido
      if (autor.Length < tamanhoMin)
      {
        return false;
      }

      // Expressão regular para verificar se o autor contém apenas letras e espaços em branco
      Regex regex = new Regex("^[a-zA-ZÀ-ÿ' ]+$");

      // Verifica se o autor corresponde à expressão regular
      if (!regex.IsMatch(autor))
      {
        return false;
      }

      return true;
    }

    private void Editora_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Verifica se a tecla pressionada é Backspace, Tab ou Enter
      if (char.IsControl(e.KeyChar))
      {
        return;
      }

      // Verifica se o caractere digitado é aspas simples
      if (e.KeyChar == '\'')
      {
        // Verifica se já existem aspas simples consecutivas
        string editora = inpEditora.Text;
        if (editora.EndsWith("'"))
        {
          // Ignora a entrada de aspas simples
          e.Handled = true;
        }
      }

      // Verifica se o comprimento máximo foi atingido (50 caracteres)
      if (inpGenero.Text.Length >= 50)
      {
        e.Handled = true;
      }

      // Utiliza a expressão regular para permitir apenas letras e espaços em branco
      string allowedCharsPattern = "^[a-zA-ZÀ-ÿ' ]+$";
      if (!Regex.IsMatch(e.KeyChar.ToString(), allowedCharsPattern))
      {
        e.Handled = true;
      }
    }

    public bool EditoraValida(string editora)
    {
      // Verifica se o campo editora não está vazio ou preenchido apenas com espaços em branco
      if (string.IsNullOrWhiteSpace(editora))
      {
        return false;
      }

      // Define o tamanho mínimo do campo editora para 3 caracteres
      int tamanhoMin = 3;

      // Verifica se o campo editora possui o tamanho mínimo exigido
      if (editora.Length < tamanhoMin)
      {
        return false;
      }

      // Expressão regular para verificar se o campo editora contém apenas letras e espaços em branco
      Regex regex = new Regex("^[a-zA-ZÀ-ÿ' ]+$");

      // Verifica se o campo editora corresponde à expressão regular
      if (!regex.IsMatch(editora))
      {
        return false;
      }

      return true;
    }

    private bool ValidarCampos()
    {
      string titulo = inpTitulo.Text;
      string genero = inpGenero.Text;
      string dt_publicacao = inpDtPublicacao.Text;
      string autor = inpAutor.Text;
      string editora = inpEditora.Text;

      if (!TituloValido(titulo))
      {
        MessageBox.Show(
          "Titulo inválido! Insira um titulo válido com pelo menos 3 caracteres e apenas letras.",
          "Erro",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        // Limpa o campo titulo
        inpTitulo.Text = string.Empty;

        // Define o foco para o campo titulo
        inpTitulo.Focus();

        return false;
      }
      if (!GeneroValido(genero))
      {
        MessageBox.Show(
          "Gênero inválido! Insira um gênero válido com pelo menos 3 caracteres e apenas letras.",
          "Erro",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        // Limpa o campo genero
        inpGenero.Text = string.Empty;

        // Define o foco para o campo genero
        inpGenero.Focus();

        return false;
      }
      if (!DtPublicacaoValida(dt_publicacao))
      {
        MessageBox.Show(
          "Data de publicação inválida! Certifique-se de que a data seja válida, anterior à data atual.",
          "Erro",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        // Limpa o campo data de publicacao
        inpDtPublicacao.Value = DateTime.Now;

        // Define o foco para o campo data de publicacao
        inpDtPublicacao.Focus();

        return false;
      }
      if (!AutorValido(autor))
      {
        MessageBox.Show(
          "Nome do autor inválido! Insira um nome de autor válido com pelo menos 3 caracteres e apenas letras.",
          "Erro",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        // Limpa o campo autor
        inpAutor.Text = string.Empty;

        // Define o foco para o campo autor
        inpAutor.Focus();

        return false;
      }
      if (!EditoraValida(editora))
      {
        MessageBox.Show(
          "Nome da editora inválido! Insira um nome de editora válido com pelo menos 3 caracteres e apenas letras.",
          "Erro",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        // Limpa o campo editora
        inpEditora.Text = string.Empty;

        // Define o foco para o campo editora
        inpEditora.Focus();

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
      inpTitulo.Clear();
      inpGenero.Clear();
      inpDtPublicacao.Value = DateTime.Now;
      inpAutor.Clear();
      inpEditora.Clear();
    }
    public void btnAdd_Click(object sender, EventArgs e)
    {
      Insert();
    }


    public void Insert()
    {
      if (ValidarCampos())
      {
        // Obtém os valores do form
        string titulo = inpTitulo.Text;
        string genero = inpGenero.Text;
        DateTime dt_publicacao = inpDtPublicacao.Value;
        string autor = inpAutor.Text;
        string editora = inpEditora.Text;

        // Constrói um objeto Livro
        Controllers.LivroController.AddLivro(
          titulo,
          genero,
          dt_publicacao,
          autor,
          editora
        );

        // Atualiza a tabela
        Refresh();

        // Limpando o texto dos inputs
        Limpar();

        // Exibe o MessageBox de livro adicionado com sucesso
        MessageBox.Show(
          "Livro adicionado com sucesso!",
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
          "Tem certeza de que deseja editar este livro?",
          "Confirmação",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
        {
          DataGridViewRow row = tabela.Rows[e.RowIndex];

          // Obtém o valor do campo Id
          int cod_livro = Convert.ToInt32(row.Cells["Id"].Value);

          // Obtém os valores das outras colunas
          string titulo = row.Cells["Titulo"].Value.ToString();
          string genero = row.Cells["Genero"].Value.ToString();
          DateTime dt_publicacao = Convert.ToDateTime(row.Cells["DtPublicacao"].Value);
          string status = row.Cells["Status"].Value.ToString();
          string autor = row.Cells["Autor"].Value.ToString();
          string editora = row.Cells["Editora"].Value.ToString();

          // Obtém o objeto Livro
          Models.Livro livro = Controllers.LivroController.GetLivro(cod_livro);

          if (livro != null)
          {
            // Atualiza as propriedades do objeto livro existente
            livro.Titulo = titulo;
            livro.Genero = genero;
            livro.DtPublicacao = dt_publicacao;
            livro.Status = status;
            livro.Autor = autor;
            livro.Editora = editora;

            // Chama o método de update passando o id e o objeto livro
            Controllers.LivroController.UpdateLivro(cod_livro, livro);

            // Atualiza a tabela
            Refresh();

            // Exibe o MessageBox de livro editado com sucesso
            MessageBox.Show(
              "Livro editado com sucesso!",
              "Sucesso!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information
            );
          }
          else
          {
            MessageBox.Show(
              "Livro não encontrado!",
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
          "Tem certeza de que deseja excluir este livro?",
          "Confirmação",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
        {
          DataGridViewRow row = tabela.Rows[e.RowIndex];

          // Obtém o valor do campo Id
          int cod_livro = Convert.ToInt32(row.Cells["Id"].Value);

          // Obtém o objeto Livro
          Models.Livro livro = Controllers.LivroController.GetLivro(cod_livro);

          if (livro != null)
          {
            // Chama o método de exclusão passando o código do livro
            Controllers.LivroController.DeleteLivro(cod_livro);

            // Remove a linha da tabela
            tabela.Rows.RemoveAt(e.RowIndex);

            // Atualiza a tabela
            Refresh();

            MessageBox.Show(
              "Livro excluído com sucesso!",
              "Sucesso",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information
            );

            // Verifica se há livros cadastrados
            if (tabela.Rows.Count == 0)
            {
              MessageBox.Show(
                "Não há livros cadastrados no banco de dados.",
                "Informação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
              );
            }
          }
          else
          {
            MessageBox.Show(
              "Livro não encontrado!",
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
      GetLivros();
    }
  }
}