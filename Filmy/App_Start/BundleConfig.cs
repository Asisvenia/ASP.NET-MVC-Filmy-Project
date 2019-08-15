using System.Web;
using System.Web.Optimization;

namespace Filmy
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery-unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/scripts/datatables/jquery.datatables.js",
                        "~/scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/Filmy.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                    "~/Content/themes/base/core.css",
                    "~/Content/themes/base/jquery-ui.css",
                    "~/Content/themes/base/jquery-ui.min.css",
                    "~/Content/themes/base/menu.css",
                    "~/Content/themes/base/resizable.css",
                    "~/Content/themes/base/selectable.css",
                    "~/Content/themes/base/accordion.css",
                    "~/Content/themes/base/autocomplete.css",
                    "~/Content/themes/base/button.css",
                    "~/Content/themes/base/dialog.css",
                    "~/Content/themes/base/slider.css",
                    "~/Content/themes/base/tabs.css",
                    "~/Content/themes/base/datepicker.css",
                    "~/Content/themes/base/progressbar.css",
                    "~/Content/themes/base/theme.css"));
        }
    }
}
