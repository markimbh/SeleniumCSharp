namespace MainProject
{
    class CadastroTest : CadastroPage
    {
        [Test]
        public void CadastrarUsuario()
        {
            LogHeader();
            ClicarLinkCadastro();
            DigitaNome();
            DigitaEmail();
            DigitaSenha();
            ClicarBotaoCadastrar();
            ValidarMsgSucessoCadastro();
        }
    }
}
