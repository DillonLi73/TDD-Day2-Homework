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
            decimal discount = 0;
            switch (_potterBooks.Count)
            {
                case 2:
                    discount = 0.05m;
                    break;
                case 3:
                    discount = 0.1m;
                    break;
            }
            return (int)(_potterBooks.Count * 100 * (1 -discount));
        }

        internal void AddPotterBooks(List<PotterBook> potterBooks)
        {
            this._potterBooks = potterBooks;
        }
    }
}
