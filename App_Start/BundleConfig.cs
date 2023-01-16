using System.Web;
using System.Web.Optimization;

namespace AlphaTechMIS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Omer Salim Bundling
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Layout Bundles:
            bundles.Add(new StyleBundle("~/Content/Layout/css").Include(
                      "~/Content/Falcon/vendors/overlayscrollbars/OverlayScrollbars.min.css"));

            bundles.Add(new StyleBundle("~/Content/LayoutLTR/css").Include(
                      "~/Content/Falcon/assets/css/theme.min.css",
                      "~/Content/Falcon/assets/css/user.min.css"));

            bundles.Add(new StyleBundle("~/Content/LayoutRTL/css").Include(
                      "~/Content/Falcon/assets/css/theme-rtl.min.css",
                      "~/Content/Falcon/assets/css/user-rtl.min.css"));

            bundles.Add(new ScriptBundle("~/Content/LayoutConfig/js").Include(
                      "~/Content/Falcon/assets/js/config.js",
                      "~/Content/Falcon/vendors/overlayscrollbars/OverlayScrollbars.min.js"));

            bundles.Add(new Bundle("~/Content/Layout/js").Include(
                      "~/Content/Falcon/vendors/popper/popper.min.js",
                      "~/Content/Falcon/vendors/bootstrap/bootstrap.min.js",
                      "~/Content/Falcon/vendors/anchorjs/anchor.min.js",
                      "~/Content/Falcon/vendors/is/is.min.js",
                      "~/Content/Falcon/vendors/fontawesome/all.min.js",
                      "~/Content/Falcon/vendors/lodash/lodash.min.js",
                      "~/Content/Falcon/assets/js/theme.js",
                      "~/Content/Falcon/assets/js/user.js",
                      "~/Scripts/JScript.js"
                      ));

            //jQuery
            bundles.Add(new Bundle("~/Scripts/jquery3").Include(
                      "~/Scripts/jQuery/jquery-3.6.0.js",
                      "~/Scripts/jQuery/jquery-3.6.0.min.js"));

            bundles.Add(new Bundle("~/Scripts/jquery2").Include(
                      "~/Scripts/jQuery/jquery-2.2.0.min.js"));

            //DataTable
            bundles.Add(new StyleBundle("~/Content/Layout/DataTable/css").Include(
                      "~/Content/Falcon/assets/lib/DataTables/css/dataTables.bootstrap4.min.css",
                      "~/Content/Falcon/assets/lib/DataTables/css/responsive.bootstrap4.css",
                      "~/Content/Falcon/assets/lib/DataTables/Buttons/datatables.min.css"));

            bundles.Add(new ScriptBundle("~/Content/Layout/DataTable/js").Include(
                      "~/Content/Falcon/assets/lib/DataTables/js/jquery.dataTables.min.js",
                      "~/Content/Falcon/assets/lib/DataTables/js/dataTables.bootstrap4.min.js",
                      "~/Content/Falcon/assets/lib/DataTables/js/dataTables.responsive.js",
                      "~/Content/Falcon/assets/lib/DataTables/js/responsive.bootstrap4.js",
                      "~/Content/Falcon/assets/lib/DataTables/Buttons/datatables.min.js"));

            //jqxBase
            bundles.Add(new StyleBundle("~/Content/jqxBase/css").Include(
                      "~/Content/jQWidgets/css/jqx.base.css"));

            bundles.Add(new ScriptBundle("~/Content/jqxBase/js").Include(
                      "~/Content/jQWidgets/js/jqxcore.js",
                      "~/Content/jQWidgets/js/jqxscrollbar.js",
                      "~/Content/jQWidgets/js/jqxbuttons.js",
                      "~/Content/jQWidgets/js/jqxmenu.js",
                      "~/Content/jQWidgets/js/jqxdata.js",
                      "~/Content/jQWidgets/js/jqxdropdownlist.js",
                      "~/Content/jQWidgets/js/jqxlistbox.js"));

            //jqxGrid
            bundles.Add(new ScriptBundle("~/Content/jqxGrid/js").Include(
                      "~/Content/jQWidgets/js/jqxgrid.js",
                      "~/Content/jQWidgets/js/jqxgrid.pager.js",
                      "~/Content/jQWidgets/js/jqxgrid.selection.js",
                      "~/Content/jQWidgets/js/jqxgrid.filter.js",
                      "~/Content/jQWidgets/js/jqxgrid.storage.js",
                      "~/Content/jQWidgets/js/jqxgrid.sort.js"));

            //jqxValidator
            bundles.Add(new ScriptBundle("~/Content/jqxValidator/js").Include(
                      "~/Content/jQWidgets/js/jqxvalidator.js"));

            //highchart
            bundles.Add(new ScriptBundle("~/Content/highchart/js").Include(
                      "~/Scripts/highchart/highcharts.js",
                      "~/Scripts/highchart/modules/export-data.js",
                      "~/Scripts/highchart/modules/exporting.js",
                      "~/Scripts/highchart/modules/accessibility.js"));

            //components: moment, select2, toastr
            bundles.Add(new StyleBundle("~/Content/components/css").Include(
                       "~/Content/select2/css/select2.min.css",
                       "~/Content/toast/toastr.min.css",
                       "~/Content/calendar/jquery.calendars.picker.css"));

            bundles.Add(new ScriptBundle("~/Content/components/js").Include(
                      "~/Content/moment/moment-2.2.1.js",
                      "~/Content/select2/js/select2.min.js",
                      "~/Content/toast/toastr.js",
                      "~/Content/calendar/jquery.calendars.js",
                      "~/Content/calendar/jquery.calendars.plus.js",
                      "~/Content/calendar/jquery.plugin.js",
                      "~/Content/calendar/jquery.calendars.picker.js",
                      "~/Content/calendar/jquery.calendars.persian.js"
                      ));

            bundles.Add(new ScriptBundle("~/Scripts/ajaxForm/js").Include(
                      "~/Scripts/jquery.form.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
