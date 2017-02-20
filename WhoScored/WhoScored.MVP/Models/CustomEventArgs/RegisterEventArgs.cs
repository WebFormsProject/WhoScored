using Bytes2you.Validation;
using System;
using System.Web;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class RegisterEventArgs : EventArgs
    {
        public RegisterEventArgs(
            HttpContext httpContext, 
            string username, 
            string password, 
            string email, 
            string firstName, 
            string lastName, 
            HttpPostedFileBase avatarFileBase = null, 
            string avatarFilePath = null, 
            string avatarStorageLocation = null)
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
            this.AvatarFileBase = avatarFileBase;
            this.AvatarFilePath = avatarFilePath;
            this.AvatarStorageLocation = avatarStorageLocation;
        }

        public HttpContext HttpContext { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public HttpPostedFileBase AvatarFileBase { get; set; }

        public string AvatarFilePath { get; set; }

        public string AvatarStorageLocation { get; set; }
    }
}
