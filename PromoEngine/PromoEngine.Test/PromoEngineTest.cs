using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromoEngine.BAL;

namespace PromoEngine.Test
{
    [TestClass]
    public class PromoEngineTest
    {
        
        [TestMethod]
        public void TestCaseCart1()
        {
            //A = 1, B = 1, C = 1
            PromotionEngine promotionEngine = new PromotionEngine();
            FillCartList1(promotionEngine);
            decimal orginalPrice = 100m,expectedPrice = 100m;

            (decimal actualPrice, decimal promoPrice) = promotionEngine.PromoCalculator();

            Assert.AreEqual(orginalPrice, actualPrice);
            Assert.AreEqual(expectedPrice, promoPrice);
        }
        [TestMethod]
        public void TestCaseCart2()
        {
            //A = 5, B = 5, C = 1
            PromotionEngine promotionEngine = new PromotionEngine();
            FillCartList2(promotionEngine);
            decimal orginalPrice = 420m, expectedPrice = 370m;

            (decimal actualPrice, decimal promoPrice) = promotionEngine.PromoCalculator();

            Assert.AreEqual(orginalPrice, actualPrice);
            Assert.AreEqual(expectedPrice, promoPrice);
        }
        [TestMethod]
        public void TestCaseCart3()
        {
            //A = 3, B = 5, C = 1, D = 1
            PromotionEngine promotionEngine = new PromotionEngine();
            FillCartList3(promotionEngine);
            decimal orginalPrice = 335m, expectedPrice = 280m;

            (decimal actualPrice, decimal promoPrice) = promotionEngine.PromoCalculator();

            Assert.AreEqual(orginalPrice, actualPrice);
            Assert.AreEqual(expectedPrice, promoPrice);
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
