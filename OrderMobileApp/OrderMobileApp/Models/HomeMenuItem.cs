using System;
using System.Collections.Generic;
using System.Text;

namespace OrderMobileApp.Models
{
    public enum MenuItemType
    {
        NewOrder,
        Chronology,
        LogIn
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
