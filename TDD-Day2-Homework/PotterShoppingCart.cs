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
                int differentVolumesNum = GetDifferentVolumesNum(booksByVolume, skipBookNum);
                if (differentVolumesNum <= 0)
                {
                    // 沒有書了，離開迴圈
                    break;
                }
                else
                {
                    amount += CalculateAmount(differentVolumesNum);
                    skipBookNum++;
                }
            }

            return amount;
        }

        private int CalculateAmount(int differentVolumesNum)
        {
            decimal discount = this._discounts[differentVolumesNum];
            return (int)(differentVolumesNum * 100 * (1 - discount));
        }

        private static int GetDifferentVolumesNum(IEnumerable<IGrouping<int, PotterBook>> booksByVolume, int skipBookNum)
        {
            var differentVolumesNum = 0;
            foreach (var booksOfVolume in booksByVolume)
            {
                if (booksOfVolume.Skip(skipBookNum).Count() > 0)
                {
                    differentVolumesNum++;
                }
            }

            return differentVolumesNum;
        }

        internal void AddPotterBooks(List<PotterBook> potterBooks)
        {
            this._potterBooks = potterBooks;
        }
    }
}
