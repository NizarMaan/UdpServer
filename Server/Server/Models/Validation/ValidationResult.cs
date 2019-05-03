using System;

namespace Server.Models.Validation
{
    /// <summary>
    /// Represents the result from a call to a <see cref="Services.Validation"/> service method.
    /// </summary>
    public class ValidationResult
    {
        public ValidationResult()
        {
            IsValid = true;
            Exception = null;
        }

        public ValidationResult(bool isValid, Exception exception)
        {
            IsValid = isValid;
            Exception = exception;
        }

        public bool IsValid { get; set; }
        public Exception Exception { get; set; }
    }
}
