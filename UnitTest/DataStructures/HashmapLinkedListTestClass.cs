using DataStrcutureAlgorithm.DataStructures;
using Xunit;

namespace DataStrcutureAlgorithm.UnitTest.DataStructures
{
    public class HashmapLinkedListTestClass
    {
        private readonly HashmapLinkedList hashmapLinkedList;

        public HashmapLinkedListTestClass()
        {
            hashmapLinkedList = new HashmapLinkedList();
            hashmapLinkedList.Add("1", "1001");
        }

        [Fact]
        public void ShouldReturnValue()
        {
            var res = hashmapLinkedList.GetValue("1");
            string expected = "1001";
            Assert.Equal(res, expected);
        }
    
    
    }
}
