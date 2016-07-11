using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Day2_Homework
{
    internal class Promotion : IAmountCalculator
    {
        public int DifferentVolumesNum { get; internal set; }
        public decimal Discount { get; internal set; }

        public decimal Calculate(Dictionary<int, int> bookCountByVolume, decimal unitPrice)
        {
            decimal amount = 0m;
            while (bookCountByVolume.Count >= DifferentVolumesNum)
            {
                amount += unitPrice * DifferentVolumesNum * (1 - Discount);

                this.minusBookFromDifferentVolume(bookCountByVolume, DifferentVolumesNum);
            }

            return amount;
        }

        private void minusBookFromDifferentVolume(Dictionary<int, int> bookCountByVolume, int minusNum)
        {
            var volumes = bookCountByVolume.Keys.ToList();
            foreach (var volume in volumes)
            {
                bookCountByVolume[volume] -= 1;
                if (bookCountByVolume[volume] == 0)
                {
                    bookCountByVolume.Remove(volume);
                }

                minusNum -= 1;
                if (minusNum == 0) { break; }
            }
        }
    }
}