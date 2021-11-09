using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace App1
{
    class Program
    {
        //private static object driver;

        static void Main(string[] args)
        {

            // open chrome browser
            IWebDriver driver = new ChromeDriver();
            
            

            driver.Manage().Window.Maximize();

            // launch turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Thread.Sleep(2000);
            // identify username textbox and enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            // identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // identify login button and click
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            // check if user has logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine(" successfully loggin, test passed.");
            }
            else
            {
                Console.WriteLine("Login failed, test failed.");
            }
            //click Administration tab
            IWebElement administrator = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrator.Click();

            // select Time & Material  from dropdown
            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();

            // click on Create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            //click on TypeCode drop down and select Time
            IWebElement tmDropDown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            tmDropDown.Click();
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeOption.Click();
            //Identify Code textbox  and enter Code
            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("October2021");

            //Identify Description textbox and enter Description
            IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.SendKeys("October2021");

            //Identify Price textbox and enter Price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span"));
            priceTag.Click();
            IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
            priceTextBox.SendKeys("14");

            // Enter Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);

            //check if the Time record has been created
            IWebElement gotolastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            gotolastPageButton.Click();
            Thread.Sleep(2000);

            //check the time record is present in the table as expected
            IWebElement actualcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (actualcode.Text == "October2021")
            {
                Console.WriteLine("Time recored has been created successfully");
            }
            else
            {
                Console.WriteLine("Testfailed");
            }
            

        }

    }
}
