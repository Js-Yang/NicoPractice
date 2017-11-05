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
        [Test]
        public void Nico_When_Key_is_abc_And_Message_is_abcd_should_return_abcd()
        {
            var nico = new Nico();
            var result = nico.NicoVariation("abc","abcd");

            var expected = "abcd  ";

            Assert.AreEqual(expected,result);
        }
    }
}
