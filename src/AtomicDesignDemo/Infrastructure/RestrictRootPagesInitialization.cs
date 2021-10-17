using AtomicDesignDemo.Features.Home.Models;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Initialization;

namespace AtomicDesignDemo.Infrastructure
{
    [InitializableModule]
    [ModuleDependency(typeof(CmsCoreInitialization))]
    public class RestrictRootPagesInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var contentTypeRepository = context.Locate.Advanced.GetInstance<IContentTypeRepository>();

            var sysRoot = contentTypeRepository.Load("SysRoot") as PageType;

            var setting = new AvailableSetting { Availability = Availability.Specific };
            setting.AllowedContentTypeNames.Add(contentTypeRepository.Load<HomePage>().Name);

            var availableSettingsRepository = context.Locate.Advanced.GetInstance<IAvailableSettingsRepository>();
            availableSettingsRepository.RegisterSetting(sysRoot, setting);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
