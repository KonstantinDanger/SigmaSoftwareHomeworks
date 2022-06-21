using System.Collections;

namespace Task_2_1
{
    public class ComparerByPrice : IComparer<Product>
    {
        //public int Compare(object? x, object? y)
        //{
        //    return (x as Product).Price.CompareTo((y as Product).Price);
        //}
        public int Compare(Product? x, Product? y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
