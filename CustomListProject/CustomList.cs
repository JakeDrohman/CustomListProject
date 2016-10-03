using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomListProject
{
    public class CustomList<T>:IEnumerable<T> where T:IComparable
    {
        private T[] MainArray;
        private int count;
        private int capacity;
        public CustomList()
        {
            MainArray = new T[100];
            capacity = 5;
            count = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return MainArray[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public void Add(T item)
        {
            if (count<capacity)
            {
                MainArray[count] = item;
                count++;
            }
            else
            {
                T[] temporaryArray = new T[count];
                CopyTo(temporaryArray);
                MainArray = new T[count + 5];
                CopyFrom(temporaryArray);
                capacity = count + 5;
                Add(item);
            }
        }
        public void Remove(T item)
        {
            bool hasItem = CheckIfHas(item);
            if(hasItem == true)
            {
                int index = FindIndex(item);
                for(int i = index; i <= count; i++)
                {
                    MainArray[i] = MainArray[i + 1];
                }
                count--;
            }
        }
        private bool CheckIfHas(T item)
        {
            bool containsItem = false;
            for (int i = 0; i <= count;i++)
            {
                if (MainArray[i].Equals(item))
                {
                    containsItem = true;
                }
            }
            return containsItem;
        }
        private int FindIndex(T item)
        {
            for(int i = 0; i < count; i++)
            {
                if (item.Equals(MainArray[i]))
                {
                    return i;
                }
            }
            throw new Exception("Does not exist in context");                        
        }
        public override string ToString()
        {
            string item = null;
            for(int i = 0; i < count; i++)
            {
                item += (MainArray[i] + " ");
            }
            return item;
        }
        public static CustomList<T> operator -(CustomList<T> firstList, CustomList<T> secondList)
        {
            for(int i = 0; i < secondList.count; i++)
            {
                firstList.Remove(secondList.MainArray[i]);
            }
            return firstList;
        }
        public static CustomList<T> operator +(CustomList<T> firstList,CustomList<T> secondList)
        {
            for(int i = 0; i < secondList.count; i++)
            {
                firstList.Add(secondList.MainArray[i]);
            }
            return firstList;
        }
        public void Zipper(CustomList<T> secondList)
        {
            int zipLength;
            if (count >= secondList.count)
            {
                zipLength = secondList.count;
                count = secondList.count * 2;
            }
            else
            {
                zipLength = count;
                count = count * 2;
            }
                T[] temporaryArray = new T[secondList.count+count];
                int j = 0;
                CopyTo(temporaryArray);
                for (int i = 0; i < zipLength; i++)
                {                    
                    MainArray[j] = temporaryArray[i];
                    MainArray[j+1] = secondList.MainArray[i];
                    j += 2;
                }
            
        }
        public T[] CopyTo(T[] array)
        {
            for (int i = 0; i < count; i++)
            {
                array[i] = MainArray[i];
            }
            return array;
        }
        public void CopyFrom(T[] array)
        {
            for (int i = 0; i < count; i++)
            {
                MainArray[i] = array[i];
            }
        }
        public void Sort()
        {
            for(int i = 0; i < count; i++)
            {
                for(int j = 0; j < count; j++)
                {
                    if(MainArray[j].CompareTo(MainArray[j + 1])>0)
                    {
                        SwapWithNext(j);
                    }                    
                }
            }
        }
        private void SwapWithNext(int index)
        {
            T itemOne = MainArray[index];
            MainArray[index] = MainArray[index + 1];
            MainArray[index + 1] = itemOne;
        }
    }
}