using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatSanBongDaOnline.Models
{
    [Serializable]
    public class CartItem
    {
        public San sans { get; set; }



        public int SoLuong { get; set; }
    }
}