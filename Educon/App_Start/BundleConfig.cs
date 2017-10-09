using System.Web;
using System.Web.Optimization;

namespace Educon
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        public static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/site").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/material.min.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/suite.js",
                "~/Scripts/dialog-polyfill.js"
            ));

            bundles.Add(new ScriptBundle("~/js/signalR").Include(
                "~/Scripts/jquery.signalR-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/js/friends").Include(
                "~/Scripts/friends.js"
            ));

            bundles.Add(new ScriptBundle("~/js/modernizr").Include(
                "~/Scripts/modernizr-*"
            ));
        }

        public static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/site").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Content/login.css",
                "~/Content/cadastro.css",
                "~/Content/portal.css",
                "~/Content/material.min.css",
                "~/Content/material.icons.css",
                "~/Content/dialog-polyfill.css"
            ));
        }
    }
}
