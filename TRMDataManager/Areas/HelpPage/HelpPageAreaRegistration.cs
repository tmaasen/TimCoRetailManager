using System.Web.Http;
using System.Web.Mvc;

namespace TRMDataManager.Areas.HelpPage
{
    public class HelpPageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_Default",
                "Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            // This line broke due to an assembly dependency version issue when I first started the program. I had to go into Web.Config and change the newVersion of the runtime dependencyAssembly. I found the version number I needed by going into the dll of the breaking dependency, clicking on it's properties and finding the Assembly Version. This number is different from the version you see when you upgrade the NuGet package, so BE MINDFUL of this!
            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}