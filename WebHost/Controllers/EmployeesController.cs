using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebHost.Models;

namespace WebHost.Controllers
{
  public class EmployeeController : Controller
  {
    // GET: Employee
    public async Task<ActionResult> Index()
    {
      HttpResponseMessage response = null;
      using (var client = new HttpClient())
      {
        response = await client.GetAsync("http://localhost:9000/api/employees");
      }

      var result = await response.Content.ReadAsAsync<List<Employee>>();
      return View(result);
    }

    // GET: Employee/Details/5
    public ActionResult Details(int id)
    {
      HttpResponseMessage response = null;
      using (var client = new HttpClient())
      {
        response =client.GetAsync($"http://localhost:9000/api/employees/{id}").Result;
        
      }
      var model = response.Content.ReadAsAsync<Employee>().Result;
        return View(model);
    }

    // GET: Employee/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Employee/Create
    [HttpPost]
    public async Task<ActionResult> Create(FormCollection collection)
    {
      try
      {
        // TODO: Add insert logic here
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
          var result = await httpClient.PostAsJsonAsync("http://localhost:9000/api/Employees", employee);
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
        response = await client.GetAsync($"http://localhost:9000/api/Employees/{id}");
      }
      var model = await response.Content.ReadAsAsync<Employee>();
      return View(model);
    }

    // POST: Employee/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add update logic here
        // TODO: Add insert logic here
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
          var result = httpClient.PutAsJsonAsync("http://localhost:9000/api/Employees", employee).Result;
        }

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // GET: Employee/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Employee/Delete/5
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
  }
}
