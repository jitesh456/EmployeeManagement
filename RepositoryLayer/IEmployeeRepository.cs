using System.Collections.Generic;
using Model;

namespace RepositoryLayer
{
    public interface IEmployeeRepository
    {
        bool AddEmployee(Employee employee);
        bool DeleteEmployee(int? id);
        bool EditEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeData(int? id);
        
    }
}