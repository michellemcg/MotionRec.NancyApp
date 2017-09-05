using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MotionRec.NancyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ConsoleConnectToHost>(cch =>
                {
                    cch.ConstructUsing(() => new ConsoleConnectToHost());

                    cch.WhenStarted(s => s.StartNancy());

                    cch.WhenStopped(s => s.StopNancy());
                });

            });
        }
    }
}
