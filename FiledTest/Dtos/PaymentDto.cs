using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Dtos
{
    public class PaymentDto
    {
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }
        [StringLength(3)]
        public string SecurityCode { get; set; }
        [Required]
        [Range(0.1, Double.MaxValue, ErrorMessage = "The field {0} must be positive .")]
        public decimal Amount { get; set; }
    }
}
