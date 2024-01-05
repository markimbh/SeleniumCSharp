namespace MainProject
{
    class LoginTest : LoginPage
    {
        [Test]
        public void ValidaLoginInvalido()
        {
            LogHeader();
            PreencheEmail();
            PreencheSenha();
            ClicarEntrar();
            ValidarMsgLoginInvalido();
        }

        [Test]
        public void ValidaCamposObrigatorios() 
        {
            LogHeader();
            ClicarEntrar();
            ValidaMsgEmailObrigatorio();
            ValidaMsgSenhaObrigatoria();
        }
    }
}
