using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace MotionRec.NancyApp
{
    class ConsoleConnectToHost
    {
        public NancyHost _host { get; set; }

        public ConsoleConnectToHost()
        {
            var config = new HostConfiguration();
            config.UrlReservations.CreateAutomatically = true;
            
            _host = new NancyHost(config, new Uri("http://localhost:8500"));
           
        }

        public void StartNancy()
        {
            _host.Start();

            Console.Title = "Nancy App";
            Console.WriteLine("http://localhost:8500");
            //Console.WriteLine("start http://localhost:8500");
            Console.ReadLine();
            
        }

        public void StopNancy()
        {
            _host.Stop();
        }

        

    }
}
