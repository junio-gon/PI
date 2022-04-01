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
            bool validaDados = validadados();

            if ((objeto.GetType() == aluno.GetType()) || validaDados)
            {
                aluno = (Aluno) objeto;
                texto = $"Nome: {aluno.NOME} E-mail: {aluno.EMAIL} RG: {aluno.RG} CPF: {aluno.CPF} RA: {aluno.RA} Curso: {aluno.CURSO} ";
                label1.Text = texto;
                //label1.Text = "Nome: " + aluno.NOME + " E-mail: " + aluno.EMAIL + " RG: " + aluno.RG + " CPF: " + aluno.CPF + " RA: " + aluno.RA + " Curso: " + aluno.CURSO;
                // no geral toda vez que tiver queries, convers�o e/ou chamada de recurso externo, utilizamos try catch
                string diretorio = @"c:\exemplo";
                if (!Directory.Exists(diretorio))
                {
                    try
                    {
                        Directory.CreateDirectory(diretorio);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao criar o diret�rio " + e.Message);
                    }
                }

                string[] linha = { aluno.NOME, aluno.EMAIL, aluno.RG, aluno.CPF, aluno.RA, aluno.CURSO };
                try
                {
                    File.WriteAllLines($"{diretorio}\\exemplo.txt", linha);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao criar o arquivo " + e.Message);
                }

                MessageBox.Show("Aluno " + aluno.NOME + " cadastrado com sucesso!!!", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        private bool validadados() {
            string mensagem = "";
            bool result = true;
            if (String.IsNullOrEmpty( txtNome.Text ) || txtNome.Text.Length == 0)
            {
                mensagem += "O campo NOME n�o pode estar vazio! \n";
                result = false;
            }
            if (String.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text.Length == 0)
            {
                mensagem += "O campo EMAIL n�o pode estar vazio! \n";
                result = false;
            }
            if (!txtEmail.Text.Contains("@") )
            {
                mensagem += "Utilize um e-mail v�lido! \n";
                result = false;
            }
            if (!result)
            {
                MessageBox.Show(mensagem, "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result; 
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