using App1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            //click Administration tab
            IWebElement administrator = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrator.Click();

            Wait.waitToBeClickable(driver,"Xpath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a",3);

            // select Time & Material  from dropdown
            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();
        }

    }
}
