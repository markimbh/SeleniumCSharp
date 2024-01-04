namespace MainProject
{
    class LoginFailTest : LoginPage
    {
        [Test]
        public void ValidaLogin()
        {
            LogHeader();
            PreencheEmail();
            PreencheSenha();
            ClicarEntrar();
            ValidarMsgLoginInvalido();
        }
    }
}
