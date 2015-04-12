using Escalade.Domain.Model.Validation;

namespace Escalade.Domain.Identity
{
    public class UserValidatorErrorDescriber
    {
        public static UserValidatorErrorDescriber Default = new UserValidatorErrorDescriber();

        public virtual ValidationError DefaultError()
        {
            return new ValidationError
            {
                Code = nameof(DefaultError),
                Description = "An unknown error has occured."
            };
        }
        public virtual ValidationError ConcurrencyFailure()
        {
            return new ValidationError
            {
                Code = nameof(ConcurrencyFailure),
                Description = "Optimistic concurrency failure, object has been modified."
            };
        }


        public virtual ValidationError InvalidToken()
        {
            return new ValidationError
            {
                Code = nameof(InvalidToken),
                Description = "Invalid token."
            };
        }

        public virtual ValidationError InvalidUsername(string username)
        {
            return new ValidationError
            {
                Code = nameof(InvalidToken),
                Description = string.Format("Username '{0} is invalid.", username)
            };
        }

        public virtual ValidationError InvalidEmail(string email)
        {
            return new ValidationError
            {
                Code = nameof(InvalidToken),
                Description = string.Format("Email '{0} is invalid.", email)
            };
        }

        public virtual ValidationError DuplicateUserName(string username)
        {
            return new ValidationError
            {
                Code = nameof(DuplicateUserName),
                Description = string.Format("Username '{0}' is already taken.", username)
            };
        }

        public virtual ValidationError DuplicateEmail(string email)
        {
            return new ValidationError
            {
                Code = nameof(DuplicateEmail),
                Description = string.Format("Email '{0}' is already taken.", email)
            };
        }
    }
}