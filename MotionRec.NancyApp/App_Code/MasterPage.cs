using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionRec.NancyApp.App_Code
{
    public class MasterPage : IMasterPage
    {
        public string Title { get; set; }

        public string CurrentDate
        {
            get
            {
                return DateTime.Now.ToShortDateString();
            }
        }
    }
}
