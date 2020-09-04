
namespace EmployeeBusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    using Model;
    using System.Net;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer;

    public class EmployeeDataAccessLayer : IEmployeeDataAccessLayer
    {

        IEmployeeRepository employeeRepository;

        public EmployeeDataAccessLayer(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        /// <summary>
        /// This function will fetch data for employee and return all record. 
        /// </summary>
        /// <returns></returns>
        public Response GetAllEmployees()
        {
            try
            {
                var employeeRecord = this.employeeRepository.GetAllEmployees();
                return this.SetResponse(employeeRecord, true);
            }
            catch (Exception e)
            {
                return this.SetResponse(e.Message, false);
            }

        }

        /// <summary>
        /// This function is for adding data in employee table.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Response AddEmployee(Employee employee)
        {
            try
            {
                var result = this.employeeRepository.AddEmployee(employee);
                return this.SetResponse(null, result);
            }
            catch (Exception e)
            {
                return this.SetResponse(e.Message, false);
            }
        }

        /// <summary>
        /// This will return record of perticular employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response GetEmployeeData(int? id)
        {
            try
            {
                var employeeRecord = this.employeeRepository.GetEmployeeData(id);
                return this.SetResponse(employeeRecord, true);
            }
            catch (Exception e)
            {
                return this.SetResponse(e.Message, false);
            }
        }
        

        /// <summary>
        /// This function will Delete Employee Record.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response DeleteEmployee(int? id)
        {
            try
            {
                var result = this.employeeRepository.DeleteEmployee(id);
                return this.SetResponse(null, result);
            }
            catch (Exception e)
            {
                return this.SetResponse(e.Message, false);
            }
        }


        public Response EditEmployee(Employee employee)
        {
            try
            {
                var result = this.employeeRepository.EditEmployee(employee);
                return this.SetResponse(null, result);

            }
            catch (Exception e)
            {
                return this.SetResponse(e.Message, false);
            }
        }

        public Response SetResponse(object body,Boolean result)
        {
            return new Response()
            {
                Body = body,
                Result=result,
            };
        }
        
    }
}
