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
            amount += calculateAmountOfPromotion3(bookCountByVolume);

            // process 3 different volume case: 10% discount
            amount += calculateAmountOfPromotion2(bookCountByVolume);

            // process 2 different volume case: 5% discount
            amount += calculateAmountOfPromotion1(bookCountByVolume);

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

        private static int calculateAmountOfPromotion1(Dictionary<int, int> bookCountByVolume)
        {
            int amount = 0;
            while (bookCountByVolume.Count >= 2)
            {
                amount += (int)(100 * 2 * 0.95);

                int bookMinusNum = 2;
                var volumes = bookCountByVolume.Keys.ToList();
                foreach (var volume in volumes)
                {
                    if (bookCountByVolume[volume] > 0)
                    {
                        bookCountByVolume[volume] -= 1;
                        if (bookCountByVolume[volume] == 0)
                        {
                            bookCountByVolume.Remove(volume);
                        }
                        bookMinusNum -= 1;
                    }

                    if (bookMinusNum == 0) { break; }
                }
            }

            return amount;
        }

        private static int calculateAmountOfPromotion2(Dictionary<int, int> bookCountByVolume)
        {
            int amount = 0;
            while (bookCountByVolume.Count >= 3)
            {
                amount += (int)(100 * 3 * 0.90);

                int bookMinusNum = 3;
                var volumes = bookCountByVolume.Keys.ToList();
                foreach (var volume in volumes)
                {
                    if (bookCountByVolume[volume] > 0)
                    {
                        bookCountByVolume[volume] -= 1;
                        if (bookCountByVolume[volume] == 0)
                        {
                            bookCountByVolume.Remove(volume);
                        }
                        bookMinusNum -= 1;
                    }

                    if (bookMinusNum == 0) { break; }
                }
            }

            return amount;
        }

        private static int calculateAmountOfPromotion3(Dictionary<int, int> bookCountByVolume)
        {
            int amount = 0;
            while (bookCountByVolume.Count >= 4)
            {
                amount += (int)(100 * 4 * 0.80);

                int bookMinusNum = 4;
                var volumes = bookCountByVolume.Keys.ToList();
                foreach (var volume in volumes)
                {
                    if (bookCountByVolume[volume] > 0)
                    {
                        bookCountByVolume[volume] -= 1;
                        if (bookCountByVolume[volume] == 0)
                        {
                            bookCountByVolume.Remove(volume);
                        }
                        bookMinusNum -= 1;
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
