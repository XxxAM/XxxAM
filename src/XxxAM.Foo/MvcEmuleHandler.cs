// --------------------------------------------------------------------------
// <copyright file="MvcEmuleHandler.cs" company="XxxAM.Foo">
//   Copyright (c) XxxAM.Foo. All rights reserved.
// </copyright>
// <summary>
//   Defines the MvcEmuleHandler type.
// </summary>
// --------------------------------------------------------------------------

namespace XxxAM.Foo {
  using System;
  using System.Reflection;
  using System.Web;

  /// <summary>The mvc emule handler.</summary>
  public class MvcEmuleHandler : IHttpHandler {

    /// <summary>
    /// Gets a value indicating whether is reusable.
    /// </summary>
    public bool IsReusable {
      get { return true; }
    }

    /// <summary>The process request.</summary>
    /// <param name="context">The context.</param>
    public void ProcessRequest(HttpContext context) {
      // Logic goes here

      // Parse out the URL and extract controller, action, and paramter
      var segments = context.Request.Url.Segments;
      var controller = segments[1].TrimEnd('/');
      var action = segments[2].TrimEnd('/');
      var param1 = segments[3].TrimEnd('/');

      // Complete controller class name with suffic and (default) namespace
      var fullName = string.Format(
          "{0}.{1}Controller", 
          this.GetType().Namespace, 
          controller);
      var controllerType = Type.GetType(fullName, true, true);

      // Get an instance of the controller
      var instance = Activator.CreateInstance(controllerType);

      // Invoke the action method on the controller instance
      const BindingFlags Flags = BindingFlags.Instance | 
          BindingFlags.IgnoreCase | BindingFlags.Public;
      var methodInfo = controllerType.GetMethod(action, Flags);
      string result;
      if (methodInfo.GetParameters().Length == 0) {
        result = (string)methodInfo.Invoke(instance, null);
      } else {
        result = (string)methodInfo.Invoke(
            instance, 
            new object[] { param1 });
      }

      // Write out result.
      context.Response.Write(result);
    }
  }
}
