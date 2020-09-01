using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Flunt.Notifications;

namespace FaleMaisServices.Exceptions {
  [ExcludeFromCodeCoverage]
  public class FaleMaisException : Exception {
    public int StatusCode { get; }

    public FaleMaisException(string message) : base(message) {}

    public FaleMaisException(string message, int statusCode) : base(message) {
      StatusCode = statusCode;
    }
  }
}
