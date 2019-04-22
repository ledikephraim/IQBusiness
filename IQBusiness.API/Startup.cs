namespace IQBusiness.API
{
  using Owin;
  using System.Web.Http;

  public class Startup
  {
    public void Configuration(IAppBuilder appBuidler)
    {
      HttpConfiguration config = new HttpConfiguration();
      config.Routes.MapHttpRoute(
        name: "DefaulApi",
        routeTemplate: "api/{controller}/{id}",
        defaults: new { id = RouteParameter.Optional }
        );

      appBuidler.UseWebApi(config);
    }
  }
}
