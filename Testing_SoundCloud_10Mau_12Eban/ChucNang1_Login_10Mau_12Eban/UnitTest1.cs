using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace ChucNang1_Login_10Mau_12Eban
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin_10Mau_12_Eban()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://soundcloud.com/");



        }
    }
}
