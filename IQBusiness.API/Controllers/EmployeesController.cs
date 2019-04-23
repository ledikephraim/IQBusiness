namespace IQBusiness.API.Controllers
{
  using IQBusiness.API.Models;
  using System.Linq;
  using System.Web.Http;


  public class EmployeesController : ApiController
  {
    private Persistence.IQBusinessContext dbContext;
    private bool controllerOwnsDBContext;
    public EmployeesController() : this(new Persistence.IQBusinessContext(), true)
    {

    }
    public EmployeesController(Persistence.IQBusinessContext dbContext, bool controllerOwnsDBContext)
    {
      this.dbContext = dbContext;
      this.controllerOwnsDBContext = controllerOwnsDBContext;
    }

    /// <summary>
    /// Retrieves a collections of employees.
    /// </summary>
    /// <returns></returns>
    public IQueryable<Employee> Get()
    {
      //read from db;
      return dbQuery();
    }

    /// <summary>
    /// Retrieves a single employee.
    /// </summary>
    /// <param name="id">the employee identifier.</param>
    /// <returns></returns>
    public Employee Get(int id)
    {
      //return from db.
      var employee = dbQuery().Where(x => x.Id == id);

      return employee.FirstOrDefault();
    }

    /// <summary>
    /// Creates a new employee.
    /// </summary>
    /// <param name="model">the new employee to be created.</param>
    /// <returns></returns>
    public IHttpActionResult Post(Employee model)
    {
      // map employee to db type.
      if (dbQuery().Any(x => x.Id == model.Id))
      {
        return Conflict();
      }

      //validate model
      if (string.IsNullOrEmpty(model.FirstName))
      {
        return BadRequest("invalid first name value supplied.");
      }
      if (string.IsNullOrEmpty(model.LastName))
      {
        return BadRequest("invalid last name value supplied.");
      }

      //persist.
      var employee = new IQBusiness.Persistence.Employee
      {
        FirstName = model.FirstName,
        LastName = model.LastName,
        PhysicalAddress = model.Address,
        Email = model.Email,
        Telephone = model.Telephone,
        SocialMediaAddress = model.SocialMediaAddress
      };

      dbContext.Employees.Add(employee);
      dbContext.SaveChanges();

      return Ok();
    }

    /// <summary>
    /// Updates an existing employee.
    /// </summary>
    /// <param name="model">the employee to be updated.</param>
    /// <returns></returns>
    public IHttpActionResult Put(Employee model)
    {
      //check row existence
      var employee = dbContext.Employees.FirstOrDefault(x => x.Id == model.Id);
      //return not found if not found.
      if (employee == null)
      {
        return NotFound();
      }

      //validate model
      if (string.IsNullOrEmpty(model.FirstName))
      {
        return BadRequest("invalid first name value supplied.");
      }
      if (string.IsNullOrEmpty(model.LastName))
      {
        return BadRequest("invalid last name value supplied.");
      }

      //Update row
      employee.FirstName = model.FirstName;
      employee.LastName = model.LastName;
      employee.PhysicalAddress = model.Address;
      employee.Email = model.Email;
      employee.Telephone = model.Telephone;
      employee.SocialMediaAddress = model.SocialMediaAddress;

      dbContext.Entry(employee).CurrentValues.SetValues(employee);
      dbContext.SaveChanges();
      return Ok(model);
    }

    /// <summary>
    /// Deletes an existing employee.
    /// </summary>
    /// <param name="key">the employee identifier.</param>
    /// <returns></returns>
    public IHttpActionResult Delete(int key)
    {
      //check row existence
      var employee = dbContext.Employees.FirstOrDefault(x => x.Id == key);
      if (employee == null)
      {
        //return not found if not found.
        return NotFound();
      }

      //delete row.
      dbContext.Employees.Remove(employee);
      dbContext.SaveChanges();
      return Ok();
    }
    private IQueryable<Employee> dbQuery()
    {
      var employees = dbContext.Employees;
      var result = from e in employees
                   select new Employee
                   {
                     Id = e.Id,
                     FirstName = e.FirstName,
                     LastName = e.LastName,
                     Address = e.PhysicalAddress,
                     Email = e.Email,
                     Telephone = e.Telephone,
                     SocialMediaAddress = e.SocialMediaAddress
                   };
      return result;
    }
  }
}

