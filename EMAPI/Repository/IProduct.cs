using EMAPI.Dto;
using EMAPI.Models;

namespace EMAPI.Repository
{
    public interface IProduct
    {


        Task<List<ProductModels>> GetAllAsync();

        Task<ProductModels> CreateAsync(ProductModels productDto);



        Task<ProductModels?> GetByIdAsync(int id);

        Task<ProductModels?> DeleteAsync(int id);


    }
}
