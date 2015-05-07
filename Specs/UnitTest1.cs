namespace Specs
{
    using Model;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class KarateTests
    {
        [Test]
        [TestCase("one, two, three, four, five", Result = 19)]
        [TestCase("one, two, three, four, five, six, seven, eight, nine, ten", Result = 39)]
        public int TestTheKarate(string test)
        {
            var kataCalculator = new Kata2Euler(test);
            return kataCalculator.Calculate();
        }

        [Test]
        [TestCase("thirty-one, thirty-two", Result = 18)]
        public int TestTheKarateThirties(string test)
        {
            var kataCalculator = new Kata2Euler(test);
            return kataCalculator.Calculate();
        }

        [TestCase("one hundred, one hundred and one", Result = 26)]
        [TestCase("one hundred, one hundred and one, one hundred and two, one hundred and three, one hundred and four, one hundred and five", Result = 94)]
        public int TestTheKarateWithOneHundred(string test)
        {
            var kataCalculator = new Kata2Euler(test);
            var result = kataCalculator.Calculate();
            Console.Out.WriteLine(kataCalculator.output);
            return result;
        }

        [TestCase("three hundred and forty-two", Result = 23)]
        public int TestTheKarateThreeHundreds(string test)
        {
            var kataCalculator = new Kata2Euler(test);
            return kataCalculator.Calculate();
        }


        [TestCase("one thousand", Result = 11)]
        public int TestTheKarateWithOneThousand(string test)
        {
            var kataCalculator = new Kata2Euler(test);
            return kataCalculator.Calculate();
        }
    }
}
