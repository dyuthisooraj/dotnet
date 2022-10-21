using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAppRepository;
using EmployeeAppModels;
using EmployeeAppBusiness.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAppBusiness
{
    public class EmployeeImplement : IEmployee
    {
        private readonly EmployeeDBContext _dbobj;
        public EmployeeImplement(EmployeeDBContext _dboj)
        {
            _dbobj = _dboj;
        }

        public List<EmployeeRegistration> Get()
        {
            return _dbobj.Details.ToList();
        }

        public void Post(EmployeeRegistration emp1)
        {
            _dbobj.Details.Add(emp1);
            _dbobj.SaveChanges();
        }


        public void Delete(string username)
        {
            EmployeeRegistration emp = _dbobj.Details.FirstOrDefault(i => i.UserName == username);
            if (emp != null)
            {
                _dbobj.Remove(emp);
                _dbobj.SaveChanges();
            }
        }

        public List<EmployeeRegistration> Edit()
        {
            throw new NotImplementedException();
        }

        public void create(EmployeeRegistration employee)
        {
            _dbobj.Details.Add(employee);
            _dbobj.SaveChanges();
        }


    }
}
