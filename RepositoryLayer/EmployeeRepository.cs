
namespace RepositoryLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using Model;

    public class EmployeeRepository : IEmployeeRepository
    {
        private string ConnectionString;

        private IConfiguration configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = configuration.GetSection("ConnectionStrings").GetSection("UserDbConnection").Value;
        }

        /// <summary>
        /// This function will fetch data for employee and return all record. 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstemployee = new List<Employee>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(rdr["EmployeeID"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Email = rdr["Email"].ToString();
                        employee.Password = rdr["Password"].ToString();
                        employee.PhoneNo = rdr["PhoneNo"].ToString();
                        lstemployee.Add(employee);
                    }
                    return lstemployee;
                }

                con.Close();
            }
            return lstemployee;
        }

        /// <summary>
        /// This function is for adding data in employee table.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Boolean AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Password", employee.Password);
                    cmd.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
                    con.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                    return true;   
                    }
                
                    con.Close();   
            }

            return false;
        }

        /// <summary>
        /// This will return record of perticular employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeData(int? id)
        {
            Employee employee = new Employee();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeeData", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmpId", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            employee.Id = Convert.ToInt32(rdr["EmployeeID"]);
                            employee.Name = rdr["Name"].ToString();
                            employee.Email = rdr["Email"].ToString();
                            employee.PhoneNo = rdr["PhoneNo"].ToString();
                        }

                        return employee;
                    }
                    con.Close();
            }
            return null;
        }

        /// <summary>
        /// This function will Delete Employee Record.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmpId", id);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
            }

            return false;
        }


        public Boolean EditEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmpId", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                con.Close();
            }
            return false;
        }
        
    }
}
