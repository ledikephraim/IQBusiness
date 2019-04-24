namespace IQBusiness.Tests
{

  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Data.Entity.Infrastructure;
  using System.Linq;
  using System.Web.Http;
  using IQBusiness.Persistence;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using NSubstitute;

  [TestClass]
  public class TestEmployees
  {
    [TestMethod]
    public void Test_GetEmployeeIsNotNull()
    {
      API.Models.Employee employee = null;
      using (var context = GetSsoDbContext())
      using (var controller = new API.Controllers.EmployeesController(context, false))
      {
         employee = controller.Get(1);
      }

      Assert.IsNotNull(employee);
    }
    [TestMethod]
    public void Test_GetEmployeeIsNull()
    {
      API.Models.Employee employee = null;
      using (var context = GetSsoDbContext())
      using (var controller = new API.Controllers.EmployeesController(context, false))
      {
        employee = controller.Get(2);
      }

      Assert.IsNull(employee);
    }
    [TestMethod]
    public void Test_PostEmployee_Should_Return_Conflict()
    {
      IHttpActionResult result;
      API.Models.Employee employee = new API.Models.Employee
      {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        Address = "Lorem",
        Email = "ip@sum.com"
      };
      using (var context = GetSsoDbContext())
      using (var controller = new API.Controllers.EmployeesController(context, false))
      {
        result = controller.Post(employee);
      }

      Assert.IsInstanceOfType(result,typeof(System.Web.Http.Results.ConflictResult));
    }
    [TestMethod]
    public void Test_PostEmployeeBadRequest()
    {
      API.Models.Employee employee = null;

      IHttpActionResult result;
      using (var context = GetSsoDbContext())
      using (var controller = new API.Controllers.EmployeesController(context, false))
      {
         result = controller.Post(employee);
      }

      Assert.IsInstanceOfType(result, typeof(System.Web.Http.Results.BadRequestErrorMessageResult));
    }
    [TestMethod]
    public void Test_PostEmployee_ShouldReturn_Success()
    {

      IHttpActionResult result;
      API.Models.Employee employee = new API.Models.Employee
      {
        FirstName ="John",
         LastName ="Doe",
         Address="Lorem",
         Email ="ip@sum.com"
      };
      using (var context = GetSsoDbContext())
      using (var controller = new API.Controllers.EmployeesController(context, false))
      {
        result = controller.Post(employee);
      }

      Assert.IsInstanceOfType(result,typeof(System.Web.Http.Results.OkResult));
    }
    [TestMethod]
    public void Test_PutEmployee_NotFound()
    {
      API.Models.Employee employee = new API.Models.Employee
      {
        Id = 21
      };

      IHttpActionResult result;
      using (var context = GetSsoDbContext())
      using (var controller = new API.Controllers.EmployeesController(context, false))
      {
        result = controller.Put(employee);
      }

      Assert.IsInstanceOfType(result, typeof(System.Web.Http.Results.NotFoundResult));
    }
    private IQBusinessContext GetSsoDbContext()
    {
      List<Employee> employees = new List<Employee> { new Employee { Id = 1, FirstName = "Otis" } };
      var mockDbSet = Substitute
        .For
        <DbSet<Employee>, IQueryable<Employee>,
          IDbAsyncEnumerable<Employee>>()
        .SetupData(employees);


      var mockDb = Substitute.For<IQBusinessContext>();
      mockDb.Employees.Returns(mockDbSet);

      return mockDb;
    }
  }
}
