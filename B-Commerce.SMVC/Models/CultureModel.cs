using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class CultureModel
    {
        public string CurrentLanguageName { get; set; }
        public string CurrentLanguageKey { get; set; }
        public Dictionary<string, string> Others { get; set; } = new Dictionary<string, string>();
    }
}