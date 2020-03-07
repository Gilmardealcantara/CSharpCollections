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
            DynamicArray();
            NonGenericCollection();
        }

        private static void NonGenericCollection()
        {
            throw new NotImplementedException();
        }

        static void ShowMemoryAddr(object obj)
        {
            GCHandle gch = GCHandle.Alloc(obj, GCHandleType.Pinned);
            IntPtr pObj = gch.AddrOfPinnedObject();
            Console.WriteLine(pObj.ToString());
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
            Array.Resize(ref arr, 5); // create a new array
            Console.WriteLine(string.Join(',', arr));
            ShowMemoryAddr(arr);
        }
    }
}
