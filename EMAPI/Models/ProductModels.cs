using System.ComponentModel.DataAnnotations;

namespace EMAPI.Models
{
    public class ProductModels
    {

        [Key]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription    { get; set; }







    }
}
