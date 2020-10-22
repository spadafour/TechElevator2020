using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DAOTests
{
    [TestClass]
    public class EmployeeDAOTests : ProjectManagerTest
    {
        [TestMethod]
        public void GetEmployeesTest()
        {
            EmployeeSqlDAO employeeDAO = new EmployeeSqlDAO(ConnectionString);
            int expected = GetRowCount("employee");
            int result = employeeDAO.GetAllEmployees().Count;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetEmployeesWithoutProjectsTest()
        {
            EmployeeSqlDAO employeeDAO = new EmployeeSqlDAO(ConnectionString);
            IList<Employee> noProjEmployees = employeeDAO.GetEmployeesWithoutProjects();
            bool unassignedReturned = false;
            bool onProjReturned = false;
            //This should catch when unassigned Employees come back and also checks to make sure assigned employees do not come back
            foreach (Employee emp in noProjEmployees)
            {
                if (emp.EmployeeId == TesterUnassigned.EmployeeId)
                {
                    unassignedReturned = true;
                }
                if (emp.EmployeeId == TesterOnProj.EmployeeId)
                {
                    onProjReturned = true;
                }
            }
            Assert.IsTrue(unassignedReturned && !onProjReturned);
        }

        [DataTestMethod]
        [DataRow("S", "s", true, true)]
        [DataRow("Sam", "s", true, false)]
        [DataRow("S", "Johnson", false, true)]
        [DataRow("abcdefghij123", "klmnopqrs456", false, false)]
        public void SearchTest(string firstName, string LastName, bool shouldFindSamAdams, bool shouldFindSuzieJohnson)
        {
            EmployeeSqlDAO employeeDAO = new EmployeeSqlDAO(ConnectionString);
            IList<Employee> namesFound = employeeDAO.Search(firstName, LastName);
            bool foundOnProjSamAdams = false;
            bool foundUnassignedSuzieJohnson = false;
            foreach (Employee emp in namesFound)
            {
                if (emp.EmployeeId == TesterOnProj.EmployeeId)
                {
                    foundOnProjSamAdams = true;
                }
                if (emp.EmployeeId == TesterUnassigned.EmployeeId)
                {
                    foundUnassignedSuzieJohnson = true;
                }
            }
            Assert.IsTrue(foundOnProjSamAdams == shouldFindSamAdams && foundUnassignedSuzieJohnson == shouldFindSuzieJohnson);
        }
    }
}
