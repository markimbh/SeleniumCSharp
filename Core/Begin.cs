global using NUnit.Framework;
global using OpenQA.Selenium;
global using ServeRest.Project.Core;
global using Bogus;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System.Diagnostics;
using System.IO.Enumeration;



namespace ServeRest.Project.Core
{
    public class Begin : DSL
    {
        public void AbreNavegador()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            var devMode = new ChromeOptions();
            devMode.AddArgument("disable-cache");
            devMode.AddArgument("start-maximized");

            var headlessMode = new ChromeOptions();
            headlessMode.AddArgument("disable-cache");
            headlessMode.AddArgument("window-size=1920x1080");
            headlessMode.AddUserProfilePreference("download.default_directory", downloadPath);
            headlessMode.AddArgument("headless");

            if (headless) driver = new ChromeDriver(headlessMode);
            else driver = new ChromeDriver(devMode);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void FechaNavegador()
        {
            if (driverQuit) driver.Quit();
            else
            {
                ProcessStartInfo psi = new() { FileName = "taskkill", Arguments = "/F /IM chromedriver.exe" };
                using Process process = new() { StartInfo = psi };
                process.Start(); process.WaitForExit();
            }
        }


        [SetUp]
        public void Start()
        {
            AbreNavegador();
            driver.Navigate().GoToUrl("https://front.serverest.dev/login");
        }

       

      


        [TearDown]

        public void Finish() 
        {
            SaveLog();
            FechaNavegador();
        }
    }
}