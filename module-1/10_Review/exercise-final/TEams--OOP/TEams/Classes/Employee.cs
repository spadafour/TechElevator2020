using System;
using System.Collections.Generic;
using System.Text;

namespace TEams.Classes
{
    public class Employee
    {
        public const double DEFAULT_STARTING_SALARY = 60000.00;

        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public Department Department { get; set; }
        public string HireDate { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public Employee()
        {
        }

        public Employee(long employeeId, string firstName, string lastName, string email, Department department, string hireDate)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Department = department;
            HireDate = hireDate;
            Salary = DEFAULT_STARTING_SALARY;
        }



        public void RaiseSalary(double percent)
        {
            double raise = this.Salary * percent / 100;
            Salary += raise;
        }


    }
}
