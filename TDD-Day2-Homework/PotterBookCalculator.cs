using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Day2_Homework
{
    internal class PotterBookCalculator : IAmountCalculator
    {
        public decimal Calculate(Dictionary<int, int> bookCountByVolume, decimal unitPrice)
        {
            return bookCountByVolume.Sum(x => x.Value * unitPrice);
        }
    }
}