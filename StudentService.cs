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

          var mapperPayment = new MapperConfiguration(cfg =>
               cfg.CreateMap<Payment, PaymentModel>()).CreateMapper();

          var mapper = new MapperConfiguration(cfg =>
                 cfg.CreateMap<Student, StudentModel>()
                  .ForMember(s => s.Payments, o => o.MapFrom(a => mapperPayment.Map< IEnumerable<Payment>, IEnumerable<PaymentModel>>(_studentRepository.GetPayments(a.Id))))
                  ).CreateMapper();

            var results = mapper.Map<Student, StudentModel>(studentEntity);

            return results;
        }
      
    }
}
