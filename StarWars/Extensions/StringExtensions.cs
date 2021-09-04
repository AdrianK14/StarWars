using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Extensions
{
    public static class StringExtensions
    {
        public static string CombineUrl(this string basePart, string relativePart)
        {
            return $"{basePart.TrimEnd('/')}/{relativePart.TrimStart('/')}";
        }
    }
}
