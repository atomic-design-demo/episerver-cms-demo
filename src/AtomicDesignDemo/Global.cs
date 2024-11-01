﻿using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace AtomicDesignDemo
{
    public class Global
    {
        [GroupDefinitions]
        public static class GroupNames
        {
            [Display(Name = "Contact", Order = 1)]
            public const string Contact = "Contact";

            [Display(Name = "Default", Order = 2)]
            public const string Default = "Default";

            [Display(Name = "Metadata", Order = 3)]
            public const string MetaData = "Metadata";

            [Display(Name = "News", Order = 4)]
            public const string News = "News";

            [Display(Name = "Products", Order = 5)]
            public const string Products = "Products";

            [Display(Name = "SiteSettings", Order = 6)]
            public const string SiteSettings = "SiteSettings";

            [Display(Name = "Specialized", Order = 7)]
            public const string Specialized = "Specialized";
        }

        [GroupDefinitions]
        public static class TabNames
        {
            [Display(Name = "Header", Order = 10)]
            public const string Header = "Header";

            [Display(Name = "Footer", Order = 10)]
            public const string Footer = "Footer";
        }
    }
}
