using AutoMapper;
using ModuleBL;
using ModuleBL.Models;
using ModulePL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModulePL
{
    public class StudentsController
    {
        public StudentViewModel GetById(int id)
        {
            var service = new StudentService();

            var student = service.GetById(id);

            var resultStud = new StudentViewModel()
            {
                Age = student.Age.GetValueOrDefault(),
                FullName = $"{student.FirstName} {student.Lastname}",
                Payments = student.Payments.Select(paymentView => new PaymentViewModel
                {
                    Date = paymentView.Date,
                    Value = paymentView.Value
                })
            };

           return resultStud;
        }
    }
}
