using System.Collections.Generic;
using System.Linq;

namespace Escalade.Domain.Model.Validation
{
    /// <summary>
    /// Represents the result of a create user operation
    /// </summary>
    public class ValidationResult
    {
        private static readonly ValidationResult success = new ValidationResult { Succeeded = true };
        private List<ValidationError> errors = new List<ValidationError>();

        /// <summary>
        ///  True if the operation was successful
        /// </summary>
        public bool Succeeded { get; protected set; }

        /// <summary>
        ///  List of errors
        /// </summary>
        public IEnumerable<ValidationError> Errors => errors;

        /// <summary>
        ///  Static success result
        /// </summary>
        /// <returns></returns>
        public static ValidationResult Success => success;

        /// <summary>
        ///  Failed helper method
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static ValidationResult Failed(params ValidationError[] errors)
        {
            var result = new ValidationResult { Succeeded = false };
            if (errors != null)
            {
                result.errors.AddRange(errors);
            }
            return result;
        }

        /// <summary>
        ///  Return string representation of IdentityResult
        /// </summary>
        /// <returns>"Succedded", if result is suceeded else "Failed:error codes"</returns>
        public override string ToString()
        {
            return Succeeded ?
                   "Succeeded" :
                   string.Format("{0} : {1}", "Failed", string.Join(",", Errors.Select(x => x.Code).ToList()));
        }
    }
}