using System;
using System.IO;

namespace MyBook
{
    partial class Program
    {
        enum UserRoles { Visitor, User, Admin }
        
        class User
        {
            public UserRoles UserRole { get; set; }
            public string UserName { get; set; }
            public string UserFolder { get; set; }

            public User(UserRoles userRole, string userName) : this(userRole, userName, string.Empty) { }
            public User(UserRoles userRole, string userName, string userFolder)
            {
                UserRole = userRole;
                UserName = userName;
                UserFolder = userFolder;
                if (!Directory.Exists(userFolder) && !string.IsNullOrWhiteSpace(userFolder))
                    Directory.CreateDirectory(userFolder);
            }

            public void Post(string message)
            {
                if (UserRole == UserRoles.Admin || UserRole == UserRoles.User)
                    File.AppendAllText(Path.Combine(UserFolder, DateTime.Now.ToString("yyyy-MM-dd")), $"[{UserRole.ToString().ToUpper()}][{DateTime.Now}] {message}\n");
            }
        }
    }
}
