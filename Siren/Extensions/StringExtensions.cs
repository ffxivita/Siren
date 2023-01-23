using System.Linq;

namespace Siren.Extensions
{
    public static class StringExtensions
    {
        public static string TrimWhitepace(this string str) => new(str.Where(c => !char.IsWhiteSpace(c)).ToArray());
    }
}