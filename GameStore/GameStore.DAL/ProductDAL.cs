using GameStore.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace GameStore.DAL
{
    /// <summary>
    /// Data Access Layer cho bảng Products.
    /// Tất cả câu lệnh SQL đều dùng SqlParameter để chống SQL Injection.
    /// </summary>
    public class ProductDAL : IProductDAL
    {
        private readonly string _connectionString;
        private readonly ILogger<ProductDAL> _logger;

        public ProductDAL(string connectionString, ILogger<ProductDAL> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        // ─────────────────────────────────────────────────────
        // INSERT
        // ─────────────────────────────────────────────────────
        /// <summary>
        /// Thêm sản phẩm mới vào DB.
        /// Ném InvalidOperationException nếu ProductID đã tồn tại (lỗi 2627).
        /// </summary>
        public void Insert(ProductDTO product)
        {
            const string sql = @"
                INSERT INTO Products (ProductID, ProductName, Category, Price, ShortDesc, InStock, CreatedAt)
                VALUES (@ProductID, @ProductName, @Category, @Price, @ShortDesc, @InStock, @CreatedAt)";

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd  = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ProductID",   product.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Category",    product.Category);
                cmd.Parameters.AddWithValue("@Price",       product.Price);
                cmd.Parameters.AddWithValue("@ShortDesc",   (object?)product.ShortDesc ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@InStock",     product.InStock);
                cmd.Parameters.AddWithValue("@CreatedAt",   DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();

                _logger.LogInformation("INSERT OK: ProductID={ProductID}, Name={Name}",
                    product.ProductID, product.ProductName);
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Lỗi UNIQUE constraint violation
                _logger.LogError(ex, "DUPLICATE ProductID={ProductID}", product.ProductID);
                throw new InvalidOperationException($"Mã sản phẩm '{product.ProductID}' đã tồn tại trong hệ thống.", ex);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error khi INSERT ProductID={ProductID}", product.ProductID);
                throw;
            }
        }

        // ─────────────────────────────────────────────────────
        // UPDATE
        // ─────────────────────────────────────────────────────
        /// <summary>
        /// Cập nhật thông tin sản phẩm theo ProductID (business key).
        /// Trả về true nếu update thành công (tìm thấy bản ghi), false nếu không tìm thấy.
        /// </summary>
        public bool Update(ProductDTO product)
        {
            const string sql = @"
                UPDATE Products
                SET ProductName = @ProductName,
                    Category    = @Category,
                    Price       = @Price,
                    ShortDesc   = @ShortDesc,
                    InStock     = @InStock,
                    UpdatedAt   = @UpdatedAt
                WHERE ProductID = @ProductID";

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd  = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Category",    product.Category);
                cmd.Parameters.AddWithValue("@Price",       product.Price);
                cmd.Parameters.AddWithValue("@ShortDesc",   (object?)product.ShortDesc ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@InStock",     product.InStock);
                cmd.Parameters.AddWithValue("@UpdatedAt",   DateTime.Now);
                cmd.Parameters.AddWithValue("@ProductID",   product.ProductID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    _logger.LogInformation("UPDATE OK: ProductID={ProductID}", product.ProductID);
                else
                    _logger.LogWarning("UPDATE: Không tìm thấy ProductID={ProductID}", product.ProductID);

                return rows > 0;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error khi UPDATE ProductID={ProductID}", product.ProductID);
                throw;
            }
        }

        // ─────────────────────────────────────────────────────
        // DELETE
        // ─────────────────────────────────────────────────────
        /// <summary>
        /// Xoá sản phẩm theo ProductID.
        /// Trả về true nếu xoá thành công.
        /// </summary>
        public bool Delete(string productID)
        {
            const string sql = "DELETE FROM Products WHERE ProductID = @ProductID";

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd  = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ProductID", productID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    _logger.LogInformation("DELETE OK: ProductID={ProductID}", productID);
                else
                    _logger.LogWarning("DELETE: Không tìm thấy ProductID={ProductID}", productID);

                return rows > 0;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error khi DELETE ProductID={ProductID}", productID);
                throw;
            }
        }

        // ─────────────────────────────────────────────────────
        // GET ALL
        // ─────────────────────────────────────────────────────
        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm từ DB.
        /// </summary>
        public List<ProductDTO> GetAll()
        {
            const string sql = @"
                SELECT Id, ProductID, ProductName, Category, Price, ShortDesc, InStock, CreatedAt, UpdatedAt
                FROM Products
                ORDER BY CreatedAt DESC";

            var list = new List<ProductDTO>();

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd  = new SqlCommand(sql, conn);

                conn.Open();
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(MapReaderToDTO(reader));
                }

                _logger.LogInformation("GetAll: Lấy {Count} sản phẩm", list.Count);
                return list;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error khi GetAll Products");
                throw;
            }
        }

        // ─────────────────────────────────────────────────────
        // GET BY ID
        // ─────────────────────────────────────────────────────
        /// <summary>
        /// Tìm sản phẩm theo ProductID (business key).
        /// Trả về null nếu không tìm thấy.
        /// </summary>
        public ProductDTO? GetByProductID(string productID)
        {
            const string sql = @"
                SELECT Id, ProductID, ProductName, Category, Price, ShortDesc, InStock, CreatedAt, UpdatedAt
                FROM Products
                WHERE ProductID = @ProductID";

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd  = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ProductID", productID);

                conn.Open();
                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                    return MapReaderToDTO(reader);

                return null;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error khi GetByProductID={ProductID}", productID);
                throw;
            }
        }

        // ─────────────────────────────────────────────────────
        // SEARCH
        // ─────────────────────────────────────────────────────
        /// <summary>
        /// Tìm kiếm sản phẩm theo từ khoá (tên hoặc mô tả).
        /// </summary>
        public List<ProductDTO> Search(string keyword)
        {
            const string sql = @"
                SELECT Id, ProductID, ProductName, Category, Price, ShortDesc, InStock, CreatedAt, UpdatedAt
                FROM Products
                WHERE ProductName LIKE @kw OR ShortDesc LIKE @kw OR ProductID LIKE @kw
                ORDER BY ProductName";

            var list = new List<ProductDTO>();

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd  = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");

                conn.Open();
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(MapReaderToDTO(reader));

                return list;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error khi Search keyword={Keyword}", keyword);
                throw;
            }
        }

        // ─────────────────────────────────────────────────────
        // HELPER
        // ─────────────────────────────────────────────────────
        private static ProductDTO MapReaderToDTO(SqlDataReader reader)
        {
            return new ProductDTO
            {
                Id          = reader.GetInt32(reader.GetOrdinal("Id")),
                ProductID   = reader.GetString(reader.GetOrdinal("ProductID")),
                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                Category    = reader.GetString(reader.GetOrdinal("Category")),
                Price       = reader.GetDecimal(reader.GetOrdinal("Price")),
                ShortDesc   = reader.IsDBNull(reader.GetOrdinal("ShortDesc"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("ShortDesc")),
                InStock     = reader.GetBoolean(reader.GetOrdinal("InStock")),
                CreatedAt   = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt   = reader.IsDBNull(reader.GetOrdinal("UpdatedAt"))
                                ? null
                                : reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
            };
        }
    }
}
