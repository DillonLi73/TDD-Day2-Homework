using System.Collections.Generic;

namespace TDD_Day2_Homework
{
    internal interface IAmountCalculator
    {
        decimal Calculate(Dictionary<int, int> bookCountByVolume, decimal unitPrice);
    }
}