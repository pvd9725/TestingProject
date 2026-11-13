using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using Assert = NUnit.Framework.Assert;

namespace WebDriverTest_17_Dieu
{
    [TestClass]
    public class AutomationExerciseTests_17_Dieu
    {
        private IWebDriver driver_17_Dieu;
        private WebDriverWait wait_17_Dieu;
        private const string BASE_URL_17_Dieu = "https://automationexercise.com";
        [SetUp]
        public void Setup_17_Dieu()
        {
            ChromeOptions options_17_Dieu = new ChromeOptions();

            //Mở trình duyệt ở chế độ toàn màn hình
            options_17_Dieu.AddArgument("--start-maximized");
            //Tắt thông báo của trình duyệt
            options_17_Dieu.AddArgument("--disable-notifications");
            //khởi tạo Chrome 
            driver_17_Dieu = new ChromeDriver(options_17_Dieu);
            //Chờ tối đa 15s
            wait_17_Dieu = new WebDriverWait(driver_17_Dieu, TimeSpan.FromSeconds(15));
            //Truy cập website
            driver_17_Dieu.Navigate().GoToUrl(BASE_URL_17_Dieu);
            // chờ trang load 1,5s
            Thread.Sleep(1500);
        }
        private IWebElement WaitAndFind_17_Dieu(By locator_17_Dieu)
        {
            //Hàm tìm phần tử có chờ
            return wait_17_Dieu.Until(d_17_Dieu => d_17_Dieu.FindElement(locator_17_Dieu));
        }
        private void ClickElement_17_Dieu(By locator_17_Dieu)
        {
            //Tìm phần tử trước sau đó hành động click
            WaitAndFind_17_Dieu(locator_17_Dieu).Click();

        }
        private void TypeText_17_Dieu(By locator_17_Dieu, string text_17_Dieu)
        {
            IWebElement el_17_Dieu = WaitAndFind_17_Dieu(locator_17_Dieu);
            el_17_Dieu.Clear();
            el_17_Dieu.SendKeys(text_17_Dieu);
        }
        // hàm kiểm tra element có hiển thị không
        private bool IsElementVisible_17_Dieu(By locator_17_Dieu)
        {
            try
            {
                return wait_17_Dieu.Until(d_17_Dieu => d_17_Dieu.FindElement(locator_17_Dieu)).Displayed;
            }
            catch
            {
                return false;
            }
        }
        //Hàm xử lý dropdown chọn theo text
        private void SelectByText_17_Dieu(By locator_17_Dieu, string visibleText_17_Dieu)
        {
            IWebElement el_17_Dieu = WaitAndFind_17_Dieu(locator_17_Dieu);
            SelectElement dropdown_17_Dieu = new SelectElement(el_17_Dieu);
            dropdown_17_Dieu.SelectByText(visibleText_17_Dieu);
        }
        // Hàm xử lý dropdown chọn theo value
        private void SelectByValue_17_Dieu(By locator_17_Dieu, string value_17_Dieu)
        {
            IWebElement el_17_Dieu = WaitAndFind_17_Dieu(locator_17_Dieu);
            SelectElement dropdown_17_Dieu = new SelectElement(el_17_Dieu);
            dropdown_17_Dieu.SelectByValue(value_17_Dieu);
        }
        //Hàm xử lý dropdwon chọn theo index
        private void SelectByIndex_17_Dieu(By locator_17_Dieu, int index_17_Dieu)
        {
            IWebElement el_17_Dieu = WaitAndFind_17_Dieu(locator_17_Dieu);
            SelectElement dropdown_17_Dieu = new SelectElement(el_17_Dieu);
            dropdown_17_Dieu.SelectByIndex(index_17_Dieu);
        }
        private void ScrollToElement_17_Dieu(IWebElement element)
        {
            IJavaScriptExecutor js_17_Dieu = (IJavaScriptExecutor)driver_17_Dieu;
            js_17_Dieu.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        //[Test]
        //public void TC01_LoginSuccess_17_Dieu()
        //{
        //    // Nhấn vào nút Login dùng cssSelector
        //    ClickElement_17_Dieu(By.CssSelector("a[href='/login']"));
        //    //Điền email và mật khẩu hợp lệ dùng name
        //    TypeText_17_Dieu(By.Name("email"), "dp1.1a2dieu@gmail.com");
        //    TypeText_17_Dieu(By.Name("password"), "123");
        //    // Nhấn click login
        //    ClickElement_17_Dieu(By.CssSelector("button[data-qa='login-button']"));

        //    bool isLoggedIn_17_Dieu = IsElementVisible_17_Dieu(
        //        By.XPath("//li//a[contains(., 'Logged in as')]"));
        //    Assert.That(isLoggedIn_17_Dieu, Is.True, "thông báo lỗi");

        //}
        //[Test]
        //public void TC02_LoginWrongPassword_17_Dieu()
        //{
        //    ClickElement_17_Dieu(By.XPath("//a[@href='/login']"));

        //    TypeText_17_Dieu(By.XPath("//input[@data-qa='login-email']"), "dp1.1a2dieu@gmail.com");
        //    TypeText_17_Dieu(By.XPath("//input[@data-qa='login-password']"), "saimk");

        //    ClickElement_17_Dieu(By.XPath("//button[@data-qa='login-button']"));


        //    bool hasError_17_Dieu = IsElementVisible_17_Dieu(
        //        By.XPath("//p[contains(text(),'Your email or password is incorrect!')]"));

        //    Assert.That(hasError_17_Dieu, Is.True,
        //        "TC002 FAILED: Khong hien thi thong bao loi khi dang nhap sai mat khau.");
        //}
        //[Test]
        //public void TC03_LoginEmptyEmail_17_Dieu()
        //{
        //    ClickElement_17_Dieu(By.XPath("//a[@href='/login']"));

        //    TypeText_17_Dieu(By.XPath("//input[@data-qa='login-password']"), "123");

        //    ClickElement_17_Dieu(By.XPath("//button[@data-qa='login-button']"));


        //    bool stillOnLoginPage_17_Dieu = driver_17_Dieu.Url.Contains("/login");
        //    Assert.That(stillOnLoginPage_17_Dieu, Is.True,
        //        "TC003 FAILED: He thong cho phep dang nhap khi email trong.");

        //}
        //[Test]
        //public void TC04_LoginEmptyPassword_17_Dieu()
        //{
        //    ClickElement_17_Dieu(By.XPath("//a[@href='/login']"));

        //    TypeText_17_Dieu(By.XPath("//input[@data-qa='login-email']"), "dp1.1a2dieu@gmail.com");

        //    ClickElement_17_Dieu(By.CssSelector("button[data-qa='login-button']"));


        //    bool stillOnLoginPage_17_Dieu = driver_17_Dieu.Url.Contains("/login");
        //    Assert.That(stillOnLoginPage_17_Dieu, Is.True,
        //        "TC003 FAILED: He thong cho phep dang nhap khi password trong.");

        //}
        //[Test]
        //public void TC05_SearchWithResult_17_Dieu()
        //{
        //Vào trang products    
        //    ClickElement_17_Dieu(By.XPath("//a[@href='/products']"));
        //Nhập từ khóa : dress
        //    TypeText_17_Dieu(By.Id("search_product"), "dress");

        //    ClickElement_17_Dieu(By.Id("submit_search"));

        //    var products_17_Dieu = driver_17_Dieu.FindElements(By.CssSelector(".features_items .col-sm-4"));
        //    bool hasResults_17_Dieu = products_17_Dieu.Count > 0;
        //    Assert.That(hasResults_17_Dieu, Is.True, $"TC006 FAILED: Tim 'dress' nhung khong co ket qua. So luong: {products_17_Dieu.Count}");
        //}
        //[Test]
        //public void TC06_SearchNoResults_17_Dieu()
        //{
        //    ClickElement_17_Dieu(By.XPath("//a[@href='/products']"));
        //    //Nhập từ khóa rác: xyz432
        //    TypeText_17_Dieu(By.Id("search_product"), "xyz432");

        //    ClickElement_17_Dieu(By.Id("submit_search"));
        //    var products_17_Dieu = driver_17_Dieu.FindElements(By.CssSelector(".features_items .col-sm-4"));

        //    bool noResults_17_Dieu = products_17_Dieu.Count == 0;
        //    Assert.That(noResults_17_Dieu, Is.True, $"TC007 FAILED: Van hien thi {products_17_Dieu.Count} san pham du tu khoa khong ton tai.");
        //}
        //[Test]
        //public void TC07_AddToCart_17_Dieu()
        //{
        //    //click vào trang product
        //    ClickElement_17_Dieu(By.XPath("//a[@href='/products']"));
        //    //Tìm sản phẩm đầu tiên
        //    IWebElement firstProduct_17_Dieu = WaitAndFind_17_Dieu(By.CssSelector(".product-image-wrapper"));
        //    // cuộn tới trang chứa sản phẩm
        //    ScrollToElement_17_Dieu(firstProduct_17_Dieu);
        //    // tìm nút add-to-cart
        //    IWebElement addBtn_17_Dieu = driver_17_Dieu.FindElement(By.CssSelector("a.add-to-cart"));
        //    //dùng js click
        //    ((IJavaScriptExecutor)driver_17_Dieu).ExecuteScript("arguments[0].click();", addBtn_17_Dieu);

        //    // Wait cho modal hiện ra (có class "show")
        //    wait_17_Dieu.Until(ExpectedConditions.ElementIsVisible(
        //        By.CssSelector("div#cartModal.show")
        //    ));

        //    // Click vào View Cart link bên trong modal
        //    IWebElement viewCart_17_Dieu = wait_17_Dieu.Until(
        //        ExpectedConditions.ElementToBeClickable(
        //            By.CssSelector("div#cartModal.show a[href='/view_cart']")
        //        )
        //    );
        //    ((IJavaScriptExecutor)driver_17_Dieu).ExecuteScript("arguments[0].click();", viewCart_17_Dieu);

        //    var cartRows_17_Dieu = driver_17_Dieu.FindElements(By.CssSelector("#cart_info_table tbody tr"));
        //    bool hasItem_17_Dieu = cartRows_17_Dieu.Count > 0;

        //    Assert.That(hasItem_17_Dieu, Is.True, "TC008 FAILED: Gio hang trong sau khi them san pham.");
        //}
        //[Test]
        //public void TC08_AddManyToCart_17_Dieu()
        //{
        //    ClickElement_17_Dieu(By.XPath("//a[@href='/products']"));


        //    // Mo chi tiet san pham dau tien
        //    ClickElement_17_Dieu(By.XPath("//a[@href='/product_details/1']"));
        //    Thread.Sleep(1000);

        //    // Xoa so luong cu va nhap so luong lon
        //    TypeText_17_Dieu(By.Id("quantity"), "50");

        //    // Them vao gio hang
        //    ClickElement_17_Dieu(By.XPath("//button[contains(.,'Add to cart')]"));
        //    Thread.Sleep(30000);

        //    // Chon View Cart trong popup
        //    ClickElement_17_Dieu(By.XPath("//u[contains(text(),'View Cart')]"));
        //    Thread.Sleep(1000);

        //    // Kiem tra quantity trong gio hang
        //    IWebElement quantityCell_17_Dieu = WaitAndFind_17_Dieu(
        //        By.XPath("//td[contains(@class,'cart_quantity')]//button"));

        //    string actualQuantity_17_Dieu = quantityCell_17_Dieu.Text.Trim();

        //    Assert.That(actualQuantity_17_Dieu, Is.EqualTo("50"),
        //        "TC FAILED: So luong san pham trong gio hang khong dung voi so luong da nhap.");
        //    Thread.Sleep(2000);
        //}
        [Test]
        public void TC09_RemoveFromCart_17_Dieu()
        {
            ClickElement_17_Dieu(By.XPath("//a[@href='/products']"));

            IWebElement addBtn_17_Dieu = driver_17_Dieu.FindElements(
                By.CssSelector("a.add-to-cart"))[0];
            ((IJavaScriptExecutor)driver_17_Dieu).ExecuteScript(
                "arguments[0].click();", addBtn_17_Dieu);

            //wait modal show trước
            WebDriverWait wait_17_Dieu = new WebDriverWait(driver_17_Dieu, TimeSpan.FromSeconds(10));
            wait_17_Dieu.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector("div#cartModal.show")));

