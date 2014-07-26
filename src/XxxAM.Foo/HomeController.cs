// --------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="XxxAM.Foo">
//   Copyright (c) XxxAM.Foo. All rights reserverd.
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------

namespace XxxAM.Foo {

  /// <summary>The home controller.</summary>
  public class HomeController {

    /// <summary>The test.</summary>
    /// <param name="param1">The param 1.</param>
    /// <returns>The <see cref="string"/>.</returns>
    public string Test(object param1) {
      const string Message = 
          "<html><h1>Got it! You passed '{0}'</h1></html>";
      return string.Format(Message, param1);
    }
  }
}