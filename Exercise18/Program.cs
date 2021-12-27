using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise18
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = 'л';
            string text = "ехал грека по реке видит грека в реке рак";
            string[] array = text.Split(' ');
            var words = array.Where(n => n.EndsWith(symbol)).SingleOrDefault();       
                      
            //Задание 2
            int[] numbers = new int[] { 5, 8, 0, -1, 6, 4, -1, -3 };
            var num_res = numbers.Where(n=> n>0);
            int count = num_res.Count();
            double average = (double)num_res.Sum() / count;

            //Задание 3
            string title = "Женя скоро будет свободен, а у вас все только начинается";
            string s = "о";
            var chars = title.Where(c => !s.Contains(c)).ToArray();
            string title2 = string.Empty;
            foreach (var item2 in chars)
            {
                title2 += item2;
            }

            //Задание 4
            //(join, where, take, skip и select)
            List<Phone> phonenumbers = new List<Phone>()
            {
                new Phone{ID = 1 , PhoneNumber = - 6651166 },
                new Phone{ID = 2 , PhoneNumber = 0 },
                new Phone{ID = 3 , PhoneNumber = 5648962 },
                new Phone{ID = 4 , PhoneNumber = -89 },
                new Phone{ID = 5 , PhoneNumber = 1111111 },
                new Phone{ID = 6 , PhoneNumber = 891516 }
            };

            List<Person> names = new List<Person>()
            {
                new Person{ID = "1" , Name = "Коля"},
                new Person{ID = "2" , Name = "Петя"},
                new Person{ID = "3" , Name = "Саша"},
                new Person{ID = "4" , Name = "Таня"},
                new Person{ID = "5" , Name = "Маша"},
                new Person{ID = "6" , Name = "Валера"},
            };

            var selected1 = from t in phonenumbers
                           where t.PhoneNumber>0                                 
                           select t;

            var selected2 = selected1.Skip(1).Take(4);

            var result = from i in selected2
                         join n in names on i.ID.ToString() equals n.ID
                         select new { ID = i.ID , Name = n.Name , PhoneNumber = i.PhoneNumber};           

            foreach (var client in result)
            {
                Console.WriteLine($"Name = {client.Name} , ID = {client.ID} , PhoneNumber = {client.PhoneNumber}");
            }

        }
    }
    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    class Phone
    {
        public int PhoneNumber { get; set; }
        public int ID { get; set; }
    }
}
