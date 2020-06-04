using System;
using System.Collections.Generic;
using System.Text;

namespace TradeMeAPIAutomationFramework.Models
{
    public class Categories
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Path { get; set; }
        public List<Subcategory> Subcategories { get; set; }
        public bool HasClassifieds { get; set; }
        public int AreaOfBusiness { get; set; }
        public bool IsLeaf { get; set; }
    }
}
