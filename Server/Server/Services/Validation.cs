using NJsonSchema;
using Server.Models.Exceptions;
using Server.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    /// <summary>
    /// Provides various methods for validating data.
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Validates that the given input Json matches the specified POCO representation.
        /// Returns a string array of errors.
        /// </summary>
        /// <param name="inputJson"></param>
        /// <param name="objectType"></param>
        /// <param name="allowAdditionalProperties"></param>
        /// <returns></returns>
        public static async Task<ValidationResult> ValidateMessageAsync(dynamic inputJson, Type objectType, bool allowAdditionalProperties)
        {
            ValidationResult validationResult = new ValidationResult(true, null);

            JsonSchema4 jsonSchema = await JsonSchema4.FromTypeAsync(objectType);
            jsonSchema.AllowAdditionalProperties = allowAdditionalProperties;

            ICollection<NJsonSchema.Validation.ValidationError> errors = jsonSchema.Validate(inputJson);

            if (errors.Count != 0)
            {
                string jsonErrors = string.Empty;

                for (int i = 0; i < errors.Count; i++)
                {
                    jsonErrors += $"{errors.ElementAt(i).ToString()} ";
                }

                validationResult = new ValidationResult(false, new InvalidMessageException(jsonErrors));
            }

            return validationResult;
        }
    }
}
