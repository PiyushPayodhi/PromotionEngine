using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.BAL
{

    public class PromotionEngine
    {
        public List<SKU> SKUList { get; set; }
        public List<Promotion> PromoList { get; set; }
        public List<CartItem> CartList { get; set; }
        public void FillSKUList()
        {
            //Populate all the SKU items
        }
        public void FillPromoList()
        {
            //Populate all the Promotions
        }
        public decimal PromoCalculator()
        {
            decimal promoPrice = 0m;
            //Apply promotions on cart and determine promoPrice.
            return promoPrice;
        }
    }

    public class CartItem
    {
        public char SKU { get; set; }
        public int Quantity { get; set; }
    }

    public class Promotion
    {
        public char SKU1 { get; set; }
        public int SKU1Unit { get; set; }
        public char SKU2 { get; set; }
        public int SKU2Unit { get; set; }
        public decimal PromoPrice { get; set; }
    }

    public class SKU
    {
        public char SKUId { get; set; }
        public decimal SKUPrice { get; set; }
    }
}