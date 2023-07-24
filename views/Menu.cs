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
    private Image m2;
    private Image m3;

    // Variáveis para as views
    private Livro livroView;
    private Usuario usuarioView;
    private Emprestimo emprestimoView;
    private Form parent;

    public Menu(Form parent)
    {
      this.parent = parent;

      // ...
      FormPrincipal();
      PanelMenu();

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
      menuStrip.Dock = DockStyle.Top;
      menuStrip.BackColor = Color.Transparent;
      menuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());

      m1 = Image.FromFile("img/m1.png");
      m1 = new Bitmap(m1, new Size(90, 90));

      m2 = Image.FromFile("img/m2.png");
      m2 = new Bitmap(m2, new Size(90, 90));

      m3 = Image.FromFile("img/m3.png");
      m3 = new Bitmap(m3, new Size(90, 90));

      // Adicionar as opções de menu
      ToolStripMenuItem livro = new ToolStripMenuItem();
      livro.Image = m1;
      livro.BackColor = Color.Transparent;
      livro.ImageScaling = ToolStripItemImageScaling.None; // Definir a escala da imagem para None
      livro.Click += PanelLivro;

      ToolStripMenuItem usuario = new ToolStripMenuItem();
      usuario.Image = m2;
      usuario.BackColor = Color.Transparent;
      usuario.ImageScaling = ToolStripItemImageScaling.None;
      usuario.Click += PanelUsuario;

      ToolStripMenuItem emprestimo = new ToolStripMenuItem();
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

    private void PanelLivro(object sender, EventArgs e)
    {
      ShowView(livroView);
    }

    private void PanelUsuario(object sender, EventArgs e)
    {
      ShowView(usuarioView);
    }

    private void PanelEmprestimo(object sender, EventArgs e)
    {
      ShowView(emprestimoView);
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
