using GameStore.DAL;
using GameStore.DTO;
using Microsoft.Extensions.Logging;

namespace GameStore.BLL
{
    /// <summary>
    /// Business Logic Layer cho Product.
    /// Chá»©a toĂ n bá»™ validation vĂ  business rules.
    /// UI chá»‰ Ä‘Æ°á»£c gá»i vĂ o táº§ng nĂ y, khĂ´ng Ä‘Æ°á»£c gá»i tháº³ng DAL.
    /// </summary>
    public class ProductBLL
    {
        private readonly GameStore.DAL.IProductDAL _dal;
        private readonly ILogger<ProductBLL> _logger;

        // Danh má»¥c há»£p lá»‡ (pháº£i khá»›p vá»›i CHECK constraint trong DB)
        public static readonly string[] ValidCategories =
            ["Console", "PhysicalCopy", "PCHardware"];

        public ProductBLL(GameStore.DAL.IProductDAL dal, ILogger<ProductBLL> logger)
        {
            _dal    = dal;
            _logger = logger;
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // ADD PRODUCT
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        /// <summary>
        /// ThĂªm sáº£n pháº©m má»›i sau khi validate.
        /// Tráº£ vá» (success, errorMessage).
        /// </summary>
        public (bool Success, string Message) AddProduct(ProductDTO product)
        {
            var (valid, msg) = Validate(product);
            if (!valid)
            {
                _logger.LogWarning("AddProduct bá»‹ tá»« chá»‘i â€“ validation fail: {Msg}", msg);
                return (false, msg);
            }

            try
            {
                _dal.Insert(product);
                _logger.LogInformation("AddProduct thĂ nh cĂ´ng: {ProductID}", product.ProductID);
                return (true, "ThĂªm sáº£n pháº©m thĂ nh cĂ´ng!");
            }
            catch (InvalidOperationException ex)
            {
                // Lá»—i trĂ¹ng ProductID
                _logger.LogError(ex, "AddProduct lá»—i DUPLICATE: {ProductID}", product.ProductID);
                return (false, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddProduct lá»—i khĂ´ng xĂ¡c Ä‘á»‹nh: {ProductID}", product.ProductID);
                return (false, $"Lá»—i há»‡ thá»‘ng: {ex.Message}");
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // UPDATE PRODUCT
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        /// <summary>
        /// Cáº­p nháº­t thĂ´ng tin sáº£n pháº©m.
        /// </summary>
        public (bool Success, string Message) UpdateProduct(ProductDTO product)
        {
            var (valid, msg) = Validate(product);
            if (!valid)
            {
                _logger.LogWarning("UpdateProduct bá»‹ tá»« chá»‘i â€“ validation fail: {Msg}", msg);
                return (false, msg);
            }

            try
            {
                bool updated = _dal.Update(product);
                if (!updated)
                    return (false, $"KhĂ´ng tĂ¬m tháº¥y sáº£n pháº©m '{product.ProductID}'.");

                _logger.LogInformation("UpdateProduct thĂ nh cĂ´ng: {ProductID}", product.ProductID);
                return (true, "Cáº­p nháº­t sáº£n pháº©m thĂ nh cĂ´ng!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateProduct lá»—i: {ProductID}", product.ProductID);
                return (false, $"Lá»—i há»‡ thá»‘ng: {ex.Message}");
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // DELETE PRODUCT
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        /// <summary>
        /// XoĂ¡ sáº£n pháº©m theo ProductID.
        /// </summary>
        public (bool Success, string Message) DeleteProduct(string productID)
        {
            if (string.IsNullOrWhiteSpace(productID))
            {
                _logger.LogWarning("DeleteProduct: ProductID rá»—ng");
                return (false, "MĂ£ sáº£n pháº©m khĂ´ng Ä‘Æ°á»£c rá»—ng.");
            }

            try
            {
                bool deleted = _dal.Delete(productID);
                if (!deleted)
                    return (false, $"KhĂ´ng tĂ¬m tháº¥y sáº£n pháº©m '{productID}'.");

                _logger.LogInformation("DeleteProduct thĂ nh cĂ´ng: {ProductID}", productID);
                return (true, "XoĂ¡ sáº£n pháº©m thĂ nh cĂ´ng!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteProduct lá»—i: {ProductID}", productID);
                return (false, $"Lá»—i há»‡ thá»‘ng: {ex.Message}");
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // GET ALL
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        /// <summary>
        /// Láº¥y toĂ n bá»™ danh sĂ¡ch sáº£n pháº©m.
        /// </summary>
        public List<ProductDTO> GetAllProducts()
        {
            try
            {
                return _dal.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllProducts lá»—i");
                return [];
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // SEARCH
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        /// <summary>
        /// TĂ¬m kiáº¿m sáº£n pháº©m theo tá»« khoĂ¡.
        /// </summary>
        public List<ProductDTO> SearchProducts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                _logger.LogWarning("SearchProducts: tá»« khoĂ¡ rá»—ng, tráº£ vá» toĂ n bá»™");
                return GetAllProducts();
            }

            try
            {
                return _dal.Search(keyword);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SearchProducts lá»—i keyword={Keyword}", keyword);
                return [];
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // GET BY ID
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        public ProductDTO? GetByProductID(string productID)
        {
            if (string.IsNullOrWhiteSpace(productID))
                return null;
            try
            {
                return _dal.GetByProductID(productID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetByProductID lá»—i: {ProductID}", productID);
                return null;
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // CLASSIFY CATEGORY (dĂ¹ng trong Unit Test)
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        /// <summary>
        /// PhĂ¢n loáº¡i vĂ  tráº£ vá» nhĂ£n hiá»ƒn thá»‹ cho category.
        /// </summary>
        public static string ClassifyCategory(string category)
        {
            return category switch
            {
                "Console"     => "đŸ® MĂ¡y chÆ¡i game",
                "PhysicalCopy"=> "đŸ’¿ ÄÄ©a game báº£n váº­t lĂ½",
                "PCHardware"  => "đŸ–¥ï¸ Pháº§n cá»©ng PC",
                _             => "â“ KhĂ´ng xĂ¡c Ä‘á»‹nh"
            };
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // VALIDATION (public Ä‘á»ƒ Unit Test gá»i trá»±c tiáº¿p)
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        /// <summary>
        /// Kiá»ƒm tra tĂ­nh há»£p lá»‡ cá»§a ProductDTO trÆ°á»›c khi lÆ°u DB.
        /// </summary>
        public (bool IsValid, string ErrorMessage) Validate(ProductDTO product)
        {
            if (product is null)
                return (false, "Dá»¯ liá»‡u sáº£n pháº©m khĂ´ng Ä‘Æ°á»£c null.");

            if (string.IsNullOrWhiteSpace(product.ProductID))
                return (false, "MĂ£ sáº£n pháº©m (ProductID) khĂ´ng Ä‘Æ°á»£c rá»—ng.");

            if (product.ProductID.Length > 20)
                return (false, "MĂ£ sáº£n pháº©m khĂ´ng Ä‘Æ°á»£c vÆ°á»£t quĂ¡ 20 kĂ½ tá»±.");

            if (string.IsNullOrWhiteSpace(product.ProductName))
                return (false, "TĂªn sáº£n pháº©m khĂ´ng Ä‘Æ°á»£c rá»—ng.");

            if (product.Price <= 0)
                return (false, "GiĂ¡ sáº£n pháº©m pháº£i lá»›n hÆ¡n 0.");

            if (!ValidCategories.Contains(product.Category))
                return (false, $"Danh má»¥c khĂ´ng há»£p lá»‡. Chá»‰ cháº¥p nháº­n: {string.Join(", ", ValidCategories)}");

            if (product.ShortDesc?.Length > 500)
                return (false, "MĂ´ táº£ ngáº¯n khĂ´ng Ä‘Æ°á»£c vÆ°á»£t quĂ¡ 500 kĂ½ tá»±.");

            return (true, string.Empty);
        }
    }
}

