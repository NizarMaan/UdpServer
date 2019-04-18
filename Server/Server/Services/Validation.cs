using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Services
{
    /// <summary>
    /// Provides various methods for validating data.
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Validates that the given input Json matches the specified POCO representation.
        /// </summary>
        /// <param name="inputJson"></param>
        /// <param name="objectType"></param>
        /// <param name="allowAdditionalProperties"></param>
        /// <returns></returns>
        public static async Task<> ValidateJsonAsync(dynamic inputJson, Type objectType, bool allowAdditionalProperties)
        {
            JsonSchema4 jsonSchema = await JsonSchema4.FromTypeAsync(objectType);
            jsonSchema.AllowAdditionalProperties = allowAdditionalProperties;

            ICollection<NJsonSchema.Validation.ValidationError> errors = jsonSchema.Validate(inputJson);

            if (errors.Count == 0)
            {
                return new BaseResponse(System.Net.HttpStatusCode.OK);
            }
            else
            {
                string[] jsonErrors = new string[errors.Count];
                for (int i = 0; i < jsonErrors.Length; i++)
                {

                    jsonErrors[i] = (errors.ElementAt(i).ToString());

                }

                return new BaseResponse(System.Net.HttpStatusCode.BadRequest, errorScope: objectType.Name, errorType: "invalid json", errorMessages: jsonErrors);
            }
        }
    }
}
