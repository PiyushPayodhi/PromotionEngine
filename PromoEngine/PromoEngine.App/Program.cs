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
            PromotionEngine promotionEngine = new PromotionEngine();
            Console.WriteLine($"Promo Price:{promotionEngine.PromoCalculator()}");
            Console.ReadLine();
        }
    }
}
