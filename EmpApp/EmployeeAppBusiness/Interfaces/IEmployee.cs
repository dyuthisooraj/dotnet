using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAppModels;

namespace EmployeeAppBusiness.Interfaces
{
    public interface IEmployee
    {
        List<EmployeeRegistration> Get();

        void Post(EmployeeRegistration emp1);

        List<EmployeeRegistration> Edit();

        void Delete(string emp2);

       


    }
}
