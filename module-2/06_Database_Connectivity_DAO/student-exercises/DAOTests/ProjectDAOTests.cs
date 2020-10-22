using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Bson;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Text;

namespace DAOTests
{
    [TestClass]
    public class ProjectDAOTests : ProjectManagerTest
    {
        [TestMethod]
        public void GetProjectsTest()
        {
            ProjectSqlDAO projDAO = new ProjectSqlDAO(ConnectionString);
            int expected = GetRowCount("project");
            int result = projDAO.GetAllProjects().Count;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AssignEmployeeToProjSuccessTest()
        {
            ProjectSqlDAO projDAO = new ProjectSqlDAO(ConnectionString);
            bool result = projDAO.AssignEmployeeToProject(TestProject.ProjectId, TesterUnassigned.EmployeeId);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AssignEmployeeToProjFailTest()
        {
            ProjectSqlDAO projDAO = new ProjectSqlDAO(ConnectionString);
            bool result = projDAO.AssignEmployeeToProject(TestProject.ProjectId, TesterOnProj.EmployeeId);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveEmployeeFromProjSuccessTest()
        {
            ProjectSqlDAO projDAO = new ProjectSqlDAO(ConnectionString);
            bool result = projDAO.RemoveEmployeeFromProject(TestProject.ProjectId, TesterOnProj.EmployeeId);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveEmployeeFromProjFailTest()
        {
            ProjectSqlDAO projDAO = new ProjectSqlDAO(ConnectionString);
            bool result = projDAO.RemoveEmployeeFromProject(TestProject.ProjectId, TesterUnassigned.EmployeeId);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateProjectSuccessTest()
        {
            ProjectSqlDAO projDAO = new ProjectSqlDAO(ConnectionString);
            Project testProj = new Project { Name = "ObviousProj", StartDate = new DateTime(2020, 01, 01), EndDate = new DateTime(2020, 02, 02) };
            int projCountBefore = GetRowCount("project");
            projDAO.CreateProject(testProj);
            int projCountAfter = GetRowCount("project");
            Assert.AreNotEqual(projCountBefore, projCountAfter);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void CreateProjectFailTest()
        {
            ProjectSqlDAO projDAO = new ProjectSqlDAO(ConnectionString);
            Project testProj = new Project { Name = TestProject.Name, StartDate = new DateTime(2020, 01, 01), EndDate = new DateTime(2020, 02, 02) };
            projDAO.CreateProject(testProj);
        }
    }
}
