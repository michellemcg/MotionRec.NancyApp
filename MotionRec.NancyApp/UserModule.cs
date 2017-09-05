using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionRec.NancyApp.Models;

namespace MotionRec.NancyApp.Module

{
    using MotionRec.NancyApp.App_Code;
    using Nancy;
    using Nancy.ModelBinding;

    public class UserModule : NancyModule
    {
        private IUser _user;
        public IMasterPage _masterPage;

        public UserModule(IUser userImplementation, IMasterPage masterPageImplementation) : base("/user")
        {
            _user = userImplementation;
            _masterPage = masterPageImplementation;
            _masterPage.Title = "Not Set";          

            Get["/"] = parameters => "Invalid Path";
           
            Get["/list"] = _ => ListUsers();

            Get["/{id:int}"] = parameters => GetUser(parameters);

            Get["/delete/{id:int}", runAsync: true] = async (x, ct) => await RemoveUser(x);

            Get["/add"] = parameters => DisplayAddUser(parameters);

            Post["/add", runAsync: true] = async(x, ct) => await AddUser(x);

        }

        private dynamic GetUser(dynamic parameters)
        {
            UserFactory uf = new UserFactory();
            var user = uf.getUser(parameters.Id);

            return View["Users", user];
        }

        private dynamic ListUsers()
        {
            UserFactory uf = new UserFactory();
            var users = uf.getAllUsers();

            return View["Users", users];
        }
        private dynamic DisplayAddUser(dynamic parameters)
        {
            Utils utils = new Utils(new User());
            return View["AddUser",utils];
        }
        private async Task<dynamic> AddUser(dynamic parameters)
        {            
            var newUser = this.Bind<User>();
            Utils utils = new Utils(newUser);
           
            if (!(newUser.FirstName != null && newUser.FirstName.Length > 0)){
                utils.CommandSucceeded = false;
                utils.AddMessage("FirstName is a required field.<br />");
            }
            if (!(newUser.LastName != null && newUser.LastName.Length > 0)){
                utils.CommandSucceeded = false;
                utils.AddMessage("LastName is a required field.<br />");
            }
            if (!(newUser.Email != null && newUser.Email.Length > 0))
            {
                utils.CommandSucceeded = false;
                utils.AddMessage("Email is a required field.<br />");
            }
            else if (!(utils.emailIsValid(newUser.Email)))
            {
                utils.CommandSucceeded = false;
                utils.AddMessage("Email is not a valid format.<br />");
            }

            if (utils.CommandSucceeded)
            {
                UserFactory uf = new UserFactory();

                dynamic x = await uf.AddUser(newUser);

                return ListUsers();
            }
            else
            {
                utils.User = newUser;
                return View["AddUser", utils];
            }
        }
        private async Task<dynamic> RemoveUser(dynamic parameters)
        {
            UserFactory uf = new UserFactory();
            int? Id = parameters.Id;

            if (Id != null && Id > 0)
            {
                if (uf.userExists((int)Id))
                {
                    dynamic x = await uf.RemoveUser((int)Id);
                }
                else
                {
                    return "User does not appear to exist";
                }
            }
            else
                return "User does not appear to exist";

            return ListUsers();
        }
    }
    public class JSONModule : NancyModule
    {
        public JSONModule()
        {
            Get["/time"] = _ =>
            {
                var response = new { Date = DateTime.UtcNow.ToString("o") };
                return Response.AsJson<object>(response);              
            };
            Get["/system"] = _ =>
            {
                var systemInfo = new { MachineNam= Environment.MachineName, Processors= Environment.ProcessorCount, OSVersion = Environment.OSVersion  };
                
                return Response.AsJson<object>(systemInfo);
            };
        }
    }
}
