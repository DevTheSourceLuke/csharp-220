// Author: Luke Bushey
// Title: Homework 2

using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            var helloPwUsers = users.Where(u => u.Password == "hello");

            Console.WriteLine("List of users and passwords:");
            users.ForEach(u => Console.WriteLine($"Name: {u.Name}, Password: {u.Password}"));            

            Console.WriteLine();
            Console.WriteLine("Users with a password of 'hello'");
            helloPwUsers.ToList().ForEach(u => Console.WriteLine($"Name: {u.Name}, Password: {u.Password}"));

            // Output all users before removing 
            Console.WriteLine();
            Console.WriteLine("List of users and passwords before removing ones where name == password:");
            users.ForEach(u => Console.WriteLine($"Name: {u.Name}, Password: {u.Password}"));
           
            // Removing users where password equals their names (case in-sensitive)
            users.RemoveAll(u => u.Password.ToLower() == u.Name.ToLower());

            Console.WriteLine();
            Console.WriteLine("List of users and passwords after removal of users where name == password:");
            users.ForEach(u => Console.WriteLine($"Name: {u.Name}, Password: {u.Password}"));

            // Removing the first user where the password =='hello'
            users.Remove(users.First(u => u.Password == "hello"));

            // Output all users after removing the first instance of one where the password == 'hello'
            Console.WriteLine();
            Console.WriteLine("Lastly listing users after removing first user where password == 'hello'");
            users.ForEach(u => Console.WriteLine($"Name: {u.Name}, Password: {u.Password}"));
        }
    }
}
