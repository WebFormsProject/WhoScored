using Bytes2you.Validation;
using System;
using System.Web;

namespace WhoScored.MVP.Models.CustomEvents
{
    public class RegisterEventArgs : EventArgs
    {
        public RegisterEventArgs(HttpContext httpContext, string username, string password, string email, string firstName, string lastName)
        {
            Guard.WhenArgument(httpContext, "httpContext").IsNull().Throw();
            Guard.WhenArgument(username, "username").IsNull().Throw();
            Guard.WhenArgument(password, "password").IsNull().Throw();
            Guard.WhenArgument(email, "email").IsNull().Throw();
            Guard.WhenArgument(firstName, "firstName").IsNull().Throw();
            Guard.WhenArgument(lastName, "lastName").IsNull().Throw();

            this.HttpContext = httpContext;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public HttpContext HttpContext { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
