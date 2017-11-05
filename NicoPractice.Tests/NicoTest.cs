using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NicoPractice.Tests
{
    public class NicoTest
    {
        [TestCase("abc","abc","abc",TestName = "Nico_When_Key_is_abc_And_Message_is_abc_should_return_abc")]
        [TestCase("bac","abc","bac",TestName = "Nico_When_Key_is_bac_And_Message_is_abc_should_return_bac")]
        [TestCase("abc", "abcdef", "abcdef", TestName = "Nico_When_Key_is_bac_And_Message_is_abcdef_should_return_abcdef")]
        [TestCase("abc", "abcd", "abcd  ", TestName = "Nico_When_Key_is_bac_And_Message_is_abcdef_should_return_abcd  ")]
        public void Basic_Nico_Variation(string key, string message, string expectedResult)
        {
            var nico = new Nico();
            var result = nico.NicoVariation(key,message);

            var expected = expectedResult;

            Assert.AreEqual(expected,result);
        }
    }
}
