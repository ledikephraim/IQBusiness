using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHost.Models
{
  public class Error
  {
    public ErrorMessage Message { get; set; }
  }
  /// <summary>
  /// Models the data for the error page.
  /// </summary>
  public class ErrorMessage
  {

    public ErrorMessage() { }


    /// <summary>
    /// The display mode passed from the authorization request.
    /// </summary>
    public string DisplayMode { get; set; }

    /// <summary>
    /// The UI locales passed from the authorization request.
    /// </summary>
    public string UiLocales { get; set; }

    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    public string Error { get; set; }

    /// <summary>
    /// Gets or sets the error description.
    /// </summary>
    public string ErrorDescription { get; set; }

    /// <summary>
    ///  The per-request identifier. This can be used to display to the end user and can
    ///  be used in diagnostics.
    /// </summary>
    public string RequestId { get; set; }

    /// <summary>
    /// The redirect URI.
    /// </summary>
    public string RedirectUri { get; set; }
    /// <summary>
    /// The response mode.
    /// </summary>
    public string ResponseMode { get; set; }

  }
}