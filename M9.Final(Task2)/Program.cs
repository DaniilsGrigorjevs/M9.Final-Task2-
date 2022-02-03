using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9.Final_Task2_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "John", "Andrew", "Victoria", "Daniil", "Nicole" };
            Console.WriteLine("Names:");
            ShowNames(names);

            NumberReader numberReader = new NumberReader();
            numberReader.NumberReaderEvent += SortTyper;
            int i = 0;
            while (i == 0)
            {
                try
                {
                    numberReader.Read(names);
                    ShowNames(names);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect value");
                }
                catch (Exception ex) when (ex.Message == "Exit")
                {
                    i++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void SortTyper(int number, List<string> names)
        {
            Console.WriteLine("Enter a number {0}", number);

            switch (number)
            {
                case 0: throw new Exception("Exit");
                case 1: names.Sort(); break;
                case 2: names.Sort(); names.Reverse(); break;
            }


        }

        static void ShowNames(List<string> names)
        {
            foreach (string name in names)
                Console.WriteLine(name);
        }
    }
    class NumberReader
    {

        public event Action<int, List<string>> NumberReaderEvent;

        public void Read(List<string> names)
        {
            Console.Write("To sort names enter 1 (A-Z) or 2 (Z-A): ");
            int number = Convert.ToInt32(Console.ReadLine());

            while (number != 0 && number != 1 && number != 2) throw new Exception("Enter number 1 or 2");

            NumberEntered(number, names);
        }

        protected virtual void NumberEntered(int number, List<string> names)
        {
            NumberReaderEvent?.Invoke(number, names);
        }
    }
}
