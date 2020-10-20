using Microsoft.Extensions.Configuration;
using ProjectOrganizer.DAL;
using System;
using System.IO;

namespace ProjectOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            IProjectDAO projectDAO = new ProjectSqlDAO(@"Data Source =.\SQLEXPRESS; Initial Catalog = EmployeeDB; Integrated Security = True");
            IEmployeeDAO employeeDAO = new EmployeeSqlDAO(@"Data Source =.\SQLEXPRESS; Initial Catalog = EmployeeDB; Integrated Security = True");
            IDepartmentDAO departmentDAO = new DepartmentSqlDAO(@"Data Source =.\SQLEXPRESS; Initial Catalog = EmployeeDB; Integrated Security = True");

            ProjectCLI projectCLI = new ProjectCLI(employeeDAO, projectDAO, departmentDAO);
            projectCLI.RunCLI();
        }
    }
}
