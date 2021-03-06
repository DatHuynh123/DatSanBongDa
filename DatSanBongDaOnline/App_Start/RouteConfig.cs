﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DatSanBongDaOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
       name: "Seach",
       url: "tim-kiem",
       defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
       namespaces: new[] { "DatSanBongDaOnline.Controllers" }
   );
            //         routes.MapRoute(
            // name: "Login",
            // url: "dang-nhap",
            // defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional },
            // namespaces: new[] { "DatSanBongDaOnline.Controllers" }
            //  );

            //         routes.MapRoute(
            //    name: "Register",
            //    url: "dang-ky",
            //    defaults: new { controller = "Home", action = "Register", id = UrlParameter.Optional },
            //    namespaces: new[] { "OnlineShop.Controllers" }
            //);
            routes.MapRoute(
        name: "Contact",
        url: "lien-he",
        defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
        namespaces: new[] { "DatSanBongDaOnline.Controllers" }
        );

            routes.MapRoute(
name: "Payment",
url: "thanh-toan",
defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
namespaces: new[] { "DatSanBongDaOnline.Controllers" }
);
            routes.MapRoute(
name: "Add Cart ",
url: "them-gio-hang",
defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
namespaces: new[] { "DatSanBongDaOnline.Controllers" }

);

            routes.MapRoute(
    name: "Cart",
    url: "gio-hang",
    defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
    namespaces: new[] { "DatSanBongDaOnline.Controllers" }
);


            routes.MapRoute(
         name: "Product Detail",
         url: "chi-tiet/{metatitle}-{id}",
         defaults: new { controller = "Product", action = "XemChiTiet", id = UrlParameter.Optional },
         namespaces: new[] { "DatSanBongDaOnline.Controllers" }
     );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "DatSanBongDaOnline.Controllers" }
            );





           
        }
    }
}
