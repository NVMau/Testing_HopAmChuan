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
    /// Summary description for ChucNang3_Seach_10Mau_12EBan
    /// </summary>
    [TestClass]
    public class ChucNang3_Search_10Mau_12EBan
    {

        public PhuongThucDungChung method = new PhuongThucDungChung();
        ///Tạo đối tượng TestContext và khai báo get set
        public MTestContext TestContext { get; set; }

        ///Testcase 3.1: Tìm kiếm bài hát thành công
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\SearchData\DataTestCase3TH1.csv",
           "DataTestCase3TH1#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(1)]///Testcase sẽ chạy đầu tiên trong UnitTest
        public void TC3_1_Tim_Kiem_Thanh_Cong()
        {
            ///Đọc dữ liệu đầu vào
            string keywords = TestContext.DataRow[0].ToString();
            /// Tìm bài hát tên là: Happy new year
            method.SearchSong(keywords);
            ///Kiểm tra xem bài hát trả về có tên giống như keywords hay không
            MAssert.IsNotNull(method.SongName());
            /// Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            // đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }


        ///Testcase 3.2: Tìm kiếm bài hát thất bại vì bài hát không tồn tại
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\SearchData\DataTestCase3TH2.csv",
   "DataTestCase3TH2#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(1)]///Testcase sẽ chạy thứ 2 trong UnitTest
        public void TC3_2_Tim_Kiem_That_Bai_Vi_Bai_Hat_Khong_Ton_Tai()
        {
            ///Đọc dữ liệu đầu vào
            string keywords = TestContext.DataRow[0].ToString();
            /// Tìm bài hát tên là: Happy new year
            method.SearchSong(keywords);
            string resultactual = method.ResultCannotFindSong();
            string resultexxpected = "Không tìm thấy bài hát nào phù hợp với yêu cầu.";
            MAssert.AreEqual(resultexxpected, resultactual);
            /// Dừng 3 giây rồi đóng Chrome
            Thread.Sleep(3000);
            // đóng trình duyệt sau khi thực hiện xong test case
            method.driver.Quit();
        }

    }
        
}
