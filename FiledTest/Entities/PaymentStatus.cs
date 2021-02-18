using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Entities
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public string PaymentState { get; set; } = "Pending";
    }
}
