using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Serilog;

namespace MotionRec.NancyApp.App_Code
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new CustomRootPathProvider(); }
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.LiterateConsole()
            .WriteTo.RollingFile("log-{Date}.txt")
            .CreateLogger();
        }

    }
}
