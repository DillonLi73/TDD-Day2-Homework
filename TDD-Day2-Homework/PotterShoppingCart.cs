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
            switch (_potterBooks.Count)
            {
                case 2:
                    return (int)(_potterBooks.Count * 100 * 0.95);
                case 3:
                    return (int)(_potterBooks.Count * 100 * 0.9);
                default:
                    return _potterBooks.Count * 100;
            }
        }

        internal void AddPotterBooks(List<PotterBook> potterBooks)
        {
            this._potterBooks = potterBooks;
        }
    }
}
