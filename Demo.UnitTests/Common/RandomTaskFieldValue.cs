using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.UnitTests.Common
{
    static class RandomTaskFieldValue
    {
        public static string Name()
        {
            return RandomValue.String(RandomValue.Integer(1, 255));
        }

        public static string Description()
        {
            return RandomValue.String(RandomValue.Integer(0, 65535));
        }
    }
}
