using NUnit.Framework;

namespace NicoPractice.Tests
{
    public class NicoTest
    {
        [TestCase("abc", "abc", "abc", TestName = "Nico_When_Key_is_abc_And_Message_is_abc_should_return_abc")]
        [TestCase("bac", "abc", "bac", TestName = "Nico_When_Key_is_bac_And_Message_is_abc_should_return_bac")]
        [TestCase("abc", "abcdef", "abcdef", TestName = "Nico_When_Key_is_bac_And_Message_is_abcdef_should_return_abcdef")]
        [TestCase("abc", "abcd", "abcd  ", TestName = "Nico_When_Key_is_bac_And_Message_is_abcdef_should_return_abcd  ")]
        [TestCase("ba", "1234567890", "2143658709", TestName = "Nico_When_Key_is_ba_And_Message_is_2143658709_should_return_2143658709")]
        [TestCase("crazy", "secretinformation", "cseerntiofarmit on  ", TestName = "Nico_When_Key_is_crazy_And_Message_is_secretinformation_should_return_cseerntiofarmit on  ")]
        public void Basic_Nico_Variation(string key, string message, string expectedResult)
        {
            var result = Solution.Nico(key,message);

            var expected = expectedResult;

            Assert.AreEqual(expected,result);
        }
    }
}