            //JS click vào View Cart trong modal
            IWebElement viewCart_17_Dieu = wait_17_Dieu.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.CssSelector("div#cartModal.show a[href='/view_cart']")));
            ((IJavaScriptExecutor)driver_17_Dieu).ExecuteScript(
                "arguments[0].click();", viewCart_17_Dieu);
            //Wait URL chuyển sang /view_cart để chắc chắn đã vào trang cart
            wait_17_Dieu.Until(ExpectedConditions.UrlContains("view_cart"));
            Thread.Sleep(30000);
            // Lúc này mới tìm nút xóa
            IWebElement deleteBtn_17_Dieu = wait_17_Dieu.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.CssSelector("a.cart_quantity_delete")));
            ((IJavaScriptExecutor)driver_17_Dieu).ExecuteScript(
                "arguments[0].click();", deleteBtn_17_Dieu);

            // Wait cart trống
            wait_17_Dieu.Until(driver =>
                driver.FindElements(
                    By.CssSelector("#cart_info_table tbody tr")).Count == 0);

            var cartRows_17_Dieu = driver_17_Dieu.FindElements(
                By.CssSelector("#cart_info_table tbody tr"));
            Assert.That(cartRows_17_Dieu.Count == 0, Is.True,
                "TC009 FAILED: San pham chua bi xoa. Con lai: " + cartRows_17_Dieu.Count);
        }

    }
}
