using System.Collections.Generic;

namespace TDD_Day2_Homework
{
    internal interface IBookCalculator
    {
        int CalculateAmount(Dictionary<int, int> bookCountByVolume, decimal unitPrice);
    }
}