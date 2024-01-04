using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;

namespace ServeRest.Project.Core
{
    public class DSL : LogSystem
    {
        #region Funções de manipulação
        public static void Wait(int ms) => Thread.Sleep(ms);

        public void ClearData(string xpath)
        {
            var element = driver.FindElement(By.XPath(xpath));
            var act = new Actions(driver);

            act.DoubleClick(element).Build().Perform();
            element.SendKeys(Keys.Delete);
        }

        public void WaitElement(string xpath, int seconds = 90) 
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => d.FindElements(By.XPath(xpath)));
            Wait(1000);
        }

        public void WaitElementGone(string xpath, int seconds = 90)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => d.FindElements(By.XPath(xpath)).Count == 0);
        }
        #endregion

        #region Funções de interação
        public void ClicaElemento(string xpath, [Optional] string description, int timer = 1000)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).Click();
                Wait(timer);
                if (description != null) Log($"Clicou em {description}");
            }
            catch (Exception ex) 
            {
                testPassed = false;
                var msgErr = $"Erro ao clicar em {description}";
                if (description != null) Log($"{msgErr} {ex.Message}");
                Assert.Fail(msgErr);
            }
        }

        public void EscreveTexto(string xpath, string value, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).SendKeys(value);
                if (description != null) Log($"Preencheu {description}");
            }
            catch (Exception ex)
            {
                testPassed = false;
                var msgErr = $"Erro ao preencher {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}");
                Assert.Fail(msgErr);
            }
        }

        public void ValidaDados(string xpath, string value, [Optional] string description)
        {
            try
            {
                Assert.That(driver.FindElement(By.XPath(xpath)).Text, Does.Contain(value));
                if (description != null) Log($"Validou {description}");
            }
            catch (Exception ex)
            {
                testPassed = false;
                var msgErr = $"Erro ao validar {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}");
                Assert.Fail(msgErr);
            }
        }



        #endregion
    }
}
