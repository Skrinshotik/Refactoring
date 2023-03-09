using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UP14
{
    public class CVector<T>
    {
        private T[] vector;
        private int size;

        public CVector(int size)
        {
            this.size = size;
            vector = new T[size];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                return vector[index];
            }
            set
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                vector[index] = value;
            }
        }

        public static CVector<T> operator +(CVector<T> v1, int num)
        {
            CVector<T> result = new CVector<T>(v1.size);
            for (int i = 0; i < v1.size; i++)
            {
                dynamic x = v1[i];
                dynamic y = num;
                result[i] = x + y;
            }
            return result;
        }

        public static CVector<T> operator -(CVector<T> v1, CVector<T> v2)
        {
            if (v1.size != v2.size)
            {
                throw new Exception("Vectors have different sizes");
            }
            CVector<T> result = new CVector<T>(v1.size);
            for (int i = 0; i < v1.size; i++)
            {
                dynamic x = v1[i];
                dynamic y = v2[i];
                result[i] = x - y;
            }
            return result;
        }

        public static bool operator ==(CVector<T> v1, CVector<T> v2)
        {
            if (v1.size != v2.size)
            {
                return false;
            }
            for (int i = 0; i < v1.size; i++)
            {
                if (!v1[i].Equals(v2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(CVector<T> v1, CVector<T> v2)
        {
            return !(v1 == v2);
        }

        public delegate void VectorCheckedEventHandler(bool result);
        public event VectorCheckedEventHandler VectorChecked;

        public void CheckVector()
        {
            bool result = true;
            for (int i = 1; i < size; i++)
            {
                if (!vector[i].Equals(vector[i - 1]))
                {
                    result = false;
                    break;
                }
            }
            if (VectorChecked != null)
            {
                VectorChecked(result);
            }
        }

        ~CVector()
        {
            Console.WriteLine("CVector object destroyed");
        }
        public string ToString()
        {
            string result = "";
            int count = 0;
            foreach (var i in vector)
            {
                if (count != size)
                    result = result + $"{i}, ";
                else
                    result = result + $"{i}";
            }
            return result;
        }
    }
}
