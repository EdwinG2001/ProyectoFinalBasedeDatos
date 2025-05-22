namespace ProyectoGrupo5
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            labelogeado1.Text = $"Logeado: {UsuarioSesion.NombreUsuario}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sobrenosotros nuevoForm = new Sobrenosotros();
            nuevoForm.Show();
            this.Hide();
        }
        private void btnpasar_Click(object sender, EventArgs e)
        {
            Inicio1 newForm = new Inicio1();
            newForm.Show();
            this.Hide();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login newForm = new Login();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifiqueEvento newForm = new ModifiqueEvento();
            newForm.Show();
            this.Hide();
        }
    }
}