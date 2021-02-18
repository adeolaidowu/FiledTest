using FiledTest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Interfaces
{
    public interface ICheapPaymentGateway
    {
        Task<bool> ProcessCheapPaymentAsync(PaymentDto payment);
    }
}
