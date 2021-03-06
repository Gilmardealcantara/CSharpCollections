﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            // Hashtable();
            // GenericCollections();

            // TestGenerics();
            // DisctionaryCollection();
            // TestCostumers();
            // TestComparable();
            TestIEnumberable();


        }

        private static void TestIEnumberable()
        {
            /* 
                IEnumerable
                IEnumerable
                    - ICollection
                        - IList
                        - IDictionary
            */
            var organization = new Organization();
            var e1 = new Employee { Id = 121, Name = "S1", Salary = 11.14, Job = "develop" };
            var e2 = new Employee { Id = 22, Name = "S2", Salary = 2.24, Job = "manager" };
            var e3 = new Employee { Id = 321, Name = "S3", Salary = 3.34, Job = "dba" };
            var e4 = new Employee { Id = 93, Name = "S4", Salary = 44.44, Job = "develop" };

            organization.Add(e1);
            organization.Add(e2);
            organization.Add(e3);
            organization.Add(e4);
            foreach (var item in organization)
                Console.Write(item + ", ");
            Console.WriteLine();
            for (var i = 0; i < organization.Count; i++)
                Console.Write(organization[i] + ", ");
            Console.WriteLine();


        }

        private static void TestComparable()
        {
            var s1 = new Student { Id = 121, Name = "S1", Marks = 11.14f, Class = 1 };
            var s2 = new Student { Id = 22, Name = "S2", Marks = 2.24f, Class = 2 };
            var s3 = new Student { Id = 321, Name = "S3", Marks = 3.34f, Class = 3 };
            var s4 = new Student { Id = 93, Name = "S4", Marks = 44.44f, Class = 4 };
            var students = new List<Student> { s1, s2, s3, s4 };
            // students.Sort();
            // students.Sort(new CompareStudent());
            // students.Sort(1, 3, new CompareStudent());
            students.Sort(delegate (Student a, Student b) { return a.Id.CompareTo(b.Id); });
            students.Sort((a, b) => a.Id.CompareTo(b.Id));
            PrintCollection(students);
        }

        private static void TestCostumers()
        {
            var customers = new List<Customer>();
            var c1 = new Customer { Id = 1, Name = "C1" };
            var c2 = new Customer { Id = 2, Name = "C2" };
            var c3 = new Customer { Id = 3, Name = "C3" };
            var c4 = new Customer { Id = 4, Name = "C4" };
            customers.Add(c1); customers.Add(c2); customers.Add(c3); customers.Add(c4);
            PrintCollection(customers);

        }

        private static void DisctionaryCollection()
        {
            /* Hash table generic*/
            var dt = new Dictionary<string, object>();
            dt.Add("ID", 1);
            dt.Add("name", "Gilmar");
            dt.Add("age", 18);
            dt.Add("phone", "31123423");
            foreach (string key in dt.Keys)
                Console.WriteLine(key + ": " + dt[key]);
        }

        private static void TestGenerics()
        {
            // Generic1 obj = new Generic1();
            // Console.WriteLine(obj.Compare(1, 1));
            // Console.WriteLine(obj.Compare<float>(1.0f, 1.0f));

            // Generic2<int> obj = new Generic2<int>();
            // obj.Add(1, 2); obj.Sub(1, 2); obj.Mult(1, 2); obj.Div(1, 2);


            // Console.WriteLine(obj.Compare("true", true));
        }

        private static void GenericCollections()
        {
            /*
                System.Collections.Generic;
                Array: Type Safe + Fixed Lenght
                Collections: Auto Resizing + not Type safe
                => Generic Collections: Type save and auto Resizing
            */
            List<int> li = new List<int>();
            li.Add(1); li.Add(2); li.Add(3); li.Add(4);
            PrintCollection(li);
            li.Insert(2, 10);
            PrintCollection(li);
            li.RemoveAt(2);
            li.Remove(1);
            PrintCollection(li);


        }

        private static void Hashtable()
        {
            /*
                Array Collection: key/value Combination
                - no type safe
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
                Console.Write(item + ", ");
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


    public class Generic1
    {
        /* Sobrecarfa/Overload */
        // public bool Compare(int a, int b) => a == b;
        // public bool Compare(float a, float b) => a == b;
        // public bool Compare(string a, string b) => a == b;

        /* Use Object type => Is not Type safe => box and unboxing operation*/
        // public bool Compare(object a, object b) => a.Equals(b);

        /* Use Generics*/
        public bool Compare<T>(T a, T b) => a.Equals(b);
    }
    public class Generic2<T>
    {
        /*dynamic defines types in exec time, is possoble use aritimetic operations*/
        public void Add(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            Console.WriteLine(da + db);
        }
        public void Sub(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            Console.WriteLine(da - db);
        }
        public void Mult(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            Console.WriteLine(da * db);
        }
        public void Div(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            Console.WriteLine(da / db);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"\nID: {this.Id}, name: {this.Name}";
        }
    }

    public class Student : IComparable<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public float Marks { get; set; }

        public int CompareTo([AllowNull] Student other)
        {
            if (this.Id > other.Id) return 1;
            if (this.Id < other.Id) return -1;
            return 0;
        }

        public override string ToString() => $"\nID: {this.Id}, name: {this.Name}, class: {this.Class}, marks: {this.Marks}";
    }

    public class CompareStudent : IComparer<Student>
    {
        public int Compare([AllowNull] Student x, [AllowNull] Student y)
        {
            if (x.Marks > y.Marks) return 1;
            if (x.Marks < y.Marks) return -1;
            return 0;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public override string ToString() => $"\nID: {this.Id}, name: {this.Name}, salay: {this.Salary}, job: {this.Job}";
    }

    public class Organization : IEnumerable
    {
        List<Employee> _employees = new List<Employee>();
        public int Count { get { return _employees.Count; } }
        public Employee this[int index] { get { return _employees[index]; } }

        public void Add(Employee emp)
        {
            _employees.Add(emp);
        }
        public IEnumerator GetEnumerator()
        {
            // return _employees.GetEnumerator();
            return new OrganizationEnumerator(this);
        }
    }

    public class OrganizationEnumerator : IEnumerator
    {
        Organization _orgColl;
        int _currentIndex;
        Employee _currnetEmployee;

        public OrganizationEnumerator(Organization org)
        {
            _orgColl = org;
            _currentIndex = -1;
        }

        public object Current => _currnetEmployee;

        public bool MoveNext()
        {
            if (++_currentIndex >= _orgColl.Count)
                return false;
            _currnetEmployee = _orgColl[_currentIndex];
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
