using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using MTestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace Testing_SoundCloud_10Mau_12Eban
{
    [TestClass]
    public class ChucNang2_Forgot_password_10Mau_12Eban
    {
        private PhuongThucDungChung method = new PhuongThucDungChung();

        public MTestContext TestContext { get; set; }

        ///Testcase 2.1: Khôi phục mật khẩu thành công nhập đúng mail
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\ForgotPassData\DataTestCase2TH1.csv",
            "DataTestCase2TH1#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(1)]///Testcase sẽ chạy đầu tiên trong UnitTest
        public void TC2_1_Khoi_Phuc_Thanh_Cong()
        {
            ///Đọc dữ liệu đầu vào
            string email = TestContext.DataRow[0].ToString();
            ///Truy cập vào trang quên mật khẩu
            method.ForgotPasswordWithNoAds(email);
            ///url thực tế: url sau khi click button Xác nhận
            string urlactual = method.driver.Url;
            ///url kì vọng
            string urlexpected = "https://hopamviet.vn/auth/login.html";
            ///So sánh url thực tế và url kì vọng
            MAssert.AreEqual(urlexpected, urlactual);
            /// Dừng 5 giây rồi đóng Chrome
            Thread.Sleep(3000);
            // đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }

        ///Testcase 2.2: Khôi phục mật khẩu thất bại vì không nhập đúng email
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\ForgotPassData\DataTestCase2TH2.csv",
           "DataTestCase2TH2#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(2)]///Testcase sẽ chạy thứ 2 trong Unittest
        public void TC2_2_Khoi_Phuc_That_Bai_Do_Email_Sai()
        {
            ///Đọc dữ liệu đầu vào
            string email = TestContext.DataRow[0].ToString();
            ///Truy cập vào trang quên mật khẩu
            method.ForgotPasswordWithNoAds(email);
            ///url thực tế: url sau khi click button Xác nhận
            string urlactual = method.driver.Url;
            ///url kì vọng
            string urlexpected = "https://hopamviet.vn/auth/forgot_password.html";
            ///So sánh url thực tế và url kì vọng
            MAssert.AreEqual(urlexpected, urlactual);
            ///Kiểm tra câu lỗi 
            MAssert.IsTrue(method.GetAlertMessageforForgotpass().Contains("Không tìm thấy email này."));
            /// Dừng 5 giây rồi đóng Chrome
            Thread.Sleep(3000);
            // đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }



    }
}
