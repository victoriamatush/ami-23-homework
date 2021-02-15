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
                if (Validation.CheckId(value))
                    id = value;
                else
                    id = 0;
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
                if (Validation.CheckCode(value))
                    code = value;
                else
                    code = "Wrong format";
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
                if (Validation.CheckTitle(value))
                    title = value;
                else
                    title = "Wrong format";
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
                if (Validation.CheckType(value))
                    type = value;
                else
                    type = "Wrong format";
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
                if (Validation.CheckId(value))
                    amount = value;
                else
                    amount = 0;
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
                if (Validation.CheckPrice(value))
                    price = value;
                else
                    price = 0.00;
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
                if (Validation.CheckData(value))
                    data = value;
                else
                    data = "Wrong format";
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

            Good g = new Good(id, code, title, type, amount, price, data);

            return g;
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

        public bool CheckAll()
        {
            bool check = true;
            if (this.id == 0)
            {
                Console.WriteLine("Wrong id");
                check = false;
            }
            if (this.code == "Wrong format")
            {
                Console.WriteLine("Wrong code");
                check = false;
            }
            if (this.title == "Wrong format")
            {
                Console.WriteLine("Wrong title");
                check = false;
            }
            if (this.type == "Wrong format")
            {
                Console.WriteLine("Wrong type");
                check = false;
            }
            if (this.amount == 0)
            {
                Console.WriteLine("Wrong amount");
                check = false;
            }
            if (this.price == 0.00)
            {
                Console.WriteLine("Wrong price");
                check = false;
            }
            if (this.data == "Wrong format")
            {
                Console.WriteLine("Wrong data");
                check = false;
            }
            return check;
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (this.CheckAll() == false)
                throw new InvalidOperationException();
        }


    }
}
