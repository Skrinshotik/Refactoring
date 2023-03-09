using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UP14
{
    public class CollectionType<T>
    {
        public Dictionary<int, T>[] collections;

        public CollectionType(Dictionary<int, T>[] collections)
        {
            this.collections = collections;
        }

        public Dictionary<int, T>[] FindCollectionsWithNegativeElements()
        {
            List<Dictionary<int, T>> positiveCollections = new List<Dictionary<int, T>>();
            foreach (Dictionary<int, T> collection in this.collections)
            {
                foreach (T element in collection.Values)
                {
                    if (element is int && Convert.ToInt32(element) < 0)
                    {
                        positiveCollections.Add(collection);
                        break;
                    }
                }
            }
            return positiveCollections.ToArray();
        }

        public Dictionary<int, T> FindMaxCollection()
        {
            Dictionary<int, T> maxCollection = this.collections[0];
            foreach (Dictionary<int, T> collection in this.collections)
            {
                if (collection.Count > maxCollection.Count)
                {
                    maxCollection = collection;
                }
            }
            return maxCollection;
        }

        public Dictionary<int, T> FindMinCollection()
        {
            Dictionary<int, T> minCollection = this.collections[0];
            foreach (Dictionary<int, T> collection in this.collections)
            {
                if (collection.Count < minCollection.Count)
                {
                    minCollection = collection;
                }
            }
            return minCollection;
        }

        public Dictionary<int, T> FindCollectionWithElement(T element)
        {
            foreach (Dictionary<int, T> collection in this.collections)
            {
                if (collection.ContainsValue(element))
                {
                    return collection;
                }
            }
            return null;
        }

        public void SortCollections()
        {
            Array.Sort(this.collections, (x, y) => x.Count.CompareTo(y.Count));
        }
    }
    public static class DictionaryExtension
    {
        public static string ToString<T>(this Dictionary<int,T> dict)
        {
            string result = "| ";
            foreach(var i in dict)
            {
                result += i.Value.ToString()+" ";
            }
            return result+"|";
        }
    }
}
