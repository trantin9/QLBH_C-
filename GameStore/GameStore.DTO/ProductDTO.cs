namespace GameStore.DTO
{
    /// <summary>
    /// Data Transfer Object for Product.
    /// Luân chuyển dữ liệu giữa các tầng UI → BLL → DAL.
    /// Không chứa logic nghiệp vụ.
    /// </summary>
    public class ProductDTO
    {
        /// <summary>Internal auto-increment ID (from DB)</summary>
        public int Id { get; set; }

        /// <summary>Business key, ví dụ: P001, P002... UNIQUE trong DB</summary>
        public string ProductID { get; set; } = string.Empty;

        /// <summary>Tên sản phẩm</summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>Danh mục: Console | PhysicalCopy | PCHardware</summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>Giá bán (VNĐ), phải > 0</summary>
        public decimal Price { get; set; }

        /// <summary>Mô tả ngắn</summary>
        public string? ShortDesc { get; set; }

        /// <summary>Còn hàng hay không</summary>
        public bool InStock { get; set; } = true;

        /// <summary>Ngày tạo</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Ngày cập nhật lần cuối</summary>
        public DateTime? UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"[{ProductID}] {ProductName} - {Price:N0}đ ({Category}) InStock={InStock}";
        }
    }
}
