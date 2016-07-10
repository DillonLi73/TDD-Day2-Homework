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
            if ( this._potterBooks == null || this._potterBooks.Count() == 0 ) { return 0; }

            int amount = 0;

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

            // process 2 different volume case: 5% discount
            List<int> volumes = null;
            while (countByVolume.Count >= 2)
            {
                amount += (int)(100 * 2 * 0.95);

                int bookMinusNum = 2;
                volumes = countByVolume.Keys.ToList();
                foreach (var volume in volumes)
                {
                    if (countByVolume[volume] > 0)
                    {
                        countByVolume[volume] -= 1;
                        if (countByVolume[volume] == 0)
                        {
                            countByVolume.Remove(volume);
                        }
                        bookMinusNum -= 1;
                    }

                    if (bookMinusNum == 0) { break; }
                }   
            }

            // process normal case: no discount
            volumes = countByVolume.Keys.ToList();
            foreach (var volume in volumes)
            {
                amount += 100 * countByVolume[volume];
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
