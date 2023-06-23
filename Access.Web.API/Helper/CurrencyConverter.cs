using System;

namespace Access.Web.API
{
    public class CurrencyConverter
    {
        private static string[] units =
        {
            "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        private static string[] tens =
        {
            "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        public static string ConvertToWords(decimal value)
        {
            string words = "";

            try
            {
                if (value == 0)
                    return "Zero";

                if (value < 0)
                {
                    words += "Minus ";
                    value = Math.Abs(value);
                }

                Int64 dollars = (Int64)value;
                Int64 cents = (Int64)((value - dollars) * 100);

                words += ConvertToWordsHelper(dollars) + " Dollar";
                if (dollars != 1)
                    words += "s";

                if (cents > 0)
                {
                    words += " and ";
                    words += ConvertToWordsHelper(cents) + " Cent";
                    if (cents != 1)
                        words += "s";
                }

                return words;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string ConvertToWordsHelper(Int64 value)
        {
            string words = "";

            if (value < 20)
                words = units[value];
            else if (value < 100)
            {
                words = tens[value / 10];
                if (value % 10 > 0)
                    words += " " + units[value % 10];
            }
            else if (value < 1000)
            {
                words = units[value / 100] + " Hundred";
                if (value % 100 > 0)
                    words += " " + ConvertToWordsHelper(value % 100);
            }
            else if (value < 1000000)
            {
                words = ConvertToWordsHelper(value / 1000) + " Thousand";
                if (value % 1000 > 0)
                    words += " " + ConvertToWordsHelper(value % 1000);
            }
            else if (value < 1000000000)
            {
                words = ConvertToWordsHelper(value / 1000000) + " Million";
                if (value % 1000000 > 0)
                    words += " " + ConvertToWordsHelper(value % 1000000);
            }
            else
            {
                words = ConvertToWordsHelper(value / 1000000000) + " Billion";
                if (value % 1000000000 > 0)
                    words += " " + ConvertToWordsHelper(value % 1000000000);
            }

            return words;
        }
    }
}
