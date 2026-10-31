using GameStore.BLL;
using GameStore.DAL;
using GameStore.DTO;
using Microsoft.Extensions.Logging.Abstractions;

namespace GameStore.Tests
{
    /// <summary>
    /// Unit Tests cho ProductBLL – áp dụng quy tắc AAA (Arrange – Act – Assert).
    /// Không kết nối DB thật; dùng FakeDAL để cô lập tầng BLL.
    /// </summary>
    [TestClass]
    public class ProductBLLTests
    {
        // ── Fake DAL (không dùng DB thật) ─────────────────────
        private static ProductBLL CreateBLL(FakeProductDAL? fakeDAL = null)
        {
            fakeDAL ??= new FakeProductDAL();
            return new ProductBLL(fakeDAL, NullLogger<ProductBLL>.Instance);
        }

        // ══════════════════════════════════════════════════════
        // TC-01: Giá âm phải bị BLL từ chối
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void AddProduct_NegativePrice_ShouldFail()
        {
            // Arrange
            var bll = CreateBLL();
            var dto = new ProductDTO
            {
                ProductID   = "P999",
                ProductName = "Test Game",
                Category    = "Console",
                Price       = -500,
                InStock     = true
            };

            // Act
            var (success, msg) = bll.AddProduct(dto);

            // Assert
            Assert.IsFalse(success, "Giá âm phải bị từ chối");
            StringAssert.Contains(msg, "Giá sản phẩm phải lớn hơn 0");
        }

        // ══════════════════════════════════════════════════════
        // TC-02: Giá = 0 phải bị BLL từ chối
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void AddProduct_ZeroPrice_ShouldFail()
        {
            // Arrange
            var bll = CreateBLL();
            var dto = new ProductDTO
            {
                ProductID   = "P998",
                ProductName = "Free Game",
                Category    = "PhysicalCopy",
                Price       = 0,
                InStock     = true
            };

            // Act
            var (success, _) = bll.AddProduct(dto);

            // Assert
            Assert.IsFalse(success, "Giá = 0 phải bị từ chối");
        }

        // ══════════════════════════════════════════════════════
        // TC-03: ProductID rỗng phải bị từ chối
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void AddProduct_EmptyProductID_ShouldFail()
        {
            // Arrange
            var bll = CreateBLL();
            var dto = new ProductDTO
            {
                ProductID   = "",
                ProductName = "No ID Game",
                Category    = "Console",
                Price       = 1000000,
                InStock     = true
            };

            // Act
            var (success, msg) = bll.AddProduct(dto);

            // Assert
            Assert.IsFalse(success, "ProductID rỗng phải bị từ chối");
            StringAssert.Contains(msg, "ProductID");
        }

        // ══════════════════════════════════════════════════════
        // TC-04: ProductName rỗng phải bị từ chối
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void AddProduct_EmptyProductName_ShouldFail()
        {
            // Arrange
            var bll = CreateBLL();
            var dto = new ProductDTO
            {
                ProductID   = "P001",
                ProductName = "  ",   // whitespace only
                Category    = "Console",
                Price       = 500000,
                InStock     = true
            };

            // Act
            var (success, msg) = bll.AddProduct(dto);

            // Assert
            Assert.IsFalse(success);
            StringAssert.Contains(msg, "Tên sản phẩm");
        }

        // ══════════════════════════════════════════════════════
        // TC-05: Category không hợp lệ phải bị từ chối
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void AddProduct_InvalidCategory_ShouldFail()
        {
            // Arrange
            var bll = CreateBLL();
            var dto = new ProductDTO
            {
                ProductID   = "P001",
                ProductName = "Strange Item",
                Category    = "BoardGame",   // không nằm trong danh sách hợp lệ
                Price       = 200000,
                InStock     = true
            };

            // Act
            var (success, msg) = bll.AddProduct(dto);

            // Assert
            Assert.IsFalse(success, "Category không hợp lệ phải bị từ chối");
            StringAssert.Contains(msg, "Danh mục không hợp lệ");
        }

        // ══════════════════════════════════════════════════════
        // TC-06: Sản phẩm hợp lệ phải được thêm thành công
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void AddProduct_ValidProduct_ShouldSucceed()
        {
            // Arrange
            var fakeDAL = new FakeProductDAL();
            var bll     = CreateBLL(fakeDAL);
            var dto     = new ProductDTO
            {
                ProductID   = "P001",
                ProductName = "PlayStation 5",
                Category    = "Console",
                Price       = 14990000,
                InStock     = true,
                ShortDesc   = "Sony PS5 Standard"
            };

            // Act
            var (success, msg) = bll.AddProduct(dto);

            // Assert
            Assert.IsTrue(success, "Sản phẩm hợp lệ phải được thêm thành công");
            Assert.AreEqual(1, fakeDAL.InsertedCount, "DAL phải được gọi đúng 1 lần");
        }

        // ══════════════════════════════════════════════════════
        // TC-07: ClassifyCategory hoạt động đúng với Console
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void ClassifyCategory_Console_ReturnsCorrectLabel()
        {
            // Arrange + Act
            var label = ProductBLL.ClassifyCategory("Console");

            // Assert
            StringAssert.Contains(label, "Máy chơi game");
        }

        // ══════════════════════════════════════════════════════
        // TC-08: ClassifyCategory hoạt động đúng với PhysicalCopy
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void ClassifyCategory_PhysicalCopy_ReturnsCorrectLabel()
        {
            var label = ProductBLL.ClassifyCategory("PhysicalCopy");
            StringAssert.Contains(label, "Đĩa game");
        }

        // ══════════════════════════════════════════════════════
        // TC-09: ClassifyCategory với category không xác định
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void ClassifyCategory_Unknown_ReturnsUnknownLabel()
        {
            var label = ProductBLL.ClassifyCategory("SomethingRandom");
            StringAssert.Contains(label, "Không xác định");
        }

        // ══════════════════════════════════════════════════════
        // TC-10: ProductID quá dài (>20 ký tự) phải bị từ chối
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void AddProduct_ProductIDTooLong_ShouldFail()
        {
            // Arrange
            var bll = CreateBLL();
            var dto = new ProductDTO
            {
                ProductID   = "ABCDEFGHIJKLMNOPQRSTU",  // 21 ký tự
                ProductName = "Long ID Product",
                Category    = "PCHardware",
                Price       = 5000000,
                InStock     = true
            };

            // Act
            var (success, msg) = bll.AddProduct(dto);

            // Assert
            Assert.IsFalse(success, "ProductID >20 ký tự phải bị từ chối");
            StringAssert.Contains(msg, "20 ký tự");
        }

        // ══════════════════════════════════════════════════════
        // TC-11: DeleteProduct với ID rỗng phải bị từ chối
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void DeleteProduct_EmptyID_ShouldFail()
        {
            var bll            = CreateBLL();
            var (success, msg) = bll.DeleteProduct("");

            Assert.IsFalse(success);
            StringAssert.Contains(msg, "không được rỗng");
        }

        // ══════════════════════════════════════════════════════
        // TC-12: Validate trả về IsValid=true cho DTO hợp lệ
        // ══════════════════════════════════════════════════════
        [TestMethod]
        public void Validate_ValidDTO_ReturnsTrue()
        {
            var bll = CreateBLL();
            var dto = new ProductDTO
            {
                ProductID   = "P100",
                ProductName = "RTX 5090",
                Category    = "PCHardware",
                Price       = 50000000,
                InStock     = false
            };

            var (isValid, _) = bll.Validate(dto);
            Assert.IsTrue(isValid);
        }
    }
}
