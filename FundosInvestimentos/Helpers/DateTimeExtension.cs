using System;

namespace FundosInvestimentos.Helpers
{
    public static class DateTimeExtension
    {
        public static int GetAge(this DateTime data)
        {
            return DateTime.UtcNow.Year - data.Year;
        }
    }
}