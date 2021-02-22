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
                throw new ArgumentException("Not int");
            }
        }

        public static bool CheckChoice(object input)
        {
            if (CheckInt(input))
            {
                if (Convert.ToInt32(input) <= 0 && Convert.ToInt32(input) >= 10)
                {
                    throw new ArgumentException("bad value, try again");
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public static bool CheckId(object input)
        {
            if (CheckInt(input))
            {
                if(Convert.ToInt32(input) <= 0)
                {
                    throw new ArgumentException("not int");
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public static bool CheckCode(string code)
        {
            string pattern = @"[0-9]{3}[-][0-9]{3}[-][0-9]{3}";
            Regex rg = new Regex(pattern);
            if (!rg.IsMatch(code))
            {
                throw new ArgumentException("wrong code");
            }
            else
            {
                return true;
            }
        }


        public static bool CheckType(string type)
        {

            if (!type.Equals("box") && !type.Equals("letter"))
            {
                throw new ArgumentException("wrong type");
            }
            else
            {
                return true;
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
                throw new ArgumentException("Wrong price");
            }
            
        }

        public static bool CheckData(string data)
        {
            if (!Regex.IsMatch(data, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Wrong data");
            }
            else { return true; }

        }

        

    }
}
