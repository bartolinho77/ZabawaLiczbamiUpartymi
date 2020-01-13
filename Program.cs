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
        private static List<ulong> ListaLiczb;
        private static void FindNumberOfTimes(ulong input)
        {
            Counter++;
            ListaLiczb.Add(input);
            ulong wynik;
            string pomocniczystring = input.ToString();
            char[] pomocnicznyarray = pomocniczystring.ToCharArray();
            if (pomocnicznyarray.Length == 1)
                return;
            wynik = Convert.ToUInt64(pomocnicznyarray[0].ToString());
            for (int i = 1; i < pomocnicznyarray.Length; i++)
            {
                wynik *= Convert.ToUInt64(pomocnicznyarray[i].ToString());
            }
            if (wynik < 10)
                return;
            else if (wynik >= 10)
                FindNumberOfTimes(wynik);
        }
        static void Main()
        {
            Console.WriteLine(ulong.MaxValue.ToString());
            Console.WriteLine(Int64.MaxValue.ToString());
            DataTable dt = new DataTable();
            dt.Columns.Add("NumberOfMultiplication", typeof(int));
            dt.Columns.Add("ListOfSteps", typeof(List<ulong>));
            dt.Rows.Add(0, new List<ulong>());

            ulong i = 10;
            while(i <= UInt64.MaxValue)// (ulong i = 10; i<Int64.MaxValue; i++)
            {
                //Console.WriteLine(i);

                ListaLiczb = new List<ulong>();
                Counter = 0;
                
                


                FindNumberOfTimes(i);
                if ((int)dt.Rows[0]["NumberOfMultiplication"] < Counter)
                {
                    dt.Rows[0]["NumberOfMultiplication"] = Counter;
                    dt.Rows[0]["ListOfSteps"] = ListaLiczb;
                    Console.WriteLine(i + " | " + Counter);
                }

                char[] temp = i.ToString().ToCharArray();
                bool charfound = false;
                for (int j =1; j<temp.Length; j++)
                {
                    if(!(Convert.ToInt16(temp[j-1].ToString()) <= Convert.ToInt16(temp[j].ToString())))
                    {
                        ulong temp1 = Convert.ToUInt64((Convert.ToInt16(temp[j - 1].ToString()) - Convert.ToInt16(temp[j].ToString())) * Math.Pow(10.0, temp.Length - j - 1));
                        if (temp1 + i < UInt64.MaxValue)
                        {
                            i += temp1;
                            charfound = true;
                        }
                        else
                        {
                            Console.WriteLine("This is the end. i = {0}", i);
                            Console.ReadKey();
                            return;
                        }
                        //break;
                        //comment
                    }
                }
                if (i.ToString().Contains("0"))
                {
                    if (!UInt64.TryParse(i.ToString().Replace("0", "2"), out i))
                    {
                        Console.WriteLine("This is the end. i = {0}", i);
                        Console.ReadKey();
                        return;
                    }
                }
                else if (!charfound)
                {
                    if (i + 1 <= UInt64.MaxValue)
                        i++;
                    else
                    {
                        Console.WriteLine("This is the end. i = {0}", i);
                        Console.ReadKey();
                        return;
                    }
                }


            }
            Console.WriteLine("This is the end. i = {0}", i);
            Console.ReadKey();
            return;
            
        }
    }
}
