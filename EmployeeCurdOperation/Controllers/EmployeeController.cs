
namespace EmployeeCurdOperation.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Model;
    using EmployeeBusinessLayer;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer;
    using Microsoft.AspNetCore.Cors;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDataAccessLayer employeeDataAccessLayer;
        
        public EmployeeController(IEmployeeDataAccessLayer employeeDataAccessLayer)
        {
            this.employeeDataAccessLayer = employeeDataAccessLayer;
            
        }

        /// <summary>
        /// This Api will return all Employee Data
        /// name of this api is " api/employee" .
        /// </summary>
        /// <returns> return employee data</returns>    
        [HttpGet]
        public IActionResult GetEmployeeDetails()
        {
            string message;
            Response response=employeeDataAccessLayer.GetAllEmployees();
            if (response.Result) {
                 message = "Employee List";
                return this.Ok(new {message ,Data=response.Body, HttpStatusCode.OK});
            }
            message = "No Record Found";
            return this.BadRequest(new {message, Data = response.Body, HttpStatusCode.BadRequest });
        }

        /// <summary>
        /// This Api will return  Employee Data of provided id.
        /// </summary>
        /// <returns> return employee data of givenid</returns>
        [HttpGet("{id}")]
        public IActionResult GetEmployeeRecord(int id)
        {
            string message;
            Response response = employeeDataAccessLayer.GetEmployeeData(id);
            if (response.Body!=null)
            {
                message = "Employee Record";
                return this.Ok(new { message, Data = response.Body ,HttpStatusCode.OK});
            }
            message = "No Record Found";
            return this.BadRequest(new { message, Data = response.Body ,HttpStatusCode.BadRequest});
        }

        /// <summary>
        /// This Api will ADD Employee record in employee table.
        /// </summary>
        /// <returns> return employee data</returns>
        
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public  IActionResult AddEmloyee([FromBody] Employee employee)
        {
            string message;
            Response response = employeeDataAccessLayer.AddEmployee(employee);
            if (response.Result)
            {
                message = "Employee Added";
                return this.Ok(new { message,Data="", HttpStatusCode.OK });
            }
            message = "Operation Failed";
            return this.BadRequest(new { message, Data = response.Body,HttpStatusCode.BadRequest });
        }

        // DELETE api/values/5
        /// <summary>
        /// This Api will Delete Employee Data.
        /// </summary>
        /// <returns> return employee data</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string message;
            Response response = employeeDataAccessLayer.DeleteEmployee(id);
            if (response.Result)
            {
                message = "Employee Record Deleted";
                return this.Ok(new { message ,data="", HttpStatusCode.OK });
            }
            message ="Failed to Delete Employee Record";
            return this.BadRequest(new { message ,Data=response.Body, HttpStatusCode.BadRequest });
        }

        // Update api/values/5
        /// <summary>
        /// This Api will Delete Employee Data.
        /// </summary>
        /// <returns> return employee data</returns>
        [HttpPut]
        public IActionResult EditEmployee([FromBody]Employee employee)
        {

            string message;
            Response response = employeeDataAccessLayer.EditEmployee(employee);
            if (response.Result)
            {
                message = "Employee Record Updated";
                return this.Ok(new { message,data="",HttpStatusCode.OK});
            }
            message = "Failed to Update";
            return this.BadRequest(new { message ,Data=response.Body, HttpStatusCode.BadRequest });
        }

    }
}
