using App1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace App1
{
    class TM_Tests
    {
        //private static object driver;

        static void Main(string[] args)
        {

            // open chrome browser
            IWebDriver driver = new ChromeDriver();

            //driver.Manage().Window.Maximize();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            // Homepage object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // TMPage object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTM(driver);
            tMPageObj.EditTM(driver);
            tMPageObj.DeleteTM(driver);

        }

    }
}

