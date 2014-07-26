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
  using System.Web;

  /// <summary>The mvc emule handler.</summary>
  public class MvcEmuleHandler : IHttpHandler {

    /// <summary>
    /// Ruft einen Wert ab, der angibt, ob eine weitere Anforderung die <see cref="T:System.Web.IHttpHandler"/>-Instanz verwenden kann.
    /// </summary>
    /// <returns>
    /// true, wenn die <see cref="T:System.Web.IHttpHandler"/>-Instanz wiederverwendet werden kann, andernfalls false.
    /// </returns>
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
      var fullName = String.Format("{0}.{1}Controller", 
          this.GetType().Namespace, 
          controller);
      var controllerType = Type.GetType(fullName, true, true);

    }
  }
}
