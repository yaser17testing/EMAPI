using EMAPI.Data;
using EMAPI.Dto;
using EMAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EMAPI.Repository
{
    public class ProductRepository : IProduct
    {



        private readonly DataContext dataContext;

        public ProductRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<ProductModels> CreateAsync(ProductModels productDto)
        {
            await dataContext.Products.AddAsync(productDto);
            await dataContext.SaveChangesAsync();

            return productDto;
        }






       

        public Task<ProductModels?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }







        public async Task<List<ProductModels>> GetAllAsync()
        {

            return await dataContext.Products.ToListAsync();



        }

        public async Task<ProductModels?> GetByIdAsync(int id)
        {
            return await dataContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }
    }
}
