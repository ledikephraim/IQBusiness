namespace IQBusiness.API
{
  using Microsoft.Owin.Hosting;
  using System;
  class Program
  {
    static void Main(string[] args)
    {
      string baseAddress = "http://localhost:9000";


      WebApp.Start<Startup>(baseAddress);
      
      Console.ReadLine();
      
    }
  }
}
