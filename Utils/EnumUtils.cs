using System.Collections.Generic;
namespace TestAplication.Utils
{
    public static class EnumUtils
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
           => self.Select((item, index) => (item, index));
    }
}