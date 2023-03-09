/*
 * Task description in a txt file
 */
namespace UP14
{
    public class Program
    {
        static void Main(string[] args)
        {
            FirstTaskTests();
            SecondTaskTests();
        }
        static void FirstTaskTests()
        {
            CVector<int> v1 = new CVector<int>(3);
            v1[0] = 1;
            v1[1] = 2;
            v1[2] = 3;

            CVector<int> v2 = new CVector<int>(3);
            v2[0] = 4;
            v2[1] = 5;
            v2[2] = 6;

            CVector<int> v3 = v1 + 2;
            Console.WriteLine($"Sum of 2 and | {v1.ToString()}| = | "+v3.ToString() + "|");
            
            try
            {
                CVector<int> v4 = v1 - v2;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            if (v1 != v2)
            {
                Console.WriteLine("v1 and v2 are not equal");
            }

            v1.VectorChecked += VectorCheckedHandler;
            v1.CheckVector();
        }
        static void SecondTaskTests()
        {
            Dictionary<int, int>[] collections = new Dictionary<int, int>[]
            {
                    new Dictionary<int, int>() { { 1, -2 }, { 2, 3 }, { 3, 4 } },
                    new Dictionary<int, int>() { { 5, 6 }, { 6, 7 } },
                    new Dictionary<int, int>() { { 7, -8 }, { 8, 9 }, { 9, 10 } }
            };

            CollectionType<int> type = new CollectionType<int>(collections);

            Console.WriteLine("\nFirst " + type.collections[0].ToString<int>());
            Console.WriteLine("Second " + type.collections[1].ToString<int>());
            Console.WriteLine("Third " + type.collections[2].ToString<int>());

            Dictionary<int, int>[] negativeCollections = type.FindCollectionsWithNegativeElements();
            Dictionary<int, int> maxCollection = type.FindMaxCollection();
            Dictionary<int, int> minCollection = type.FindMinCollection();
            Dictionary<int, int> collectionWithElement = type.FindCollectionWithElement(3);

            type.SortCollections();

            Console.WriteLine("\nFirst " + type.collections[0].ToString<int>());
            Console.WriteLine("Second " + type.collections[1].ToString<int>());
            Console.WriteLine("Third " + type.collections[2].ToString<int>());

            Console.WriteLine("\nNegative Collections ");
            foreach (var negativeCollection in negativeCollections)
            {
                Console.WriteLine(negativeCollection.ToString<int>());
            }
            Console.WriteLine("\nMax Collection " + maxCollection.ToString<int>());
            Console.WriteLine("Min Collection " + minCollection.ToString<int>());
            Console.WriteLine("Collection With Element 3     " + collectionWithElement.ToString<int>());
        }
        static void VectorCheckedHandler(bool result)
        {
            Console.WriteLine("Vector is " + (result ? "uniform" : "non-uniform"));
        }
    }
}

