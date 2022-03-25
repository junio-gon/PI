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
            Aluno aluno = new Aluno();
            Animal animal = new Animal(); 

            if (tipo == TIPOPESSOA.ALUNO)
            {
                aluno = new Aluno() {
                    NOME = txtNome.Text,
                    EMAIL = txtEmail.Text,
                    CPF = txtCPF.Text,
                    CURSO = txtCurso.Text,
                    RA = txtRA.Text,
                    RG = txtRG.Text
                };
                ExibirObj(aluno);
            }
        }

        public void ExibirObj(Object objeto)
        {
            Aluno aluno = new Aluno();
            Animal animal = new Animal();
            string texto = "";
            if (objeto.GetType() == aluno.GetType())
            {
                aluno = (Aluno) objeto;
                texto = $"Nome: {aluno.NOME} E-mail: {aluno.EMAIL} RG: {aluno.RG} CPF: {aluno.CPF} RA: {aluno.RA} Curso: {aluno.CURSO} ";
                label1.Text = texto;
                //label1.Text = "Nome: " + aluno.NOME + " E-mail: " + aluno.EMAIL + " RG: " + aluno.RG + " CPF: " + aluno.CPF + " RA: " + aluno.RA + " Curso: " + aluno.CURSO;
                string diretorio = @"c:\exemplo";
                string[] linha = { aluno.NOME, aluno.EMAIL, aluno.RG, aluno.CPF, aluno.RA, aluno.CURSO };
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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