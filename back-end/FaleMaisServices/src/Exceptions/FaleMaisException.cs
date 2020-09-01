using System;
using System.Diagnostics.CodeAnalysis;

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
