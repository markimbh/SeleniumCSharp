namespace MainProject
{
    class CadastroPage : PageObjects
    {
        public void LogHeader() =>
           Log("<b>TESTE:</b> Cadastra Usuário<b><br>" +
               "<b>=======================</b><br>");
        public void ClicarLinkCadastro()
        {
            ClicaElemento("//*[@id=\"root\"]/div/div/form/small/a", "Cadastre-se");
        }

        public void DigitaNome()
        {
            var faker = new Faker("pt_BR");
            var fakerName = faker.Name.FullName();

            EscreveTexto("//*[@id=\"nome\"]", fakerName, $"nome {fakerName}");
        }

        public void DigitaEmail()
        {
            var faker = new Faker("pt_BR");
            var fakerEmail = faker.Internet.Email();

            EscreveTexto("//*[@id=\"email\"]", fakerEmail, $"e-mail {fakerEmail}");
        }

        public void DigitaSenha()
        {
            var faker = new Faker();
            var fakerSenha = faker.Internet.Password();

            EscreveTexto("//*[@id=\"password\"]", fakerSenha, $"senha {fakerSenha}");
        }

        public void ClicarBotaoCadastrar()
        {
            ClicaElemento("//*[@id=\"root\"]/div/div/form/div[5]/button", "botão Cadastrar");
        }

        public void ValidarMsgSucessoCadastro()
        {
            var msg = "Cadastro realizado com sucesso";
            ValidaDados("//*[contains(text(),'Cadastro realizado com sucesso')]", msg, $"mensagem de sucesso do cadastro");
        }
    }
}
