using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;

namespace Collections
{
    class Program
    {


        static void Main(string[] args)
        {
            /* Collection: */
            // DynamicArray();
            // NonGenericCollection();
            Hashtable();
        }

        private static void Hashtable()
        {
            /*
                Array Collection: key/value Combination
                1010/
            */
            Hashtable ht = new Hashtable();
            ht.Add("ID", 1);
            ht.Add("name", "Gilmar");
            ht.Add("age", 18);
            ht.Add("phone", "31123423");

            Console.WriteLine("Hello".GetHashCode());
            Console.WriteLine(ht.GetHashCode());

            foreach (var key in ht.Keys)
                Console.WriteLine(key + ": " + ht[key]);

        }

        private static void NonGenericCollection()
        {
            /*
                System.Collection: 
                Stack, Queue, LinkedList, SortedList, ArrayList, Hashtable
                ArrayList: 
                - Array vs ArrayList
                    - Fix Lenght | VariableList
                    - Not possible insert itens | We can insert itens int the middle
                    - Not possible delete itens | we can delete itens from the middle
                - Capacite increase when add itens 4 in 4 
                
            */
            ArrayList al = new ArrayList(1);
            Console.WriteLine(al.Capacity);
            al.Add("1");
            Console.WriteLine(al.Capacity);
            al.Add(2); al.Add(3); al.Add(4);
            Console.WriteLine(al.Capacity);
            al.Add(5);
            Console.WriteLine(al.Capacity);
            al.Add(6); al.Add("777"); al.Add(8.9); al.Add(9);
            Console.WriteLine(al.Capacity);
            PrintCollection(al);
            al.Insert(3, 0);
            PrintCollection(al);
            al.Remove("777");
            al.RemoveAt(3);
            PrintCollection(al);
        }

        static void ShowMemoryAddr(object obj)
        {
            GCHandle gch = GCHandle.Alloc(obj, GCHandleType.Pinned);
            IntPtr pObj = gch.AddrOfPinnedObject();
            Console.WriteLine(pObj.ToString());
        }

        static void PrintCollection(ICollection collection)
        {
            foreach (var item in collection)
                Console.Write(item + ",");
            Console.WriteLine();

        }

        static void DynamicArray()
        {
            /*
                - Dynamic Array
                - Imutable
                - Not increase the size
                - Not inserve values into the middle
                - Not delete values into the meddle
            */
            var arr = new char[4] { '1', '2', '3', '4' };
            ShowMemoryAddr(arr);
            Array.Resize(ref arr, 10); // create a new array
            PrintCollection(arr);
            ShowMemoryAddr(arr);
        }
    }
}
