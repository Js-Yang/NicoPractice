using NicoPractice;

namespace Solution
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleNico()
        {
            Assert.AreEqual("cseerntiofarmit on  ", Kata.Nico("crazy", "secretinformation"));
            Assert.AreEqual("abcd  ", Kata.Nico("abc", "abcd"));
            Assert.AreEqual("2143658709", Kata.Nico("ba", "1234567890"));
            Assert.AreEqual("message", Kata.Nico("a", "message"));
            Assert.AreEqual("eky", Kata.Nico("key", "key"));
        }
    }
}