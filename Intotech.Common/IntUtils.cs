using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common
{
    public static class IntUtils
    {
        public static int GetRandomCode(int min, int max)
        {
            Random rnd = new Random();

            return rnd.Next(min, max);
        }
    }
}
