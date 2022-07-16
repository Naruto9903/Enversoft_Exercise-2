using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCSVFile();
            Console.ReadLine();
        }
        static void ReadCSVFile()
        {
            var records = File.ReadAllLines("C:\\Users\\user\\source\\repos\\Exercise 2\\Exercise 2\\Data.csv");
            var list = new List<Person>();
            List<string> ListDataFirstName = new List<string>();
            List<string> ListDataLastName = new List<string>();
            List<string> ListDataAddress = new List<string>();
            List<string> FullNames = new List<string>();
            
            foreach (var record in records)
            {
                var values = record.Split(',');
                ListDataFirstName.Add(values[0]);
                ListDataLastName.Add(values[1]);
                ListDataAddress.Add(values[2]);
            }
            ListDataFirstName.RemoveAt(0);
            ListDataLastName.RemoveAt(0);
            FullNames.AddRange(ListDataFirstName);
            FullNames.AddRange(ListDataLastName);
            FullNames.Sort();

            List<string> list_test = new List<string>();
            foreach (var namelist in FullNames.GroupBy(i => i).OrderByDescending(x => x.Count()))
            {
                using (TextWriter Tw = new StreamWriter("C:\\Users\\user\\source\\repos\\Exercise 2\\Exercise 2\\TextFiles\\Names.txt", true))
                {
                    Tw.WriteLine("{0} : {1}", namelist.Key, namelist.Count());
                    list_test.Add((namelist.Key).ToString());
                }
            }
            
            foreach (var grp in ListDataAddress.OrderBy(item => item.Split(' ').ElementAtOrDefault(1)))
            {
                using (TextWriter Tw = new StreamWriter("C:\\Users\\user\\source\\repos\\Exercise 2\\Exercise 2\\TextFiles\\Addresses.Txt", true))
                {
                    Tw.WriteLine(grp);
                    list_test.Add(grp.ToString());
                }
            }
            Console.WriteLine("Text Files Created Successfully");
            Console.WriteLine("Press Enter to Continue");

        }
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
          
}
