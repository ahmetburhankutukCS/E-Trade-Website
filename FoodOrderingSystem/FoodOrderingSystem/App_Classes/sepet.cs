using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace FoodOrderingSystem.App_Classes
{
    using Models;
    public class sepet
    {
        private static List<Food> urunler = new List<Food>();

        public List<Food> Urunler
        {
            get { return urunler;}
            set { urunler = value;}
        }

    }
}