using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckBoxListDemo.Web.Models
{
    public class CheckBoxListItem
    {
        public int ID { get; set; }
        public string Display { get; set; }
        public bool IsChecked { get; set; }
    }
}