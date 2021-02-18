using FiledTest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        Task<bool> ProcessPremiumPaymentAsync(PaymentDto payment);
    }
}
