﻿using System.Web;
using System.Web.Optimization;

namespace MyApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/scripts/app/app.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/jquery-3.3.1.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/respond.js",
                "~/scripts/datatables/jquery.datatables.js",
                "~/scripts/datatables/datatables.bootstrap4.js",
                "~/scripts/toastr.js",
                "~/Scripts/jquery.validate.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/content/datatables/css/datatables.bootstrap4.css",
                "~/Content/site.css",
                "~/content/toastr.css",
                "~/Content/modern-business.css"
            ));
        }
    }

}
