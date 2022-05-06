using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Domain.Entities
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }
        [ForeignKey("FK_CustomerId")]
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20, ErrorMessage = "LoanType cannot exceed 20 characters.")]
        public string LoanType { get; set; }
        [Required]
        public double LoanAmount { get; set; }
        [Required]
        public DateTime LoanDate { get; set; }
        [Required]
        public float ROI { get; set; }
        [Required]
        public int LoanDuration { get; set; }
    }
}
