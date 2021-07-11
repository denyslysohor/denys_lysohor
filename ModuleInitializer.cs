using ModuleDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDAL
{
    class ModuleInitializer : DropCreateDatabaseAlways<ModuleContext>
    {
        private void StudentInitializer(ModuleContext context)
        {
            var studentList = new List<Student>()
            {
                new Student
                {
                    FirstName = "Alex",
                    LastName = "Linnik",
                    Age = 20
                },
                new Student
                {
                    FirstName = "Egor",
                    LastName = "Kulik",
                    Age = 22
                }
            };

            foreach (var student in studentList)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();
        }
        private void PaymentInitializer(ModuleContext context)
        {
            var paymentList = new List<Payment>()
            {
                new Payment
                { 
                    StudentId = 1,
                    Date = new DateTime(2021,1,8),
                    Value = 1000
                },
                new Payment
                {
                    StudentId = 2,
                    Date = new DateTime(2021,1,9),
                    Value = 1200
                },
                new Payment
                {
                    StudentId = 2,
                    Date = new DateTime(2021, 7, 10),
                    Value = 800
                }
            };

            foreach (var payment in paymentList)
            {
                context.Payments.Add(payment);
            }
            context.SaveChanges();
        }
        
        protected override void Seed(ModuleContext context)
        {
            StudentInitializer(context);
            PaymentInitializer(context);
        }
    }
}
