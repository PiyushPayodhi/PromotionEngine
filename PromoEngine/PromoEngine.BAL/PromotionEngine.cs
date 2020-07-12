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
        public PromotionEngine()
        {
            FillSKUList();
            FillPromoList();
        }
        public void FillSKUList()
        {
            try
            {
                //Populate all the SKU items
                SKUList = new List<SKU>();
                SKUList.Add(new SKU() { SKUId = 'A', SKUPrice = 50m });
                SKUList.Add(new SKU() { SKUId = 'B', SKUPrice = 30m });
                SKUList.Add(new SKU() { SKUId = 'C', SKUPrice = 20m });
                SKUList.Add(new SKU() { SKUId = 'D', SKUPrice = 15m });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void FillPromoList()
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public (decimal actualPrice, decimal promoPrice) PromoCalculator()
        {
            decimal actualPrice = 0m, promoPrice = 0m, sku1Price = 0m, sku2Price = 0m;
            bool promoApplied = false;
            try
            {
                foreach (var cartItem in CartList.FindAll(c => !c.IsCheckedOut))
                {
                    promoApplied = false;
                    sku1Price = SKUList.Find(sku => sku.SKUId == cartItem.SKU).SKUPrice;
                    actualPrice += sku1Price * cartItem.Quantity;
                    
                    //If item is already checkedout, pick next.
                    if (cartItem.IsCheckedOut)
                    {
                        continue;
                    }
                    
                    foreach (var promotion in PromoList)
                    {
                        //For promotions with single SKU item
                        if (promotion.SKU2.Equals('\0'))
                        {
                            if (promotion.SKU1 == cartItem.SKU && promotion.SKU1Unit <= cartItem.Quantity)
                            {
                                //Items with promo
                                promoPrice += promotion.PromoPrice * (cartItem.Quantity / promotion.SKU1Unit);

                                //Items without promo
                                promoPrice += (cartItem.Quantity % promotion.SKU1Unit) * sku1Price;

                                promoApplied = true;

                                //Check out items
                                cartItem.IsCheckedOut = true;
                                break;
                            }
                        }
                        //For promotions with multiple SKU items
                        else
                        {
                            if (promotion.SKU1 == cartItem.SKU && promotion.SKU1Unit <= cartItem.Quantity)
                            {
                                foreach (var cartItem2 in CartList.FindAll(c => !c.IsCheckedOut))
                                {
                                    if (promotion.SKU2 == cartItem2.SKU && promotion.SKU2Unit <= cartItem2.Quantity)
                                    {
                                        sku2Price = SKUList.Find(sku => sku.SKUId == cartItem2.SKU).SKUPrice;

                                        //Number of times a given promotion needs to be applied.
                                        var totalPromo = Math.Min((cartItem.Quantity / promotion.SKU1Unit), (cartItem2.Quantity / promotion.SKU2Unit));

                                        //SKU1 and SKU2 items wit promo
                                        promoPrice += promotion.PromoPrice * totalPromo;

                                        //SKU1 items without promo
                                        promoPrice += (cartItem.Quantity % promotion.SKU1Unit) * sku1Price;

                                        //SKU2 items without promo
                                        promoPrice += (cartItem2.Quantity % promotion.SKU2Unit) * sku2Price;

                                        promoApplied = true;

                                        //Check out items
                                        cartItem.IsCheckedOut = true;
                                        CartList.Find(c => c.SKU == cartItem2.SKU).IsCheckedOut = true;
                                        cartItem2.IsCheckedOut = true;

                                        break;
                                    }
                                }
                            }
                        }
                    }

                    //When no promotion is applied, calculate actual price
                    if (!promoApplied)
                    {
                        promoPrice += (cartItem.Quantity) * sku1Price;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return (actualPrice, promoPrice);
        }
    }

    public class CartItem
    {
        public char SKU { get; set; }
        public int Quantity { get; set; }
        public bool IsCheckedOut { get; set; }
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