using System;
using System.Drawing;
using System.Windows.Forms;

namespace Views
{
  public class CustomForm : Form
  {
    public CustomForm()
    {
      BackgroundImage = Image.FromFile("img/fundo.png");
      BackgroundImageLayout = ImageLayout.Stretch;
    }
  }

  public class DoubleBufferedPanel : Panel
  {
    public DoubleBufferedPanel()
    {
      DoubleBuffered = true;
    }
  }

  public partial class Menu : CustomForm
  {
    private DoubleBufferedPanel painelgeral;
    private Image m1;
    private Image m1Ativo;
    private Image m2;
    private Image m2Ativo;
    private Image m3;
    private Image m3Ativo;

    // Variáveis para as views
    private Livro livroView;
    private Usuario usuarioView;
    private Emprestimo emprestimoView;
    private Form parent;

    private Panel customTitleBar;
    private Label logoLabel;
    private Button closeButton;

    private ToolStripMenuItem livro;
    private ToolStripMenuItem usuario;
    private ToolStripMenuItem emprestimo;

    public Menu(Form parent)
    {
      this.parent = parent;

      // ...
      FormPrincipal();
      PanelMenu();
      BorderSuperior();

      // Inicialize as variáveis das views
      livroView = new Livro();
      usuarioView = new Usuario();
      emprestimoView = new Emprestimo();

      // Exiba a view de Livros por padrão
      ShowView(livroView);

      FormClosed += AoFechar;
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
        return cp;
      }
    }

    private void FormPrincipal()
    {
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      WindowState = FormWindowState.Maximized;
      Text = "Bibliotech";
    }

    private void PanelMenu()
    {
      painelgeral = new DoubleBufferedPanel();
      painelgeral.BackColor = Color.Transparent;
      painelgeral.Dock = DockStyle.Fill;

      // Cria o MenuStrip
      MenuStrip menuStrip = new MenuStrip();
      menuStrip.Padding = new Padding(40, 0, 0, 0);
      menuStrip.Dock = DockStyle.Top;
      menuStrip.BackColor = Color.Transparent;
      menuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());

      m1 = Image.FromFile("img/m1.png");
      m1 = new Bitmap(m1, new Size(90, 90));

      m1Ativo = Image.FromFile("img/m1Ativo.png");
      m1Ativo = new Bitmap(m1, new Size(100, 100));

      m2 = Image.FromFile("img/m2.png");
      m2 = new Bitmap(m2, new Size(90, 90));

      m2Ativo = Image.FromFile("img/m2Ativo.png");
      m2Ativo = new Bitmap(m2Ativo, new Size(100, 100));
      
      m3 = Image.FromFile("img/m3.png");
      m3 = new Bitmap(m3, new Size(90, 90));

      m3Ativo = Image.FromFile("img/m3Ativo.png");
      m3Ativo = new Bitmap(m3Ativo, new Size(100, 100));
      
      // Adicionar as opções de menu
      livro = new ToolStripMenuItem();
      livro.Image = m1;
      livro.BackColor = Color.Transparent;
      livro.ImageScaling = ToolStripItemImageScaling.None; // Definir a escala da imagem para None
      livro.Click += PanelLivro;

      usuario = new ToolStripMenuItem();
      usuario.Image = m2;
      usuario.Padding = new Padding(50, 0, 0, 0);
      usuario.BackColor = Color.Transparent;
      usuario.ImageScaling = ToolStripItemImageScaling.None;
      usuario.Click += PanelUsuario;

      emprestimo = new ToolStripMenuItem();
      emprestimo.Image = m3;
      emprestimo.BackColor = Color.Transparent;
      emprestimo.ImageScaling = ToolStripItemImageScaling.None;
      emprestimo.Click += PanelEmprestimo;

      Controls.Add(painelgeral);
      Controls.Add(menuStrip);
      menuStrip.Items.Add(livro);
      menuStrip.Items.Add(usuario);
      menuStrip.Items.Add(emprestimo);
    }

    public void BorderSuperior()
    {
      // Configurações gerais do formulário
      FormBorderStyle = FormBorderStyle.None;

      // Configuração da barra de título personalizada
      Color customTitleBarColor = Color.Transparent;//FromArgb(200, 155, 155, 155);

      customTitleBar = new Panel();
      // customTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      customTitleBar.BackColor = customTitleBarColor;
      customTitleBar.Dock = DockStyle.Top;
      customTitleBar.Height = 50; // Defina a altura desejada da barra de título
      customTitleBar.Width = Screen.PrimaryScreen.Bounds.Width; // Defina a largura do painel para a largura da tela

      // Configuração do botão de fechar
      closeButton = new Button();

      closeButton.FlatAppearance.MouseOverBackColor = Color.Red;
      closeButton.Cursor = Cursors.Hand;

      closeButton.Font = new Font("Segoe UI Symbol", 20);
      closeButton.Text = "❌";
      closeButton.ForeColor = Color.GhostWhite;
      closeButton.BackColor = Color.Transparent;
      closeButton.FlatStyle = FlatStyle.Flat;
      closeButton.FlatAppearance.BorderSize = 0;
      closeButton.Dock = DockStyle.Right;
      closeButton.Width = 40; // Defina a largura desejada para o botão de fechar


      // Associa o evento de clique do botão de fechar
      closeButton.Click += (sender, e) => Close();

      // Adiciona os controles ao painel da barra de título personalizada
      customTitleBar.Controls.Add(closeButton);

      // Adiciona o painel da barra de título ao formulário e envia-o para a parte superior do z-order
      Controls.Add(customTitleBar);
      customTitleBar.SendToBack();
    }
    
    private void PanelLivro(object sender, EventArgs e)
    {
      ShowView(livroView);

      // Altere a imagem para o item do menu ativo
      livro.Image = m1Ativo;
      usuario.Image = m2;
      emprestimo.Image = m3;
    }

    private void PanelUsuario(object sender, EventArgs e)
    {
      ShowView(usuarioView);
      usuario.Image = m2Ativo;
      livro.Image = m1;
      emprestimo.Image = m3;
    }

    private void PanelEmprestimo(object sender, EventArgs e)
    {
      ShowView(emprestimoView);
      emprestimo.Image = m3Ativo;
      usuario.Image = m2;
      livro.Image = m1;
    }

    private void ShowView(UserControl view)
    {
      if (!painelgeral.Controls.Contains(view))
      {
        painelgeral.SuspendLayout();
        painelgeral.Controls.Clear();
        painelgeral.Controls.Add(view);
        view.Dock = DockStyle.Fill;
        painelgeral.ResumeLayout();
      }
    }
    private void AoFechar(object sender, FormClosedEventArgs e)
    {
      this.parent.Show();
      /* this.Close(); */
    }
  }

  // Classe personalizada para evitar a mudança de cor ao passar o mouse sobre os itens do menu
  public class CustomColorTable : ProfessionalColorTable
  {
    public override Color MenuItemBorder => Color.Transparent;
    public override Color MenuItemSelected => Color.Transparent;
    public override Color MenuItemSelectedGradientBegin => Color.Transparent;
    public override Color MenuItemSelectedGradientEnd => Color.Transparent;
    public override Color MenuItemPressedGradientBegin => Color.Transparent;
    public override Color MenuItemPressedGradientEnd => Color.Transparent;
    public override Color MenuItemPressedGradientMiddle => Color.Transparent;
  }
}
