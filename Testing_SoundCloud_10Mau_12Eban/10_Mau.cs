using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

using MAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;//Kiểm tra đúng sai của trang

namespace Testing_SoundCloud_10Mau_12Eban
{
    /// <summary>
    /// Summary description for _10_Mau
    /// </summary>
    [TestClass]
    public class _10_Mau
    {
        public IWebDriver driver = new ChromeDriver();



        [TestMethod, Order(1)]///Testcase sẽ chạy đầu tiên trong UnitTest
        public void TC1_1_10_MauLogin_Thanh_Cong()
        {
            driver.Navigate().GoToUrl("https://hopamviet.vn/");

  
            // Đọc dữ liệu đầu vào
            string username_10_Mau = "trackmix118@gmail.com";
            string password_10_Mau = "testingprojetmaueban";

            // wait Dung de dợi đối tượng đó xuất hiện 
           
            try
            {
                driver.Navigate().GoToUrl("https://hopamviet.vn/");
                // wait Dung de dợi đối tượng đó xuất hiện 
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //Click vao menu cua web 
                IWebElement e_menu_10_Mau = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/nav/div/button/span")));
                e_menu_10_Mau.Click();
                //Click vao icon avater
                IWebElement e_iconavtar_10_Mau = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"MenuUser\"]/i"))); // Cập nhật lại đây nếu cần
                e_iconavtar_10_Mau.Click();
                //Click vao bieu tuong dang nhap
                IWebElement e_login_10_Mau = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"main_nav\"]/ul/li[3]/div/a[1]"))); // Cập nhật lại đây nếu cần
                e_login_10_Mau.Click();

            }
            catch (NoSuchElementException)
            {
                driver.Navigate().GoToUrl("https://hopamviet.vn/");
                // wait Dung de dợi đối tượng đó xuất hiện 
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //Click vao menu cua web 
                IWebElement e_menu_10_Mau = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/nav/div/button/span")));
                e_menu_10_Mau.Click();
                //Click vao icon avater
                IWebElement e_iconavtar_10_Mau = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"MenuUser\"]/i"))); // Cập nhật lại đây nếu cần
                e_iconavtar_10_Mau.Click();
                //Click vao bieu tuong dang nhap
                IWebElement e_login_10_Mau = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"main_nav\"]/ul/li[3]/div/a[1]"))); // Cập nhật lại đây nếu cần
                e_login_10_Mau.Click();
            }
            //Nhap ten nguoi dung
            IWebElement e_user_10_Mau = driver.FindElement(By.Name("identity"));
            e_user_10_Mau.SendKeys(username_10_Mau);
            ///Nhập password
            IWebElement e_pass_10_Mau = driver.FindElement(By.Name("password"));
            e_pass_10_Mau.SendKeys(password_10_Mau);
            // Click button đăng nhập
            IWebElement e_btnlogin_10_Mau = driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/fieldset/button"));
            e_btnlogin_10_Mau.Click();
            // Lấy url thực tế là url sau khi click button Đăng nhập
            string actualurl_10_Mau = driver.Url;

            // Đặt Url kì vọng theo đặc tả
            string expectedurl_10_Mau = "https://hopamviet.vn/";

            // So sánh Url kì vọng so với thực tế
            MAssert.AreEqual(expectedurl_10_Mau, actualurl_10_Mau);
            // Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);

            // Đóng trình duyệt sau khi thực hiện xong test case
            driver.Quit();
        }
    }
}
