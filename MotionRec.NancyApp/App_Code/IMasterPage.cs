using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionRec.NancyApp.App_Code
{
    public interface IMasterPage
    {
        string Title { get; set; }
        string CurrentDate { get; }
    }
}
