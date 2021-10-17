using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using EPiServer.ServiceLocation;
using EPiServer.Web.Hosting;
using HandlebarsDotNet;

namespace AtomicDesignDemo.Extensions
{
    public static class HtmlHelperExtensions
    {
        private static readonly Dictionary<string, HandlebarsTemplate<object, object>> Templates = new Dictionary<string, HandlebarsTemplate<object, object>>();

        public static MvcHtmlString RenderTemplate(this HtmlHelper helper, string templateName, object context)
        {
            if (!Templates.ContainsKey(templateName))
            {
                var hostingEnvironment = ServiceLocator.Current.GetInstance<IHostingEnvironment>();
                var patternFile = hostingEnvironment.MapPath($"~/assets/patterns/{templateName}.hbs");
                if (File.Exists(patternFile))
                {
                    var pattern = File.ReadAllText(patternFile);
                    var template = Handlebars.Compile(pattern);
                    Templates[templateName] = template;
                }
            }
            if (Templates.ContainsKey(templateName))
            {
                var template = Templates[templateName];
                var result = template(context);
                return MvcHtmlString.Create(result);
            }
            return MvcHtmlString.Empty;
        }
    }
}
