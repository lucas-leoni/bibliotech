using System;
using System.Windows.Forms;

namespace Views
{
  public class Login : Form
  {
    private Menu menu;
    private Label lblUsuario;
    private TextBox inpUsuario;
    private Label lblSenha;
    private TextBox inpSenha;
    private Button bntLogin;
    private CheckBox cbxExibirSenha;
    public Login()
    {
      MaximizeBox = false;
      StartPosition = FormStartPosition.CenterScreen;
      BackgroundImage = Image.FromFile("img/fundo.png");
      BackgroundImageLayout = ImageLayout.Stretch;
      lblUsuario = new Label();
      lblUsuario.ForeColor = Color.White;
      lblUsuario.BackColor = Color.Transparent;
      lblUsuario.Text = "Usuário:";
      lblUsuario.Location = new System.Drawing.Point(90, 75);

      inpUsuario = new TextBox();
      inpUsuario.Location = new System.Drawing.Point(
        lblUsuario.Location.X,
        lblUsuario.Location.Y + 25
      );
      inpUsuario.Name = "inpUsuario";
      inpUsuario.Size = new System.Drawing.Size(200, 25);

      lblSenha = new Label();
      lblSenha.BackColor = Color.Transparent;
      lblSenha.ForeColor = Color.White;
      lblSenha.Text = "Senha:";
      lblSenha.Location = new System.Drawing.Point(
        inpUsuario.Location.X,
        inpUsuario.Location.Y + 35
      );

      inpSenha = new TextBox();
      inpSenha.Location = new System.Drawing.Point(
        lblSenha.Location.X,
        lblSenha.Location.Y + 25
      );
      inpSenha.Name = "inpSenha";
      inpSenha.UseSystemPasswordChar = true;
      inpSenha.Size = new System.Drawing.Size(200, 25);

      cbxExibirSenha = new CheckBox();
      cbxExibirSenha.BackColor = Color.Transparent;
      cbxExibirSenha.ForeColor = Color.White;
      cbxExibirSenha.Location = new System.Drawing.Point(
        inpSenha.Location.X,
        inpSenha.Location.Y + 35
      );
      cbxExibirSenha.Name = "cbxExibirSenha";
      cbxExibirSenha.Text = "Exibir senha";
      cbxExibirSenha.Size = new System.Drawing.Size(200, 25);
      cbxExibirSenha.CheckedChanged += AlternarExibicaoSenha;

      bntLogin = new Button();
      bntLogin.Text = "Entrar";
      bntLogin.Location = new System.Drawing.Point(
        cbxExibirSenha.Location.X + 60,
        cbxExibirSenha.Location.Y + 55
      );
      bntLogin.Click += Logar;

      // Título da janela
      this.Text = "Login";

      // Tamanho da janela
      this.Size = new System.Drawing.Size(400, 400);

      // Adicionando em tela
      Controls.Add(lblUsuario);
      Controls.Add(inpUsuario);
      Controls.Add(lblSenha);
      Controls.Add(inpSenha);
      Controls.Add(cbxExibirSenha);
      Controls.Add(bntLogin);
    }

    private void AlternarExibicaoSenha(object sender, EventArgs e)
    {
      inpSenha.UseSystemPasswordChar = !cbxExibirSenha.Checked;
    }

    public void Limpar()
    {
      // Limpando o texto dos inputs
      inpUsuario.Clear();
      inpSenha.Clear();
      cbxExibirSenha.Checked = false;
    }

    private void Logar(object sender, EventArgs e)
    {
      string login = inpUsuario.Text;
      string senha = inpSenha.Text;

      if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
      {
        MessageBox.Show(
          "Preencha seu usuário e senha!",
          "Erro!",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );
      }
      else if (login != "admin" && senha != "admin")
      {
        MessageBox.Show(
          "Usuário e senha incorretos!",
          "Erro!",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );
      }
      else if (login != "admin")
      {
        MessageBox.Show(
          "Usuário incorreto!",
          "Erro!",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );
      }
      else if (senha != "admin")
      {
        MessageBox.Show(
          "Senha incorreta!",
          "Erro!",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );
      }
      else
      {
        Limpar();
        menu = new Menu(this);
        menu.Show();
        this.Hide();
      }
    }
  }
}