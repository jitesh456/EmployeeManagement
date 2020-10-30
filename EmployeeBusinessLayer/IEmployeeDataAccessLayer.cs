
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer;

namespace EmployeeBusinessLayer
{
   public interface IEmployeeDataAccessLayer
    {
        Response AddEmployee(Employee employee);

        Response DeleteEmployee(int? id);

        Response GetEmployeeData(int? id);

        Response GetAllEmployees();

        Response EditEmployee(Employee employee);

    }
}
