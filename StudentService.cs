using ModuleBL.Models;
using ModuleDAL;
using System;
using System.Linq;
using AutoMapper;
using ModuleDAL.Models;
using System.Collections.Generic;

namespace ModuleBL
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public StudentModel GetById(int id)
        {
          var studentEntity = _studentRepository.GetById(id);

            if (studentEntity == null)
                throw new ArgumentException("Student not found");

            var results = new StudentModel()
            {
                Id = studentEntity.Id,
                Age = studentEntity.Age,
                FirstName = studentEntity.FirstName,
                Lastname = studentEntity.LastName,
                Payments = studentEntity.Payments.Select(payment => new PaymentModel
                {
                    Date = payment.Date,
                    Id = payment.Id,
                    Value = payment.Value
                })
            };

            return results;
        }
      
    }
}
