using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SILDMS.Utillity
{
    public static class DMSUtility
    {
        public static DateTime FormatDate(string strDate)
        {
            var newDate = new DateTime();
            if (string.IsNullOrEmpty(strDate)) return newDate;
            var strDatepart = strDate.Substring(0, 10);
            if (strDatepart.Contains('/'))
            {
                var str = strDatepart.Split('/');
                newDate = new DateTime(Convert.ToInt32(str[2]), Convert.ToInt32(str[1]),
                    Convert.ToInt32(str[0]));
            }
            else if (strDatepart.Contains('-'))
            {
                var str = strDatepart.Split('-');
                newDate = new DateTime(Convert.ToInt32(str[2]), Convert.ToInt32(str[1]),
                    Convert.ToInt32(str[0]));
            }
            else
            {
                var str = Regex.Split(strDate, @"\s+");
                newDate = new DateTime(Convert.ToInt32(str[2]), ReturnMonthCode(str[1]),
                   Convert.ToInt32(str[0]));

            }
            return newDate;
        }

        public static int ReturnMonthCode(string name)
        {
            switch (name)
            {
                case "Jan":
                    return 1;

                case "Feb":
                    return 2;

                case "Mar":
                    return 3;

                case "Apr":
                    return 4;

                case "May":
                    return 5;

                case "Jun":
                    return 6;

                case "Jul":
                    return 7;

                case "Aug":
                    return 8;

                case "Sep":
                    return 9;

                case "Oct":
                    return 10;

                case "Nov":
                    return 11;

                case "Dec":
                    return 12;

                default:
                    return 0;

            }
        }


        public static string ConvertNumberToWord(string input)
        {
            string decimals = "";
            if (input.Contains("."))
            {
                decimals = input.Substring(input.IndexOf(".") + 1);
                input = input.Remove(input.IndexOf("."));
            }
            string strWords = words(Convert.ToInt64(input));
            if (decimals.Length > 0)
            {
                if (decimals.Length == 1)
                {
                    return "Paisa " + words(Convert.ToInt64(decimals.Substring(0, 1))) + "";
                }
                strWords += " & Paisa " + words(Convert.ToInt64(decimals.Substring(0, 2))) + "";
            }
            return strWords + " Only";
        }

        public static string words(long numbers)
        {
            long number = numbers;

            if (number == 0) return "Zero";
            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lac Eighty Three Thousand Six Hundred and Forty Eight";
            long[] num = new long[4];
            long first = 0;
            long u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
"Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
"Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
"Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lac ", "Crore " };
            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = number / 10000000; // crores
            num[2] = num[2] - 100 * num[3]; // Lacs
            for (long i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (long i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }


        public static String AddComma(decimal amount)
        {
            string result = "";
            string amt = "";
            string amt_paisa = "";

            amt = amount.ToString();
            int aaa = amount.ToString().IndexOf(".", 0);
            amt_paisa = amount.ToString().Substring(aaa + 1);

            if (amt == amt_paisa)
            {
                amt_paisa = "";
            }
            else
            {
                amt = amount.ToString().Substring(0, amount.ToString().IndexOf(".", 0));
                amt = (amt.Replace(",", "")).ToString();
            }
            switch (amt.Length)
            {
                case 9:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 2) + "," + amt.Substring(6, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 2) + "," + amt.Substring(6, 3) + "." +
                                 amt_paisa;
                    }
                    break;
                case 8:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 2) + "," + amt.Substring(5, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 2) + "," + amt.Substring(5, 3) + "." +
                                 amt_paisa;
                    }
                    break;
                case 7:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 3) + "." + amt_paisa;
                    }
                    break;
                case 6:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 3) + "." + amt_paisa;
                    }
                    break;
                case 5:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 3) + "." +
                                 amt_paisa;
                    }
                    break;
                case 4:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 3) + "." +
                                 amt_paisa;
                    }
                    break;
                default:
                    if (amt_paisa == "")
                    {
                        result = amt;
                    }
                    else
                    {
                        result = amt + "." + amt_paisa;
                    }
                    break;
            }
            return result;
        }



    }
}
