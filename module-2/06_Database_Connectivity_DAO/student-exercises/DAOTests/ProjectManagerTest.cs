using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using ProjectOrganizer;
using ProjectOrganizer.Models;
using System.Dynamic;
using System.Data.SqlClient;
using System;

namespace DAOTests
{
    [TestClass]
    public class ProjectManagerTest
    {
        protected string ConnectionString { get; } = @"Data Source =.\SQLEXPRESS; Initial Catalog = EmployeeDB; Integrated Security = True";
        protected Employee TesterOnProj { get; private set; } = new Employee
        { JobTitle = "Tester", FirstName = "Sam", LastName = "Adams", BirthDate = new DateTime(1990, 01, 01), Gender = "M", HireDate = new DateTime(2000, 01, 01) };
        protected Employee TesterUnassigned { get; private set; } = new Employee
        {  JobTitle = "Tester", FirstName = "Suzie", LastName = "Johnson", BirthDate = new DateTime(1980, 02, 02), Gender = "F", HireDate = new DateTime(1995, 02, 02) };
        protected Project TestProject { get; private set; } = new Project
        { Name = "Test Project", StartDate = new DateTime(2020, 10, 10), EndDate = new DateTime(2020, 12, 01) };
        protected Department TestDepartment { get; private set; } = new Department
        { Name = "Test Department" };

        private TransactionScope Transaction;

        [TestInitialize]
        public void Setup()
        {   
            Transaction = new TransactionScope();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sqlText;
                //Add Test Department, Assign Test Employees to TestDept
                sqlText = $"insert into department values('{TestDepartment.Name}');";
                TestDepartment.Id = AddObjectToTable(sqlText, connection);
                TesterOnProj.DepartmentId = TestDepartment.Id;
                TesterUnassigned.DepartmentId = TestDepartment.Id;
                //Add Test Employees
                sqlText = $"insert into employee values({FormatEmployeeSQLValues(TesterOnProj)});";
                TesterOnProj.EmployeeId = AddObjectToTable(sqlText, connection);
                sqlText = $"insert into employee values({FormatEmployeeSQLValues(TesterUnassigned)});";
                TesterUnassigned.EmployeeId = AddObjectToTable(sqlText, connection);
                //Add Test Project
                sqlText = $"insert into project values('{TestProject.Name}', '{TestProject.StartDate}', '{TestProject.EndDate}');";
                TestProject.ProjectId = AddObjectToTable(sqlText, connection);
                //Assign TesterOnProj to TestProj
                sqlText = $"insert into project_employee values({TestProject.ProjectId}, {TesterOnProj.EmployeeId});";
                SqlCommand command = new SqlCommand(sqlText, connection);
                command.ExecuteNonQuery();
            }
        }

        private int AddObjectToTable(string sqlText, SqlConnection connection)
        {
            sqlText += "select scope_identity();";
            SqlCommand command = new SqlCommand(sqlText, connection);
            int returnId = Convert.ToInt32(command.ExecuteScalar());
            return returnId;
        }

        [TestCleanup]
        public void Cleanup()
        {
            Transaction.Dispose();
        }

        protected int GetRowCount(string table)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"select count(*) from {table}", connection);
                int rowCount = Convert.ToInt32(command.ExecuteScalar());
                return rowCount;
            }
        }

        protected string FormatEmployeeSQLValues(Employee emp)
        {
            string format = $"{emp.DepartmentId}, '{emp.FirstName}', '{emp.LastName}', '{emp.JobTitle}', '{emp.BirthDate}', '{emp.Gender}', '{emp.HireDate}'";
            return format;
        }
    }
}