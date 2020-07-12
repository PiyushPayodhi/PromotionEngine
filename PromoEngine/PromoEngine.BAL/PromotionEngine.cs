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
            SKUList = new List<SKU>();
            SKUList.Add(new SKU() { SKUId = 'A', SKUPrice = 50m });
            SKUList.Add(new SKU() { SKUId = 'B', SKUPrice = 30m });
            SKUList.Add(new SKU() { SKUId = 'C', SKUPrice = 20m });
            SKUList.Add(new SKU() { SKUId = 'D', SKUPrice = 15m });
        }
        public void FillPromoList()
        {
            //Populate all the Promotions
            PromoList = new List<Promotion>();
            PromoList.Add(new Promotion()
            {
                SKU1 = 'A',
                SKU1Unit = 3,
                PromoPrice = 130
            });
            PromoList.Add(new Promotion()
            {
                SKU1 = 'B',
                SKU1Unit = 2,
                PromoPrice = 45
            });
            PromoList.Add(new Promotion()
            {
                SKU1 = 'C',
                SKU1Unit = 1,
                SKU2 = 'D',
                SKU2Unit = 1,
                PromoPrice = 30
            });
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