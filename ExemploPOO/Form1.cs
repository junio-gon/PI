namespace ExemploPOO
{
    public partial class Form1 : Form
    {
        

        private TIPOPESSOA tipo;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //(string _nome, string _rg, string _cpf, string _email)

            Pessoa pessoa = new Pessoa(txtNome.Text, txtRG.Text, txtCPF.Text, txtEmail.Text);

            ExibirObj(pessoa);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ExibirObj(Pessoa pessoa) {
            label1.Text = "Nome: " + pessoa.NOME + " E-mail: " + pessoa.EMAIL + " RG: " + pessoa.RG + " CPF: " + pessoa.CPF;
        }

        private void rbAluno_CheckedChanged(object sender, EventArgs e)
        {
            validaPessoa();
        }

        private void rbProfessor_CheckedChanged(object sender, EventArgs e)
        {
            validaPessoa();
        }

        private void validaPessoa()
        {
            if (rbAluno.Checked == true)
            {
                pnProfessor.Visible = false;
                pnAluno.Visible = true;
                this.tipo = TIPOPESSOA.ALUNO;
            }
            else if (rbProfessor.Checked == true)
            {
                pnProfessor.Visible = true;
                pnAluno.Visible = false;
                this.tipo = TIPOPESSOA.PROFESSOR;
            }
        }
    }
}