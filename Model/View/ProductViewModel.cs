using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.View
{
    public class ProductViewModel
    {
        public string ProductID { get; set; }
        public string Images { set; get; }
        public string ProductName { set; get; }
        public decimal? Price { set; get; }
        public string MetaTitle { set; get; }

    }
}