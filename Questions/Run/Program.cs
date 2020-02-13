using FirstDuplicate;
using System;

namespace Run
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDuplicate = new Source();    
            var arr = new int[] { 2,1,3,3,5,4,3,2,2};
            Console.WriteLine(firstDuplicate.FirstDuplicate(arr).ToString());
        }
    }
}
