using System;

namespace Escalade.Domain.Model
{
    public class User
    {
        public User(string firstName, string lastName, string location)
        {
            FirstName = firstName;
            LastName = lastName;
            Location = location;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Location { get; private set; }
    }
}