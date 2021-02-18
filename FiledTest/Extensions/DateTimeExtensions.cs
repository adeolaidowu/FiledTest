using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsNotExpired(this DateTime expirationDate)
        {
            var today = DateTime.Today;
            if (today > expirationDate) return false;
            return true;
        }
    }
}
