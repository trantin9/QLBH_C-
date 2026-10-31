using GameStore.DAL;
using GameStore.DTO;

namespace GameStore.Tests
{
    /// <summary>
    /// Fake implementation của IProductDAL để cô lập Unit Test khỏi DB thật.
    /// </summary>
    public class FakeProductDAL : IProductDAL
    {
        private readonly List<ProductDTO> _store = [];

        public int InsertedCount { get; private set; }
        public int UpdatedCount  { get; private set; }
        public int DeletedCount  { get; private set; }

        public void Insert(ProductDTO product)
        {
            if (_store.Any(p => p.ProductID == product.ProductID))
                throw new InvalidOperationException($"Mã sản phẩm '{product.ProductID}' đã tồn tại trong hệ thống.");

            _store.Add(product);
            InsertedCount++;
        }

        public bool Update(ProductDTO product)
        {
            var existing = _store.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existing is null) return false;

            _store.Remove(existing);
            _store.Add(product);
            UpdatedCount++;
            return true;
        }

        public bool Delete(string productID)
        {
            var existing = _store.FirstOrDefault(p => p.ProductID == productID);
            if (existing is null) return false;

            _store.Remove(existing);
            DeletedCount++;
            return true;
        }

        public List<ProductDTO> GetAll() => [.. _store];

        public ProductDTO? GetByProductID(string productID)
            => _store.FirstOrDefault(p => p.ProductID == productID);

        public List<ProductDTO> Search(string keyword)
            => _store.Where(p =>
                p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                p.ProductID.Contains(keyword, StringComparison.OrdinalIgnoreCase))
              .ToList();
    }
}
