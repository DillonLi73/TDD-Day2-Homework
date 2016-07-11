using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_Day2_Homework
{
    public class PotterShoppingCart
    {
        private List<PotterBook> _potterBooks;
        private List<Promotion> _promotions = new List<Promotion> {
            new Promotion() { DifferentVolumesNum = 2, Discount = 0.05m },
            new Promotion() { DifferentVolumesNum = 3, Discount = 0.10m },
            new Promotion() { DifferentVolumesNum = 4, Discount = 0.20m },
            new Promotion() { DifferentVolumesNum = 5, Discount = 0.25m }
        };
        private PotterBookCalculator _potterBookCalculator = new PotterBookCalculator();

        public int checkout()
        {
            if (this._potterBooks == null || this._potterBooks.Count() == 0) { return 0; }

            List<IAmountCalculator> amountCalculators = GetCalculators();
            Dictionary<int, int> bookCountByVolume = getBookCountByVolume();
            int amount = (int)amountCalculators.Sum(x => x.Calculate(bookCountByVolume, PotterBook.PRICE));

            return amount;
        }

        private List<IAmountCalculator> GetCalculators()
        {
            var calculators = new List<IAmountCalculator>();

            var sortedPromotions = this._promotions;
            sortedPromotions.Sort((x, y) => { return -x.Discount.CompareTo(y.Discount); });
            calculators.AddRange(sortedPromotions);

            calculators.Add(this._potterBookCalculator);

            return calculators;
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
