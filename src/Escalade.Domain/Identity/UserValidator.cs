using Escalade.Domain.Model;
using Escalade.Domain.Model.Validation;
using Escalade.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escalade.Domain.Identity
{
    /// <summary>
    /// Validates users before they are saved
    /// </summary>
    public class UserValidator
    {
        private readonly IUserRepository userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            if(userRepository == null) { throw new ArgumentNullException(nameof(userRepository)); }
            this.userRepository = userRepository;
            Describer =  new UserValidatorErrorDescriber();
        }

        public UserValidatorErrorDescriber Describer { get; private set; }

        /// <summary>
       ///  Validates a user before saving
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public virtual async Task<ValidationResult> ValidateAsync(User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            var errors = new List<ValidationError>();
            await ValidateUsername(user, errors);
            await ValidateEmail(user, errors);
            return errors.Count > 0 ? ValidationResult.Failed(errors.ToArray()) : ValidationResult.Success;
        }

        private async Task ValidateUsername(User user, ICollection<ValidationError> errors)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                errors.Add(Describer.InvalidUsername(user.Username));
            }
            else
            {
                var owner = await userRepository.FindByNameAsync(user.NormalisedUsername);
                if (owner != null)
                {
                    errors.Add(Describer.DuplicateUserName(user.Username));
                }
            }
        }

        private async Task ValidateEmail(User user, ICollection<ValidationError> errors)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                errors.Add(Describer.InvalidEmail(user.Email));
            }
            else
            {
                var owner = await userRepository.FindByEmailAsync(user.NormalisedEmail);
                if (owner != null)
                {
                    errors.Add(Describer.DuplicateEmail(user.Email));
                }
            }
        }
    }
}