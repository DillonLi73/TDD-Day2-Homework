using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Day2_Homework
{
    internal class Promotion
    {
        public int DifferentVolumesNum { get; internal set; }
        public decimal Discount { get; internal set; }

        internal int CalculateAmount(Dictionary<int, int> bookCountByVolume, decimal unitPrice)
        {
            int amount = 0;
            while (bookCountByVolume.Count >= DifferentVolumesNum)
            {
                amount += (int)(unitPrice * DifferentVolumesNum * (1 - Discount));

                int bookMinusNum = DifferentVolumesNum;
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
    }
}