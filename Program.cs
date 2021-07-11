﻿
using ModulePL;
using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ctrl = new StudentsController();

            var student = ctrl.GetById(2);

            Console.WriteLine($"{student.FullName} {student.Age}");

           
            foreach (var item in student.Payments)
            {
                Console.WriteLine($"{item.Date} {item.Value}");
            }
           
        }
    }
}
