using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// Các Phương thức định nghĩa
using MAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using MTestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace Testing_SoundCloud_10Mau_12Eban
{
    /// <summary>
    /// Summary description for ChucNang1_Login_10Mau_12Eban
    /// </summary>
    [TestClass]
    public class ChucNang1_Login_10Mau_12Eban
    {
        // Khai báo lớp dùng chung 
        public PhuongThucDungChung method = new PhuongThucDungChung();

        // Tạo đối tượng TestContext và khai báo phương thức get set
        public MTestContext TestContext { get; set; }

        /// TestCase 1.1: Đăng nhập thành công với username và password đúng
        /// Khai báo DataSource, file dữ liệu đầu vào 
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\SigninData\DataTestCase1TH1.csv",
            "DataTestCase1TH1#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(1)]///Testcase sẽ chạy đầu tiên trong UnitTest
        public void TC1_1_Login_Thanh_Cong()
        {
            // Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();

            // Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.SigninWithNoAds(username, password);

            // Lấy url thực tế là url sau khi click button Đăng nhập
            string actualurl = method.driver.Url;

            // Đặt Url kì vọng theo đặc tả
            string expectedurl = "https://hopamviet.vn/";

            // So sánh Url kì vọng so với thực tế
            MAssert.AreEqual(expectedurl, actualurl);
            // Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);

            // Đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\SigninData\DataTestCase1TH2.csv",
                    "DataTestCase1TH2#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(2)]///Testcase sẽ chạy thứ 2 trong UnitTest
        public void TC1_2_Login_That_Bai_Khong_Nhap_UserName()
        {
            ///Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.SigninWithNoAds(username, password);
            ///Cảnh báo thực tế: Cảnh báo sau khi nhấn button Đăng nhập
            string actalert = method.GetAlertMessage();
            ///Cảnh báo kỳ vọng
            string expectalert = "The Email/Tên đăng nhập field is required.";
            ///So sánh cảnh báo kỳ vọng và cảnh báo thực tế
            MAssert.AreEqual(expectalert, actalert);
            /// Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            /// Đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }

        ///TestCase 1.3: Đăng nhập không thành công do không nhập password
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\SigninData\DataTestCase1TH3.csv",
            "DataTestCase1TH3#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(3)]///Testcase sẽ chạy thứ 3 trong UnitTest
        public void TC1_3_Login_That_Bai_Khong_Nhap_PassWord()
        {
            ///Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.SigninWithNoAds(username, password);
            ///Cảnh báo thực tế: Cảnh báo sau khi nhấn button Đăng nhập
            string actalert = method.GetAlertMessage();
            ///Cảnh báo kỳ vọng
            string expectalert = "The Password field is required.";
            MAssert.AreEqual(expectalert, actalert);
            /// Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            /// Đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }

        //TestCase 1.4: Đăng nhập không thành công với username chưa đăng ký
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\SigninData\DataTestCase1TH4.csv",
                      "DataTestCase1TH4#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(4)]///Testcase sẽ chạy thứ 4 trong UnitTest
        public void TC1_4_Login_That_Bai_UserName_Chua_Dang_Ky()
        {
            ///Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.SigninWithNoAds(username, password);
            ///Cảnh báo thực tế: Cảnh báo sau khi nhấn button Đăng nhập
            string actalert = method.GetAlertMessage();
            ///Cảnh báo kỳ vọng
            string expectalert = "Đăng nhập không thành công";
            MAssert.AreEqual(expectalert, actalert);
            /// Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            /// Đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }

        //TestCase 1.5: Đăng nhập không thành công với password sai
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\SigninData\DataTestCase1TH5.csv",
                    "DataTestCase1TH5#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(5)]///Testcase sẽ chạy thứ 5 trong UnitTest
        public void TC1_5_Login_That_Bai_UserNameDung_MatKhauSai()
        {
            ///Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.SigninWithNoAds(username, password);
            ///Cảnh báo thực tế: Cảnh báo sau khi nhấn button Đăng nhập
            string actalert = method.GetAlertMessage();
            ///Cảnh báo kỳ vọng
            string expectalert = "Đăng nhập không thành công";
            MAssert.AreEqual(expectalert, actalert);
            /// Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            /// Đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }


    }
}