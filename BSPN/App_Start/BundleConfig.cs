using System.Web;
using System.Web.Optimization;

namespace BSPN
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/Angular/angular.js",
                        "~/Scripts/Angular/angular-route.js",
                        "~/Scripts/Angular/angular-resource.js"));

            const string ANGULAR_APP_ROOT = "~/Scripts/BSPNApp/";

            bundles.Add(new ScriptBundle("~/bundles/application")
                .Include(ANGULAR_APP_ROOT + "BSPNApp.js")
                .IncludeDirectory(ANGULAR_APP_ROOT, "*.js", true));

            //bundles.Add(new ScriptBundle("~/bundles/application").Include(
            //        "~/Scripts/BSPNApp/BSPNApp.js",
            //        "~/Scripts/BSPNApp/Services/DriverData.js",
            //        "~/Scripts/BSPNApp/Services/RaceData.js",
            //        "~/Scripts/BSPNApp/Controllers/DriversController.js",
            //        "~/Scripts/BSPNApp/Controllers/RacesController.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/JQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/JQuery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
