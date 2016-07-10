using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_Day2_Homework
{
    public class PotterShoppingCart
    {
        private List<PotterBook> _potterBooks;

        public int checkout()
        {
            if (this._potterBooks == null || this._potterBooks.Count() == 0) { return 0; }

            Dictionary<int, int> bookCountByVolume = getBookCountByVolume();

            int amount = 0;

            // process 4 different volume case: 20% discount
            amount += calculateAmountOfPromotion(bookCountByVolume, 4, 0.20m);

            // process 3 different volume case: 10% discount
            amount += calculateAmountOfPromotion(bookCountByVolume, 3, 0.10m);

            // process 2 different volume case: 5% discount
            amount += calculateAmountOfPromotion(bookCountByVolume, 2, 0.05m);

            // process normal case: no discount
            amount += calculateAmountOfNormalCase(bookCountByVolume);

            return amount;
        }

        private Dictionary<int, int> getBookCountByVolume()
        {
            var countByVolume = new Dictionary<int, int>();
            foreach (var potterBook in this._potterBooks)
            {
                if (countByVolume.ContainsKey(potterBook.Volume))
                {
                    countByVolume[potterBook.Volume] += 1;
                }
                else
                {
                    countByVolume[potterBook.Volume] = 1;
                }
            }

            return countByVolume;
        }

        private static int calculateAmountOfNormalCase(Dictionary<int, int> countByVolume)
        {
            int amount = 0;
            var volumes = countByVolume.Keys.ToList();
            foreach (var volume in volumes)
            {
                amount += 100 * countByVolume[volume];
            }

            return amount;
        }

        private static int calculateAmountOfPromotion(Dictionary<int, int> bookCountByVolume, int differentBooksNum, decimal discount)
        {
            int amount = 0;
            while (bookCountByVolume.Count >= differentBooksNum)
            {
                amount += (int)(100 * differentBooksNum * (1 - discount));
                
                int bookMinusNum = differentBooksNum;
                var volumes = bookCountByVolume.Keys.ToList();
                foreach (var volume in volumes)
                {
                    if (bookCountByVolume[volume] > 0)
                    {
                        bookCountByVolume[volume] -= 1;
                        bookMinusNum -= 1;

                        if (bookCountByVolume[volume] == 0)
                        {
                            bookCountByVolume.Remove(volume);
                        }
                    }

                    if (bookMinusNum == 0) { break; }
                }
            }

            return amount;
        }

        internal void AddPotterBooks(List<PotterBook> potterBooks)
        {
            if (this._potterBooks == null)
            {
                this._potterBooks = potterBooks;
            }
            else
            {
                this._potterBooks.AddRange(potterBooks);
            }
        }
    }
}
