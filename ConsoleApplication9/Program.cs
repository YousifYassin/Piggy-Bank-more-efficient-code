using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    public delegate void Mydelegate(string value);
    class Account
    {
        private string deposite;
        public event Mydelegate ValueChanged;
        public string Depostie
        {
            set
            {
                deposite = value;
                ValueChanged(deposite);
            }
        }
        private int money;
        public int Money
        {
            get { return money; }
            set
            {
                money += value;
            }
        }
    }
    class AccountUtility
    {
        public static void Limitation(Account value)
        {
            if (value.Money < 500)
            {
                Console.WriteLine($"You got {value.Money:C}");
            }
            else
            {
                Console.WriteLine($"Congratulation you reach your gool!! \n{value.Money:C}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account yousif = new Account();
            yousif.Money = 0;
            yousif.ValueChanged += (x) =>
            {
                yousif.Money = Int32.Parse(x);
                AccountUtility.Limitation(yousif);
            };
            string str;
            do
            {
                str = ConvInput("Enter the value").ToString();
                if (!str.Equals("exit", StringComparison.OrdinalIgnoreCase)&&(!str.Equals("0",StringComparison.OrdinalIgnoreCase)))
                    yousif.Depostie = str;
            } while (!str.Equals("exit", StringComparison.OrdinalIgnoreCase) && (!str.Equals("0", StringComparison.OrdinalIgnoreCase)));
            Console.WriteLine("Goodbye");
            Console.ReadLine();
        }
        static int ConvInput(string lable)
        {
            Console.WriteLine(lable);
            string input;
            int output;
            do
            {
                input = Console.ReadLine();
                if (Int32.TryParse(input,out output))
                {
                    return output;
                }
                else if (input.Equals("exit",StringComparison.OrdinalIgnoreCase))
                {
                    return 0;
                }
                else
                {
                    Console.WriteLine("Please insert a Number!");
                }
            } while (true);
        }
    }
}
