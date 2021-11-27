using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBook
{
    partial class Program
    {
        static void Main(string[] args)
        {
            MyBookDb db = new MyBookDb();
            User sanyi = db.CreateUser("Sanyi", UserRoles.User, "asdfasdf");
            User dani = db.CreateUser("Dani", UserRoles.Visitor, "12345678");
            User timi = db.CreateUser("Timi", UserRoles.User, "qwertzuiop");

            sanyi.Post("Hahóó1");
            sanyi.Post("Hahóó2");
            sanyi.Post("Hahóó3");
            dani.Post("Hahóó1");
            dani.Post("Hahóó2");
            dani.Post("Hahóó3");
            timi.Post("Hahóó1");
            timi.Post("Hahóó2");
            timi.Post("Hahóó3");

            User admin = db.LoadUser("myadmin", UserRoles.Admin, "password");
            admin.Post("Hello, én vagyok az admin");

            db.LoadUser("Béla", UserRoles.Admin, "TutiJóJelszo");
        }
    }
}
