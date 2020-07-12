using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromoEngine.BAL;
using Xunit;

namespace PromoEngine.Test
{
    public class PromoEngineTest
    {
        public PromoEngineTest()
        {

        }
        
        [Fact]
        public void TestCaseCart1()
        {
            //A = 1, B = 1, C = 1
            PromotionEngine promotionEngine = new PromotionEngine();
            FillCartList1(promotionEngine);
            decimal expectedPrice = 100m;

            decimal promoPrice = promotionEngine.PromoCalculator();

            Assert.Equals(expectedPrice, promoPrice);
        }
        [Fact]
        public void TestCaseCart2()
        {
            //A = 5, B = 5, C = 1
            PromotionEngine promotionEngine = new PromotionEngine();
            FillCartList2(promotionEngine); 
            decimal expectedPrice = 370m;

            decimal promoPrice = promotionEngine.PromoCalculator();

            Assert.Equals(expectedPrice, promoPrice);
        }
        [Fact]
        public void TestCaseCart3()
        {
            //A = 3, B = 5, C = 1, D = 1
            PromotionEngine promotionEngine = new PromotionEngine();
            FillCartList3(promotionEngine);
            decimal expectedPrice = 280m;

            decimal promoPrice = promotionEngine.PromoCalculator();

            Assert.Equals(expectedPrice, promoPrice);
        }
        public void FillCartList1(PromotionEngine promotionEngine)
        {
            promotionEngine.CartList = new List<CartItem>();
            promotionEngine.CartList.Add(new CartItem() { SKU = 'A', Quantity = 1 });
            promotionEngine.CartList.Add(new CartItem() { SKU = 'B', Quantity = 1 });
            promotionEngine.CartList.Add(new CartItem() { SKU = 'C', Quantity = 1 });
        }
        public void FillCartList2(PromotionEngine promotionEngine)
        {
            promotionEngine.CartList = new List<CartItem>();
            promotionEngine.CartList.Add(new CartItem() { SKU = 'A', Quantity = 5 });
            promotionEngine.CartList.Add(new CartItem() { SKU = 'B', Quantity = 5 });
            promotionEngine.CartList.Add(new CartItem() { SKU = 'C', Quantity = 1 });
        }
        public void FillCartList3(PromotionEngine promotionEngine)
        {
            promotionEngine.CartList = new List<CartItem>();
            promotionEngine.CartList.Add(new CartItem() { SKU = 'A', Quantity = 3 });
            promotionEngine.CartList.Add(new CartItem() { SKU = 'B', Quantity = 5 });
            promotionEngine.CartList.Add(new CartItem() { SKU = 'C', Quantity = 1 });
            promotionEngine.CartList.Add(new CartItem() { SKU = 'D', Quantity = 1 });
        }
    }
}
