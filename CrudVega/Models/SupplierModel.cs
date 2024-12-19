using System.ComponentModel.DataAnnotations;

namespace CrudVega.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(11)]
        public string Telephone { get; set; }

        [StringLength(14)]
        public string CNPJ { get; set; }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(150)]
        public string Address { get; set; }
        [Required]
        public string QrCode { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
