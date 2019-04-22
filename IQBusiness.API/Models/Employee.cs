namespace IQBusiness.API.Models
{
  /// <summary>
  /// Represents an employee.
  /// </summary>
  public class Employee
  {

    /// <summary>
    /// Gets or sets the identifier of an employee.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of an employee.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of an employee.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets an address of an employee.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets an email address of an employee.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets a telephone contact of an employee.
    /// </summary>
    public string Telephone { get; set; }

    /// <summary>
    /// Gets or sets a social media address of an employee.
    /// </summary>
    public string SocialMediaAddress { get; set; }
  }
}
