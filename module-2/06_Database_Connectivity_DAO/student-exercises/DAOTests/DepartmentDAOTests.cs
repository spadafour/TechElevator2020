using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Bson;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DAOTests
{
    [TestClass]
    public class DepartmentDAOTests : ProjectManagerTest
    {
        [TestMethod]
        public void GetDepartmentsTest()
        {
            DepartmentSqlDAO testDeptDAO = new DepartmentSqlDAO(ConnectionString);
            int expected = GetRowCount("department");
            int result = testDeptDAO.GetDepartments().Count;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateDepartmentSuccessTest()
        {
            DepartmentSqlDAO testDeptDAO = new DepartmentSqlDAO(ConnectionString);
            int deptCountBefore = GetRowCount("department");
            Department newDept = new Department() { Name = "obviousName" };
            testDeptDAO.CreateDepartment(newDept);
            int deptCountAfter = GetRowCount("department");
            Assert.AreNotEqual(deptCountBefore, deptCountAfter);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void CreateDepartmentFailTest()
        {
            DepartmentSqlDAO testDeptDAO = new DepartmentSqlDAO(ConnectionString);
            Department newDept = new Department { Name = $"{TestDepartment.Name}" };
            testDeptDAO.CreateDepartment(newDept);
        }

        [TestMethod]
        public void UpdateDepartmentSuccessTest()
        {
            DepartmentSqlDAO testDeptDAO = new DepartmentSqlDAO(ConnectionString);
            TestDepartment.Name = "ObviouslyDifferentName";
            bool result = testDeptDAO.UpdateDepartment(TestDepartment);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateDepartmentFailTest()
        {
            DepartmentSqlDAO testDeptDAO = new DepartmentSqlDAO(ConnectionString);
            Department deptFailName = new Department() { Name = "ObviousFailName" };
            testDeptDAO.CreateDepartment(deptFailName);
            TestDepartment.Name = deptFailName.Name;
            bool result = testDeptDAO.UpdateDepartment(TestDepartment);
            Assert.IsFalse(result);
        }
    }
}
