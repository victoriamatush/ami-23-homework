using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace practicts_task_1
{
    class Good
    {
        protected int id;
        protected string code;
        protected string title;
        protected string type;
        protected int amount;
        protected double price;
        protected string data;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id  = Validation.CheckId(value) ? value : throw new ArgumentException("bad value, try again");
            }
        }
        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = Validation.CheckCode(value) ? value : throw new ArgumentException("bad value, try again");
            }
        }
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = Validation.CheckData(value) ? value : throw new ArgumentException("bad value, try again");
            }
            
        }
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = Validation.CheckType(value) ? value : throw new ArgumentException("bad value, try again");
            }
        }
        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = Validation.CheckId(value) ? value : throw new ArgumentException("bad value, try again");
            }
        }
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = Validation.CheckPrice(value) ? value : throw new ArgumentException("bad value, try again");
            }
        }
        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = Validation.CheckData(value) ? value : throw new ArgumentException("bad value, try again");
            }
        }

        public Good()
        {
            this.id = 0;
            this.code = "";
            this.title = "";
            this.type = "";
            this.amount = 0;
            this.price = 0;
            this.data = "";
        }
        public Good(int id, string code, string title, string type, int amount, double price, string data)
        {
            this.id = id;
            this.code = code;
            this.title = title;
            this.type = type;
            this.amount = amount;
            this.price = price;
            this.data = data;
        }

        public void Output()
        {
            Console.WriteLine(this.ToString());
        }
        
        public override string ToString()
        {
            return string.Format($"Id: {id} \nCode: {code} \nTitle: {title} \nType:" +
                $" {type} \nAmount: {amount} \nPrice: {price} \nData: {data} \n");
        }

        public Good Input()
        {
            Console.Write("Enter id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter code: ");
            string code = Console.ReadLine();
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter type: ");
            string type = Console.ReadLine();
            Console.Write("Enter amount: ");
            int amount = int.Parse(Console.ReadLine());
            Console.Write("Enter price: ");
            double price = int.Parse(Console.ReadLine());
            Console.Write("Enter data: ");
            string data = Console.ReadLine();
            Good g = new Good();
            try
            {
                g = new Good
                {
                    Id = id,
                    Code = code,
                    Title = title,
                    Type = type,
                    Amount = amount,
                    Price = price,
                    Data = data
                };
                return g;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            
        }

        public bool locate(string pattern)
        {
            bool check = false;
            PropertyInfo[] attributes = typeof(Good).GetProperties();
            foreach (PropertyInfo attr in attributes)
            {
                if (Convert.ToString(attr.GetValue(this)).ToLower().Contains(pattern.ToLower()))
                {
                    check = true;
                }
            }return check;
        }
    }
}
