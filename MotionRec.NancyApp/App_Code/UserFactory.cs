using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionRec.NancyApp.Models;

namespace MotionRec.NancyApp.App_Code
{
    public class UserFactory
    {    
        public IUser userType { get; set;  }

        public List<IUser> getAllUsers()
        {
            DAL.NancyAppContext ctx = new DAL.NancyAppContext();
            List<IUser> users = (from u in ctx.User select u).ToList<IUser> ();

            return users;
        }

        public List<IUser> getUser(int Id)
        {
            DAL.NancyAppContext ctx = new DAL.NancyAppContext();
            List<IUser> users = (from u in ctx.User where u.Id == Id select u).ToList<IUser>();

            return users;
        }

        public bool userExists(int Id)
        {
            DAL.NancyAppContext ctx = new DAL.NancyAppContext();

            if ((from u in ctx.User where u.Id == Id select u).ToList<IUser>().Count > 0)
                return true;
            else
                return false;
        }
        

        public async Task<int> RemoveUser(int Id)
        {
            int rspns;
            using (var dbCntx = new NancyApp.DAL.NancyAppContext())
            {
                var user = new User { Id = Id };

                dbCntx.User.Attach(user);
                dbCntx.User.Remove(user);
                rspns = await dbCntx.SaveChangesAsync();
            }
            return rspns;
        }

        public async Task<int> AddUser(User newUser)
        {
            int rspns;

            using (var dbCntx = new NancyApp.DAL.NancyAppContext())
            {
                dbCntx.User.Add(newUser);
                rspns = await dbCntx.SaveChangesAsync();
            }
            return rspns;
        }

    }
}
