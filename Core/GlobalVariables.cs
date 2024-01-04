namespace ServeRest.Project.Core
{
    public class GlobalVariables
    {
        public IWebDriver driver;

        public bool driverQuit = true;

        public bool headless = false;

        public string downloadPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads";

        public bool testPassed = true;
    }
}
