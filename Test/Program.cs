using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ApplicationContext context = new ApplicationContext();
        }
    }
}
