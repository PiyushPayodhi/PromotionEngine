using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoEngine.BAL;

namespace PromoEngine.App
{
    class Program
    {
        static void Main(string[] args)
        {
            PromotionEngine pc = new PromotionEngine();

            FillCartList1(pc);
            (decimal actualPrice, decimal promoPrice) = pc.PromoCalculator();
            Console.WriteLine($"Cart 3 \nActual Price:{actualPrice} Promo Price:{promoPrice}");

            pc.CartList = null;
            FillCartList2(pc);
            (actualPrice, promoPrice) = pc.PromoCalculator();
            Console.WriteLine($"Cart 3 \nActual Price:{actualPrice} Promo Price:{promoPrice}");

            pc.CartList = null;
            FillCartList3(pc);
            (actualPrice, promoPrice) = pc.PromoCalculator();
            Console.WriteLine($"Cart 3 \nActual Price:{actualPrice} Promo Price:{promoPrice}");
            Console.ReadLine();
        }

        static public void FillCartList1(PromotionEngine pc)
        {
            pc.CartList = new List<CartItem>();
            pc.CartList.Add(new CartItem() { SKU = 'A', Quantity = 1 });
            pc.CartList.Add(new CartItem() { SKU = 'B', Quantity = 1 });
            pc.CartList.Add(new CartItem() { SKU = 'C', Quantity = 1 });
        }
        static public void FillCartList2(PromotionEngine pc)
        {
            pc.CartList = new List<CartItem>();
            pc.CartList.Add(new CartItem() { SKU = 'A', Quantity = 5 });
            pc.CartList.Add(new CartItem() { SKU = 'B', Quantity = 5 });
            pc.CartList.Add(new CartItem() { SKU = 'C', Quantity = 1 });
        }
        static public void FillCartList3(PromotionEngine pc)
        {
            pc.CartList = new List<CartItem>();
            pc.CartList.Add(new CartItem() { SKU = 'A', Quantity = 3 });
            pc.CartList.Add(new CartItem() { SKU = 'B', Quantity = 5 });
            pc.CartList.Add(new CartItem() { SKU = 'C', Quantity = 1 });
            pc.CartList.Add(new CartItem() { SKU = 'D', Quantity = 1 });
        }
    }
}
