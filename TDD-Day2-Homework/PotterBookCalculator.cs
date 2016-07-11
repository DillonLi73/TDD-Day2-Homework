using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Day2_Homework
{
    internal class PotterBookCalculator
    {
        internal int calculateAmount(Dictionary<int, int> bookCountByVolume, decimal unitPrice)
        {
            int amount = 0;
            var volumes = bookCountByVolume.Keys.ToList();
            foreach (var volume in volumes)
            {
                amount += (int)(unitPrice * bookCountByVolume[volume]);
            }

            return amount;
        }
    }
}