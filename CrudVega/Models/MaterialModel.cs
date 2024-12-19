using System.ComponentModel.DataAnnotations;

namespace CrudVega.Models
{
    public class MaterialModel
    {
        public int Id { get; set; }

        [Required]
        public int IdSupplier { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string FiscalCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Specie { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
