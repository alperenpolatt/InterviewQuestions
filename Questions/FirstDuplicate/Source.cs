using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstDuplicate
{
    public class Source
    {
       
        private bool compareNumbersAndLength(int[] arr) => !arr.Any(a => a > arr.Length);
        public int FirstDuplicatePrimitive(int[] arr)
        {
            if (!compareNumbersAndLength(arr))
                return -1;
            var duplicates = new int[arr.Length];
            for (int i = 0, k = 0; i < arr.Length; i++) { 
                for (int j = i + 1; j < arr.Length; j++) { 
                    if (arr[i] == arr[j]) {
                        duplicates[k] = j;
                        k++;
                    }
                }
                
            }
            if (duplicates[0] == 0)//no duplicates
                return -1;
            var minIndex = duplicates[0];
            for (int i = 1; i<duplicates.Length; i++)
            {
                if (duplicates[i] < minIndex && duplicates[i]>0)
                    minIndex = duplicates[i];
            }
            return arr[minIndex];
        }
        public int FirstDuplicate(int[] arr)
        {
            if (!compareNumbersAndLength(arr))
                return -1;
            var duplicates = arr.Select((x, i) => new { Value = x, Index = i })
                  .GroupBy(x => x.Value)
                  .Where(x=>x.Count()>1)
                  .ToDictionary(x => x.Key, x => x.Select(y => y.Index)
                                                  .ToArray());
            if (duplicates.Count == 0)
                return -1;
            var minIndex = duplicates.Values.SelectMany(a => a.Skip(1)).Min();
            return arr[minIndex];
        }
    }
}
