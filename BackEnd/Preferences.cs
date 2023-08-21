using System;

namespace HeatMaps
{
    public static class Preferences
    {
        //import database context containing route settings
        public const string Route1 = "/index";
        public const string Route2 = "/update";
        public const string Route3 = "/delete";
        public const string Route4 = "/add";
        public const string Route5 = "/get";
        public const string Route6 = "salesondate/{date}";
        public const string Route7 = "bysaleid/{saleId}";
        public const string Route8 = "/delete";
        public const int PageSize = 15;
    }
}
