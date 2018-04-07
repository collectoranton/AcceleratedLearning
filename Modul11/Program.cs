using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;  

namespace Modul11
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"PersonExtra.csv";

            var parser = new Parser();

            var list = parser.CreateListOfCustomers(path);

            var list2 = new List<string>();

            foreach (var item in list)
            {
                if (!list2.Contains(item.Age))
                    list2.Add(item.Age);
            }

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Parser
    {
        public List<Customer> CreateListOfCustomers(string path)
        {
            var customerArray = File.ReadAllLines(path);
            var customerList = new List<Customer>();

            foreach (var customer in customerArray)
                customerList.Add(CustomerFromLine(customer));

            return customerList;
        }

        Customer CustomerFromLine(string lineFromList)
        {
            var splitCustomer = lineFromList.Split(',');
            var customer = new Customer();

            customer.ID = splitCustomer[0];
            customer.FirstName = splitCustomer[1];
            customer.LastName = splitCustomer[2];
            customer.Email = splitCustomer[3];
            customer.Gender = splitCustomer[4];
            customer.Age = splitCustomer[5];
            customer.PlaysTennis = splitCustomer[6];
            customer.LikesFruit = splitCustomer[7];
            customer.IPAddress = splitCustomer[8];

            return customer;
        }
    }

    class Customer
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string PlaysTennis { get; set; }
        public string LikesFruit { get; set; }
        public string IPAddress { get; set; }
    }
}
