using AutoMapper;
using FiledTest.Data;
using FiledTest.Dtos;
using FiledTest.Entities;
using FiledTest.Extensions;
using FiledTest.Helpers;
using FiledTest.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Services
{
    public class AccountRepository : ICheapPaymentGateway, IExpensivePaymentGateway
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AccountRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> ProcessCheapPaymentAsync(PaymentDto payment)
        {
            if (!CreditCard.ValidateCardNumber(payment.CreditCardNumber) || !payment.ExpirationDate.IsNotExpired())
                return false;
            await _context.Payments.AddAsync(_mapper.Map<Payment>(payment));
            int paymentId = _context.Payments.OrderBy(x => x.Id).LastOrDefault().Id;
            if (await _context.SaveChangesAsync() > 0)
            {
                await _context.PaymentStatus.AddAsync(new PaymentStatus { PaymentId = paymentId, PaymentState = "Processed" });
                await _context.SaveChangesAsync();
                return true;
            }
            await _context.PaymentStatus.AddAsync(new PaymentStatus { PaymentId = paymentId, PaymentState = "Failed" });
            await _context.SaveChangesAsync();
            return false;
        }

        public async Task<bool> ProcessPremiumPaymentAsync(PaymentDto payment)
        {
            if (!CreditCard.ValidateCardNumber(payment.CreditCardNumber) || !payment.ExpirationDate.IsNotExpired())
                return false;
            await _context.Payments.AddAsync(_mapper.Map<Payment>(payment));
            int paymentId = _context.Payments.OrderBy(x => x.Id).LastOrDefault().Id;
            if (await _context.SaveChangesAsync() > 0)
            {
                await _context.PaymentStatus.AddAsync(new PaymentStatus { PaymentId = paymentId, PaymentState = "Processed" });
                await _context.SaveChangesAsync();
                return true;
            }
            await _context.PaymentStatus.AddAsync(new PaymentStatus { PaymentId = paymentId, PaymentState = "Failed" });
            await _context.SaveChangesAsync();
            return false;
        }
    }
}
