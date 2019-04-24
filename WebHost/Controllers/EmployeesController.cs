namespace WebHost.Controllers
{
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;
  using System.Web.Mvc;
  using WebHost.Models;
  using WebHost.Properties;

  public class EmployeeController : Controller
  {
    public async Task<ActionResult> Index()
    {
      HttpResponseMessage response = null;
      using (var client = new HttpClient())
      {
        response = await client.GetAsync($"{Settings.Default.APIBaseURI}/Employees");
      }

      var result = await response.Content.ReadAsAsync<List<Employee>>();
      return View(result);
    }

    public async Task<ActionResult> Details(int id)
    {
      HttpResponseMessage response = null;
      using (var client = new HttpClient())
      {
        response = await client.GetAsync($"{Settings.Default.APIBaseURI}/Employees/{id}");
      }
      var model = await response.Content.ReadAsAsync<Employee>();

      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(FormCollection collection)
    {

      if (!ModelState.IsValid)
      {

        var vm = new Error();

        vm.Message = new ErrorMessage

        {

          Error = "Registration failed",

          ErrorDescription = "Fields missing"

        };

        return View();
    
      }
      try
      {
        var firstName = collection["FirstName"];
        var lastName = collection["lastName"];
        var address = collection["Address"];
        var email = collection["Email"];
        var telephone = collection["Telephone"];
        var socialMediaAddress = collection["SocialMediaAddress"];

        var employee = new Employee
        {
          FirstName = firstName,
          LastName = lastName,
          Address = address,
          Telephone = telephone,
          SocialMediaAddress = socialMediaAddress
        };
        using (var httpClient = new HttpClient())
        {

          var result = await httpClient.PostAsJsonAsync($"{Settings.Default.APIBaseURI}/Employees", employee);
        }

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // GET: Employee/Edit/5
    public async Task<ActionResult> Edit(int id)
    {

      HttpResponseMessage response = null;
      using (var client = new HttpClient())
      {
        response = await client.GetAsync($"{Settings.Default.APIBaseURI}/Employees/{id}");
      }
      var model = await response.Content.ReadAsAsync<Employee>();
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
      try
      {
        var firstName = collection["FirstName"];
        var lastName = collection["lastName"];
        var address = collection["Address"];
        var email = collection["Email"];
        var telephone = collection["Telephone"];
        var socialMediaAddress = collection["SocialMediaAddress"];

        var employee = new Employee
        {
          Id = id,
          FirstName = firstName,
          LastName = lastName,
          Email = email,
          Address = address,
          Telephone = telephone,
          SocialMediaAddress = socialMediaAddress
        };
        using (var httpClient = new HttpClient())
        {
          var result = httpClient.PutAsJsonAsync($"{Settings.Default.APIBaseURI}/Employees", employee).Result;
        }

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    public ActionResult Delete(int id)
    {
      return View();
    }

    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
    [HttpPost]
    public async Task<ActionResult> employeeSearch(string search, string button)
    {

      // TODO: Add delete logic here
      HttpResponseMessage response = null;
      using (var httpClient = new HttpClient())
      {
        response = await httpClient.GetAsync($"{Settings.Default.APIBaseURI}/Employees/Search?={search}");
      }
      var result = await response.Content.ReadAsAsync<List<Employee>>();
      return View("Index", result);


    }
  }
}
