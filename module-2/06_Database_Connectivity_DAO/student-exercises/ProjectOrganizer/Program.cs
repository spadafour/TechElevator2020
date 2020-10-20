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

            IProjectDAO projectDAO = null;
            IEmployeeDAO employeeDAO = null;
            IDepartmentDAO departmentDAO = null;

            ProjectCLI projectCLI = new ProjectCLI(employeeDAO, projectDAO, departmentDAO);
            projectCLI.RunCLI();
        }
    }
}
