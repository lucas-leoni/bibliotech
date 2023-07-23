using System;
using System.Windows.Forms;

namespace Views
{
  public partial class Menu : Form
  {
    // Declarando o painel principal
    private Panel painelGeral;
    /* private Login login; */
    private Form parent;
    public Menu(Form parent)
    {
      this.parent = parent;

      // Construtor que inicializa os dois métodos
      FormPrincipal();
      PanelMenu();
      FormClosed += AoFechar;
    }

    private void FormPrincipal()
    {
      //vai servir talvez para quando trocar o menu nao ficar piscando
      //this.SuspendLayout();

      // serve alterar a form conforme a fonte
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

      //tamanho da form maximized,vai pegar a tela toda
      this.WindowState = FormWindowState.Maximized;

      // tirei o tamanho fixo para colocar o maximized logo a cima...
      //this.ClientSize = new System.Drawing.Size(1000 , 500);

      // nome da form
      this.Text = "Bibliotech";
    }

    private void PanelMenu()
    {
      // Cria o painel principal
      painelGeral = new Panel();

      // Faz com que o painel principal use a tela toda
      painelGeral.Dock = DockStyle.Fill;
      Controls.Add(painelGeral);

      // Cria o MenuStrip
      MenuStrip menuStrip = new MenuStrip();

      // Faz com que o menustrip fique no topo
      menuStrip.Dock = DockStyle.Top;
      Controls.Add(menuStrip);

      // Adicionar as opções de menu
      ToolStripMenuItem livroMenu = new ToolStripMenuItem("Livros");
      livroMenu.Click += PanelLivro;

      ToolStripMenuItem usuarioMenu = new ToolStripMenuItem("Usuários");
      usuarioMenu.Click += PanelUsuario;

      ToolStripMenuItem emprestimoMenu = new ToolStripMenuItem("Empréstimos");
      emprestimoMenu.Click += PanelEmprestimo;

      ToolStripMenuItem logo = new ToolStripMenuItem();

      Font fontePersonalizada = new Font("Segoe UI", 20, FontStyle.Bold);

      // Alterar a fonte e tamanho dos itens de menu
      livroMenu.Font = fontePersonalizada;
      usuarioMenu.Font = fontePersonalizada;
      emprestimoMenu.Font = fontePersonalizada;

      menuStrip.Items.Add(livroMenu);
      menuStrip.Items.Add(usuarioMenu);
      menuStrip.Items.Add(emprestimoMenu);

      Livro livroView = new Livro();
      livroView.Dock = DockStyle.Fill;
      painelGeral.Controls.Add(livroView);
    }

    private void PanelLivro(object sender, EventArgs e)
    {
      // Exibir o conteúdo de Livro no panel
      painelGeral.Controls.Clear();
      Livro livroView = new Livro();
      livroView.Dock = DockStyle.Fill;
      painelGeral.Controls.Add(livroView);
    }

    private void PanelUsuario(object sender, EventArgs e)
    {
      // Exibir o conteúdo de Usuario no panel
      painelGeral.Controls.Clear();
      /* Usuario usuarioView = new Usuario(painelGeral); */
      Usuario usuarioView = new Usuario();
      usuarioView.Dock = DockStyle.Fill;
      painelGeral.Controls.Add(usuarioView);
    }

    private void PanelEmprestimo(object sender, EventArgs e)
    {
      // Exibir o conteúdo de Emprestimo no panel
      painelGeral.Controls.Clear();
      Emprestimo emprestimoView = new Emprestimo();
      emprestimoView.Dock = DockStyle.Fill;
      painelGeral.Controls.Add(emprestimoView);
    }

    private void AoFechar(object sender, FormClosedEventArgs e)
    {
      this.parent.Show();
      /* this.Close(); */
    }
  }
}
