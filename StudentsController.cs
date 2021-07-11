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

            var mapper1 = new MapperConfiguration(cfg =>
               cfg.CreateMap<PaymentModel, PaymentViewModel>()).CreateMapper();

            var mapper = new MapperConfiguration(cfg =>
                 cfg.CreateMap<StudentModel, StudentViewModel>()
                  .ForMember(s => s.FullName, o => o.MapFrom(a=>a.FirstName + " " + a.Lastname))
                  .ForMember(s => s.Payments, o => o.MapFrom(a => mapper1.Map<IEnumerable<PaymentModel>, IEnumerable<PaymentViewModel>>(a.Payments)))
                  ).CreateMapper();

            return mapper.Map<StudentModel, StudentViewModel>(student);
        }
      
    }
}
