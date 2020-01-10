using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabawaLiczbamiUpartymi
{
    class Program
    {
        private static int Counter;
        private static List<long> ListaLiczb;
        private static void FindNumberOfTimes(long input)
        {
            Counter++;
            ListaLiczb.Add(input);
            long wynik;
            string pomocniczystring = input.ToString();
            char[] pomocnicznyarray = pomocniczystring.ToCharArray();
            if (pomocnicznyarray.Length == 1)
                return;
            wynik = Convert.ToInt64(pomocnicznyarray[0].ToString());
            for (int i = 1; i < pomocnicznyarray.Length; i++)
            {
                wynik *= Convert.ToInt64(pomocnicznyarray[i].ToString());
            }
            if (wynik < 10)
                return;
            else if (wynik >= 10)
                FindNumberOfTimes(wynik);
        }
        static void Main()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NumberOfMultiplication", typeof(int));
            dt.Columns.Add("ListOfSteps", typeof(List<long>));
            dt.Rows.Add(0, new List<long>());

            for (long i = 12729788311; i<Int64.MaxValue; i++)
            {
                ListaLiczb = new List<long>();
                Counter = 0;
                FindNumberOfTimes(i);
                if ((int)dt.Rows[0]["NumberOfMultiplication"] < Counter)
                {
                    dt.Rows[0]["NumberOfMultiplication"] = Counter;
                    dt.Rows[0]["ListOfSteps"] = ListaLiczb;
                    Console.WriteLine(i + " | " + Counter);
                }
            }
            
            
        }
    }
}
