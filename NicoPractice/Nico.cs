using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoPractice
{
    public class Nico
    {
        public string NicoVariation(string key, string message)
        {
            var container = message.ToCharArray();
            return new string(container);
        }
    }
}
