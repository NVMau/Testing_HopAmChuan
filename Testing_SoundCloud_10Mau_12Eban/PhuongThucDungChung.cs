using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace Testing_SoundCloud_10Mau_12Eban
{
    public class PhuongThucDungChung
    {
        /// Khai báo thuộc tính là public để các UnitTest dùng chung
        public IWebDriver driver = new ChromeDriver();
        public PhuongThucDungChung() { }

        /// Phương thức truy cập vào trang web https://hopamviet.vn/
        public void TruyCapTrangChu()
        {
            driver.Navigate().GoToUrl("https://hopamviet.vn/");
        }

        /// Phương thức truy cập vào trang login và thực hiện đăng nhập khi đang ở trang chủ
        public void Sign_in(string username, string password)
        {
            TruyCapTrangChu();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //Click vao menu cua web 
            IWebElement e_menu = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/nav/div/button/span")));
            e_menu.Click();
            //Click vao icon avater
            IWebElement e_iconavtar = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"MenuUser\"]/i"))); // Cập nhật lại đây nếu cần
            e_iconavtar.Click();
            //Click vao bieu tuong dang nhap
            IWebElement e_login = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"main_nav\"]/ul/li[3]/div/a[1]"))); // Cập nhật lại đây nếu cần
            e_login.Click();
            //Nhap ten nguoi dung
            IWebElement e_user = driver.FindElement(By.Name("identity"));
            e_user.SendKeys(username);
            ///Nhập password
            IWebElement e_pass = driver.FindElement(By.Name("password"));
            e_pass.SendKeys(password);
            // Click button đăng nhập
            IWebElement e_btnlogin = driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/fieldset/button"));
            e_btnlogin.Click();
        }
        public void SigninWithNoAds(string username, string password)
        {
            try
            {
                Sign_in(username, password);
            }
            catch (NoSuchElementException)
            {
                Sign_in(username, password);
            }
        }


        ///Phương thức trả về lỗi khi không đăng nhập không thành công
        public string GetAlertMessage()
        {
            IWebElement e_alertmess = driver.FindElement(By.ClassName("text-danger"));
            return e_alertmess.Text;
        }

        public string GetAlertMessageforForgotpass()
        {
            IWebElement e_alertmess = driver.FindElement(By.XPath("//*[@id=\"infoMessage\"]/p"));
            return e_alertmess.Text;
        }

        

        ///Phương thức tự động truy cập chức năng Quên mật khẩu và tự động điền Email
        public void ForgotPassword(string email)
        {
            driver.Navigate().GoToUrl("https://hopamviet.vn/auth/login.html");
            ///Truy cập vào mục quên mật khẩu
            IWebElement e_forgotpassword = driver.FindElement(By.XPath("/html/body/div[1]/div/div/a[2]"));
            e_forgotpassword.Click();
            ///Nhập email khôi phục
            IWebElement e_emailtextbox = driver.FindElement(By.XPath("//*[@id=\"email\"]"));
            e_emailtextbox.SendKeys(email);
            ///CLick nút xác nhận
            IWebElement e_submitbtn = driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/fieldset/button"));
            e_submitbtn.Click();
        }

        ///Phương thức xử lý quảng cáo của ForgotPassword 
        public void ForgotPasswordWithNoAds(string email)
        {
            try
            {
                ForgotPassword(email);
            }
            catch (ElementNotInteractableException)
            {
                ForgotPassword(email);
            }
        }

        ///Phương thức tìm kiếm bài hát
        public void SearchSong(string keywords)
        {
            ///Truy cập vào trang chủ
            TruyCapTrangChu();
            ///Tại ô tìm kiếm, nhập vào tên bài hát cần tìm kiếm và nhấn Enter
            IWebElement e_searchbox = driver.FindElement(By.XPath("/html/body/nav/div/form/div/input"));
            ///Điền vào từ khóa
            e_searchbox.SendKeys(keywords);
            ///Nhấn Enter
            e_searchbox.SendKeys(Keys.Enter);
        }


        ///Phương thức trả về bài hát được tìm thấy
        public string SongName()
        {
            IWebElement e_songname = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]"));
            string name = e_songname.Text;
            return name;
        }

        ///Phương thức trả về kết quả thông báo không có bài hát mà bạn muốn tìm (Không tồn tại bài hát) 
        public string ResultCannotFindSong()
        {
            string result;
            IWebElement e_result = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[1]"));
            ///Lấy thông báo
            result = e_result.Text;
            return result;
        }

        ///Phương thức tìm kiếm bài hát
        public void Register(string username, string email, string pass1,string pass2)
        {
            ///Truy cập vào trang chủ
            TruyCapTrangChu();
            ///Doi web load 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //Click vao menu cua web 
            IWebElement e_menu = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/nav/div/button/span")));
            e_menu.Click();
            //Click vao icon avater
            IWebElement e_iconavtar = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"MenuUser\"]/i"))); // Cập nhật lại đây nếu cần
            e_iconavtar.Click();
            IWebElement e_regist = driver.FindElement(By.XPath("//*[@id=\"main_nav\"]/ul/li[3]/div/a[2]"));
            e_regist.Click();
            IWebElement e_username = driver.FindElement(By.XPath("//*[@id=\"username\"]"));
            e_username.SendKeys(username);
            IWebElement e_email = driver.FindElement(By.XPath("//*[@id=\"email\"]"));
            e_email.SendKeys(email);
            IWebElement e_pass1 = driver.FindElement(By.XPath("//*[@id=\"password\"]"));
            e_pass1.SendKeys(pass1);
            IWebElement e_pass2 = driver.FindElement(By.XPath("//*[@id=\"password_confirm\"]"));
            e_pass2.SendKeys(pass2);
            IWebElement e_btnresgit = driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/fieldset/button"));
            e_btnresgit.Click();

        }

        public void RegisterWithNoAds(string username, string email, string pass1, string pass2)
        {
            try
            {
                Register(username, email, pass1, pass2);
            }
            catch (NoSuchElementException)
            {
                Register(username, email, pass1, pass2);
            }
        }


        ///Phương thức trả về kết quả thông báo không đăng nhập thất bại  
        public string ResultCanRegist()
        {
            string result;
            IWebElement e_result = driver.FindElement(By.Id("infoMessage"));
            ///Lấy thông báo
            result = e_result.Text;
            return result;
        }


    }
}
