using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Day2_Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_Day2_Homework.Tests
{
    [TestClass()]
    public class PotterShoppingCartTests
    {
        [TestMethod()]
        public void Test_Checkout_Buy_1_Volume1_Checkout_should_be_100()
        {
            // arrange
            var target = new PotterShoppingCart();
            var potterBooks = new List<PotterBook>
            {
                new PotterBook() { Volume = 1 }
            };
            target.AddPotterBooks(potterBooks);

            var expected = 100;

            // act
            var actual = target.checkout();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_Checkout_Buy_1_Volume1_And_1_Volume2_Checkout_should_be_190()
        {
            // arrange
            var target = new PotterShoppingCart();
            var potterBooks = new List<PotterBook>
            {
                new PotterBook() { Volume = 1 },
                new PotterBook() { Volume = 2 }
            };
            target.AddPotterBooks(potterBooks);

            var expected = 190;

            // act
            var actual = target.checkout();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}