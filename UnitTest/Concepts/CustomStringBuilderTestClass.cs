using DataStrcutureAlgorithm.Concepts;
using Xunit;

namespace UnitTest.Concepts
{

    public class CustomStringBuilderTestClass
    {
        private readonly CustomStringBuilder customStringBuilder;

        public CustomStringBuilderTestClass()
        {
            customStringBuilder = new CustomStringBuilder("Test");
        }

        [Fact]
        public void ShouldAddNewStringOnConstructor()
        {
            string result = customStringBuilder.ToString();
            Assert.Equal("Test", result);
        }

        [Fact]
        public void ShouldAppendNewString()
        {
            customStringBuilder.Append("Test");
            string result = customStringBuilder.ToString();
            Assert.Equal("TestTest", result);
        }


        [Fact]
        public void ShouldExpandMaxCapacity()
        {
            customStringBuilder.Append("TestTest");
            string result = customStringBuilder.ToString();
            Assert.Equal("TestTestTest", result);
        }
    }
}
