using DataStrcutureAlgorithm.Concepts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataStrcutureAlgorithm.UnitTest.Concepts
{
    public class BitmanipulationTestClass
    {
        private readonly BitManipulation bitManipulation;

        public BitmanipulationTestClass()
        {
            bitManipulation = new BitManipulation();
        }

        [Fact]
        public void Should()
        {
            var res = bitManipulation.ShitftBit(9);
            int expected = 18;
            Assert.Equal(res, expected);
        }
    }
}
