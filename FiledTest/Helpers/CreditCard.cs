using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Helpers
{
    public class CreditCard
    {
        public static bool ValidateCardNumber(string cardNumber)
        {
            
            if (cardNumber.Contains(" "))
            {
                cardNumber = cardNumber.Replace(" ", String.Empty);
            }
            var doubles = "";
            var singles = "";

            //populate singles
            for(int i = cardNumber.Length -1; i >= 0; i -= 2)
            {
                singles += cardNumber[i];
            }
            // populate doubles
            for (int i = cardNumber.Length - 2; i >= 0; i -= 2)
            {
                doubles += cardNumber[i] * 2;
            }

            var total = SumDigits(singles) + SumDigits(doubles);
            if (total % 10 > 0) return false;
            return true;
        }

        private static int SumDigits(string number)
        {
            //return number.Select(x => int.Parse(x.ToString())).Sum();
            var total = 0;
            for(int i = 0; i < number.Length; i++)
            {
                total += number[i];
            }
            return total;
        }
    }
}
