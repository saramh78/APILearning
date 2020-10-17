using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi1.Helper
{
    public static class LinqHelper
    {
        public static int? MaxSara(this IEnumerable<int> source)
        {
            int  value = default(int);
            bool hasValue = false;
            foreach (int x in source)
            {
                if (hasValue)
                {
                    if (x > value) value = x;
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            else throw new ArgumentNullException();
        }        
    }
}
