using GameStore.DTO;

namespace GameStore.DAL
{
    /// <summary>
    /// Interface cho ProductDAL – dùng để inject/fake trong Unit Test.
    /// </summary>
    public interface IProductDAL
    {
        void Insert(ProductDTO product);
        bool Update(ProductDTO product);
        bool Delete(string productID);
        List<ProductDTO> GetAll();
        ProductDTO? GetByProductID(string productID);
        List<ProductDTO> Search(string keyword);
    }
}
