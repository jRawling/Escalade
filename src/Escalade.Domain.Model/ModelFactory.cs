using Dto = Escalade.Persistence.Model;

namespace Escalade.Domain.Model
{
    public static class ModelFactory
    {
        public static User CreateUser(Dto.User user)
        {
            if (user == null)
            {
                return null;
            }

            return new User(user);
        }
    }
}