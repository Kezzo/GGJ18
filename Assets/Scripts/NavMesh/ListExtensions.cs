using System;
using System.Linq;
using System.Collections.Generic;

public static class ListExtensions
{
    public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
    {
        Random rnd = new Random();
        return source.OrderBy((item) => rnd.Next());
    }
}
