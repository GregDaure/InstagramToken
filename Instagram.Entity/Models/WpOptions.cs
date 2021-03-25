using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Instagram.Entity.Models
{
    public partial class WpOptions
    {
        public long OptionId { get; set; }
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
        public string Autoload { get; set; }
    }
}
