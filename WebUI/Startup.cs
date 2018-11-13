using Data;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using static Service.Startup;

[assembly: OwinStartupAttribute(typeof(WebUI.Startup))]
namespace WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // ConfigureAuth(app);

            OwinInit(app);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });



            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
            //AddUsersAndRoles();

        }

        private void AddUsersAndRoles()
        {

            PiContext context = new PiContext();
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!RoleManager.RoleExists("Doctor"))
            {
                var roleresult = RoleManager.Create(new IdentityRole("Doctor"));
            }

            if (!RoleManager.RoleExists("Patient"))
            {
                var roleresult = RoleManager.Create(new IdentityRole("Patient"));
            }


            if (!RoleManager.RoleExists("Admin"))
            {
                var roleresult = RoleManager.Create(new IdentityRole("Admin"));
            }

            var user = new User
            {
                UserName = "admin",
                Email = "admin@yahoo.com"
            };

            string pwd = "Administration1234$";
            var adminResult = UserManager.Create(user, pwd);
            if (adminResult.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Admin");
            }

        }

    }
}

