using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionRec.NancyApp.Models
{
    public interface IUser
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }

    }
}
