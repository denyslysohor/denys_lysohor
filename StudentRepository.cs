using ModuleDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDAL
{
    public class StudentRepository
    {
  
        private readonly ModuleContext _context;

        public StudentRepository()
        {
            _context = new ModuleContext();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);    
        }
        public IEnumerable<Payment> GetPayments(int id)
        {
            var st = _context.Payments.Where(p => p.StudentId == id);
            
            return st;
        }
    }
}
