using System.IO;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Hosting;
using HandlebarsDotNet;

namespace AtomicDesignDemo.Infrastructure
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class HandlebarsInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var hostingEnvironment = ServiceLocator.Current
                .GetInstance<IHostingEnvironment>();
            var patternsDirectory = hostingEnvironment.MapPath("~/assets/patterns");
            var patternFiles = Directory.EnumerateFiles(
                patternsDirectory,
                "*.hbs",
                SearchOption.TopDirectoryOnly);

            foreach (var patternFile in patternFiles)
            {
                var patternPath = File.ReadAllText(patternFile);
                var patternName = Path.GetFileNameWithoutExtension(patternFile);
                Handlebars.RegisterTemplate(patternName, patternPath);
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}
