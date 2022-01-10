using System.Web;
using System.Web.Optimization;

namespace PizzaSystem
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /******************************************************* JS *******************************************************/

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-3.3.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                "~/Scripts/popper.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                      "~/Scripts/adminlte.min.js",
                      "~/Scripts/Custom/Menu.js")
                      .Include("~/Scripts/Moment.js")
                      .Include("~/Scripts/bootstrap-datepicker.min.js")
                      .Include("~/Scripts/bootstrap-datetimepicker.js")
                      .Include("~/Scripts/select2.min.js")
                      .Include("~/Content/fileinput/fileinput.js")
                      .Include("~/Content/fileinput/theme.js")
                      .Include("~/Scripts/sweetalert.min.js")
                      );

            bundles.Add(new ScriptBundle("~/bundles/sweetAlert").Include(
                      "~/Scripts/sweetAlert.min.js"));

            /******************************************************* CSS *******************************************************/

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/AdminLTE.min.css",
                      "~/Content/style-site.css",
                      "~/Content/Custom/LaptopCustom.css",
                      "~/Content/_all-skins.min.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/select2.min.css",
                      "~/Content/select2-bootstrap4.min.css",
                      "~/Content/fileinput/fileinput.css",
                      "~/Content/fontawesome/css/all.min.css"));
        }
    }
}
