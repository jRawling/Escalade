using System.Collections.Generic;
using System.Linq;

namespace Escalade.Application.UserSession.Dto
{
    /// <summary>
    /// Represents the result of a create user operation
    /// </summary>
    public class RegistrationResult
    {
        private static readonly RegistrationResult success = new RegistrationResult { Succeeded = true };
        private List<UserCreationError> errors = new List<UserCreationError>();

        /// <summary>
        ///  True if the operation was successful
        /// </summary>
        public bool Succeeded { get; protected set; }

        /// <summary>
        ///  List of errors
        /// </summary>
        public IEnumerable<UserCreationError> Errors => errors;

        /// <summary>
        ///  Static success result
        /// </summary>
        /// <returns></returns>
        public static RegistrationResult Success => success;

        /// <summary>
        ///  Failed helper method
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static RegistrationResult Failed(params UserCreationError[] errors)
        {
            var result = new RegistrationResult { Succeeded = false };
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