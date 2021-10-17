using AtomicDesignDemo.Features.Product.Models;
using AtomicDesignDemo.Features.Promotion.Models;
using AtomicDesignDemo.Models;
using EPiServer.Cms.TinyMce.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace AtomicDesignDemo.Infrastructure
{
    [ModuleDependency(typeof(TinyMceInitialization))]
    public class ExtendedTinyMceInitialization
        : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                config.For<BasePageData>(t => t.Description)
                    .AddPlugin("code")
                    .Toolbar("formatselect styleselect | bold italic | epi-link image epi-image-editor epi-personalized-content | bullist numlist outdent indent | code");

                config.For<ProductPage>(t => t.ProductDescription)
                    .AddPlugin("code")
                    .Toolbar("formatselect styleselect | bold italic | epi-link image epi-image-editor epi-personalized-content | bullist numlist outdent indent | code");

                config.For<PromotionBlock>(t => t.Description)
                    .AddPlugin("code")
                    .Toolbar("formatselect styleselect | bold italic | epi-link image epi-image-editor epi-personalized-content | bullist numlist outdent indent | code");
            });
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
