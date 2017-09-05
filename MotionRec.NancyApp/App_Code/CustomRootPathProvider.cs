using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace MotionRec.NancyApp.App_Code
{
    class CustomRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            string rootPath = System.Configuration.ConfigurationSettings.AppSettings["rootPath"].ToString();

            return rootPath;// @"C:\Working\MotionRec.NancyApp\MotionRec.NancyApp\";
        }
       
    }
}
