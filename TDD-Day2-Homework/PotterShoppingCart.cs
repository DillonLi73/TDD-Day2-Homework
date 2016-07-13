using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_Day2_Homework
{
    public class PotterShoppingCart
    {
        private List<PotterBook> _potterBooks;
        private Dictionary<int, decimal> _discounts = new Dictionary<int, decimal>()
        {
            { 1, 0 },
            { 2, 0.05m },
            { 3, 0.10m },
            { 4, 0.20m },
            { 5, 0.25m }
        };

        public int checkout()
        {
            int amount = 0;
            var skipBookNum = 0;
            var booksByVolume = this._potterBooks.GroupBy(x => x.Volume);
            
            while (true)
            {
                // 取得目前不同集數的最大值
                var differentBooksNum = 0;
                foreach (var booksOfVolume in booksByVolume)
                {
                    if (booksOfVolume.Skip(skipBookNum).Count() > 0)
                    {
                        differentBooksNum++;
                    }
                }

                if (differentBooksNum <= 0)
                {
                    // 沒有書了，離開迴圈
                    break;
                }
                else
                {
                    // 依據最大值取得對應折數、計算價格
                    decimal discount = this._discounts[differentBooksNum];
                    amount += (int)(differentBooksNum * 100 * (1 - discount));
                    skipBookNum++;
                }
            }

            return amount;
        }

        internal void AddPotterBooks(List<PotterBook> potterBooks)
        {
            this._potterBooks = potterBooks;
        }
    }
}
