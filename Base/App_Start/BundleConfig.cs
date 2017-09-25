using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Base.App_Start
{
    public class BundleConfig
    {
        public static void RefisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/node_modules/@angular/material/prebuilt-themes/deeppurple-amber.css"));
        }
    }
}