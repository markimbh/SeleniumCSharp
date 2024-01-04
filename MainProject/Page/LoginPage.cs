namespace MainProject
{
    class LoginPage : PageObjects
    {
        public void LogHeader() =>
            Log("<b>TESTE:</b> Valida login<b><br>" +
                "<b>=======================</b><br>");

        public void PreencheEmail()
        {
            var email = "teste@teste.com";
            EscreveTexto("//*[@id='email']", email, $"campo E-mail: {email}");

        }

        public void PreencheSenha()
        {
            var senha = "33**3/";
            EscreveTexto("//*[@id='password']", senha, $"campo Senha: {senha}");
        }

        public void ClicarEntrar()
        {
            ClicaElemento("//*[@id='root']/div/div/form/button", $"botão Entrar");
        }

        public void ValidarMsgLoginInvalido()
        {
            var msg = "Email e/ou senha inválidos";
            ValidaDados("//*[@id='root']/div/div/form/div[1]/span", msg, $"mensagem de login ou senha inválidos");
        }
    }

    
}
