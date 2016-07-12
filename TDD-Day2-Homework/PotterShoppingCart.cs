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
            decimal discount = this._discounts[this._potterBooks.Count];
            return (int)(_potterBooks.Count * 100 * (1 - discount));
        }

        internal void AddPotterBooks(List<PotterBook> potterBooks)
        {
            this._potterBooks = potterBooks;
        }
    }
}
