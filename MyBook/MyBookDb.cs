using System.IO;

namespace MyBook
{
    partial class Program
    {
        class MyBookDb
        {
            string dbName, path;
            public MyBookDb() : this("mybook") { }
            public MyBookDb(string dbName)
            {
                this.dbName = dbName;
                if (!Directory.Exists(this.dbName))
                    Directory.CreateDirectory(this.dbName);
                this.path = Path.Combine(this.dbName, "myusers.mydb");
                if (!File.Exists(this.path))
                    CreateUser("myadmin", UserRoles.Admin, "password");
            }

            public User CreateUser(string userName, UserRoles userRole, string password)
            {
                File.AppendAllText(this.path, $"{userName}#{(int)userRole}#{password}\n");
                return  new User(userRole, userName, Path.Combine(this.dbName, userName));
            }
            public bool IsUserValid(User user, string password)
            {
                return IsUserValid(user.UserName, user.UserRole, password);
            }
            public bool IsUserValid(string userName, UserRoles userRole, string password)
            {
                string[] adatok = File.ReadAllLines(this.path);
                for (int i = 0; i < adatok.Length; i++)
                    if (adatok[i] == $"{userName}#{(int)userRole}#{password}\n")
                        return true;
                return false;
            }
            public User LoadUser(string userName, UserRoles userRole, string password)
            {
                if (IsUserValid(userName, userRole, password))
                    return new User( userRole, userName, Path.Combine(dbName, userName));
                return new User(UserRoles.Visitor, userName, Path.Combine(dbName, userName));
            }
        }
    }
}
