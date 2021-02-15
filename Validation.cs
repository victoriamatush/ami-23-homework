using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace practicts_task_1
{
    class Validation
    {
        public static bool CheckInt(object input)
        {
            try
            {
                Convert.ToInt32(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckId(object input)
        {
            if (CheckInt(input))
            {
                if(Convert.ToInt32(input) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool CheckCode(string code)
        {
            string pattern = @"[0-9]{3}[-][0-9]{3}[-][0-9]{3}";
            Regex rg = new Regex(pattern);

            if (rg.IsMatch(code))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckTitle(string title)
        {
            string pattern = @"[a-zA-z]+";
            Regex rg = new Regex(pattern);

            if (rg.IsMatch(title))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckType(string type)
        {
            if (type.ToLower() == "box" || type.ToLower() == "letter")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckPrice(double price)
        {
            try
            {
                price = Math.Round(price, 2);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public static bool CheckData(string data)
        {
            if (data.Contains("[@_!#$%^&*()?/|{}~`:;-]"))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
