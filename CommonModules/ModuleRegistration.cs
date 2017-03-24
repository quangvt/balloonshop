using System.Web;
//[assembly: PreApplicationStartMethod(typeof(CommonModules.ModuleRegistration),
//    "RegisterModule")]

namespace CommonModules
{
    public class ModuleRegistration
    {
        // The method must be public and static and cannot take any arguments
        public static void RegisterModule()
        {
            HttpApplication.RegisterModule(typeof(CommonModules.InfoModule));
        }
    }
}