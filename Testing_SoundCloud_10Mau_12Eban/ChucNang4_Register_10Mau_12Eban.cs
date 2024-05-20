using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
///Các Phương thức định nghĩa
using MAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using MTestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;


namespace Testing_SoundCloud_10Mau_12Eban
{
    /// <summary>
    /// Summary description for ChucNang4__Register_10Mau_12Eban
    /// </summary>
    [TestClass]
    public class ChucNang4_Register_10Mau_12Eban
    {

        public PhuongThucDungChung method = new PhuongThucDungChung();
        ///Tạo đối tượng TestContext và khai báo get set
        public MTestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\RegisterData\DataTestCase4TH1.csv",
           "DataTestCase4TH1#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(1)]///Testcase sẽ chạy đầu tiên trong UnitTest
        public void TC4_1_Dang_Ki_Thanh_Cong()
        {
            // Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string email = TestContext.DataRow[1].ToString();
            string pass1 = TestContext.DataRow[2].ToString();
            string pass2 = TestContext.DataRow[3].ToString();


            // Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.RegisterWithNoAds(username, email, pass1, pass2);

            // Lấy url thực tế là url sau khi click button Đăng kí 
            string actualurl = method.driver.Url;

            // Đặt Url kì vọng theo đặc tả
            string expectedurl = "https://hopamviet.vn/auth/login.html";

            // So sánh Url kì vọng so với thực tế
            MAssert.AreEqual(expectedurl, actualurl);
            // Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);

            // Đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }



        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\RegisterData\DataTestCase4TH2.csv",
           "DataTestCase4TH2#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(2)]///Testcase sẽ chạy đầu tiên trong UnitTest
        public void TC4_2_Dang_Ki_That_Bai_Do_Email()
        {
            // Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string email = TestContext.DataRow[1].ToString();
            string pass1 = TestContext.DataRow[2].ToString();
            string pass2 = TestContext.DataRow[3].ToString();


            // Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.RegisterWithNoAds(username, email, pass1, pass2);

            //Lấy thông báo khi đăng kí thất bại
            string resultactual = method.ResultCanRegist();

            // Đặt thông báo kì vọng theo đặc tả
            string expectedresult = "The Địa chỉ email field must contain a unique value.";

            // So sánh Url kì vọng so với thực tế
            MAssert.AreEqual(expectedresult, resultactual);

            // Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);

            // Đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\RegisterData\DataTestCase4TH3.csv",
          "DataTestCase4TH3#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(3)]///Testcase sẽ chạy đầu tiên trong UnitTest
        public void TC4_2_Dang_Ki_That_Bai_Do_Pass()
        {
            // Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string email = TestContext.DataRow[1].ToString();
            string pass1 = TestContext.DataRow[2].ToString();
            string pass2 = TestContext.DataRow[3].ToString();


            // Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.RegisterWithNoAds(username, email, pass1, pass2);

            //Lấy thông báo khi đăng kí thất bại
            string resultactual = method.ResultCanRegist();

            // Đặt thông báo kì vọng theo đặc tả
            string expectedresult = "The Mật khẩu field does not match the Nhập lại mật khẩu field.";

            // So sánh Url kì vọng so với thực tế
            MAssert.AreEqual(expectedresult, resultactual);

            // Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);

            // Đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }
    }
}
