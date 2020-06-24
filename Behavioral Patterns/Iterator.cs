using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Iterator pattern  - access a collection of objects sequentially without specifying the underlying representation.

namespace DesignPatterns.Behavioral_Patterns
{
    public interface Iterator
    {
        int next();
        bool hasNext();
    }
    public class ArrayIterator : Iterator
    {
        private int[] arr;
        private int pos;
        private int len;
        public ArrayIterator(int []arr,int len)
        {
            this.arr = arr;
            this.len = len;
            pos = -1;
        }
        public bool hasNext()
        {
            return pos + 1 < len;
        }

        public int next()
        {
            return arr[++pos];
        }
    }
    public class Node
    {
        public int data { get; set; }
        public Node next { get; set; }
        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }
    public class ListIterator : Iterator
    {
        private Node current;
        public ListIterator(Node head)
        {
            this.current = head;
        }
        public bool hasNext()
        {
            return current != null;
        }

        public int next()
        {
            int val = current.data;
            current = current.next;
            return val;
        }
    }
    public interface Collection
    {
        Iterator getIterator();
        void insert(int val);
    }

    public class Array : Collection
    {
        private int[] arr;
        private int len;
        public Array(int size)
        {
            arr = new int[size];
            len = 0;
        }
        public Iterator getIterator()
        {
            return new ArrayIterator(arr, len);
        }

        public void insert(int val)
        {
            arr[len++] = val;
        }
    }
    public class LinkedList : Collection
    {
        private Node head;
        private Node current;
       
        public Iterator getIterator()
        {
            return new ListIterator(head);
        }

        public void insert(int val)
        {
            Node node = new Node(val);
            if (current == null)
            {
                head = node;
                current = node;
            }
            else
            {
                current.next = node;
                current = node;
            }
        }
      
    }
    
    public class IteratorClient
    {
        public static void Main(string[] args)
        {
            Collection arr = new Array(5);
            arr.insert(1);
            arr.insert(2);
            arr.insert(3);
            arr.insert(4);
            arr.insert(5);
            iterate(arr.getIterator());
            Collection lst = new LinkedList();
            lst.insert(1);
            lst.insert(2);
            lst.insert(3);
            lst.insert(4);
            lst.insert(5);
            iterate(lst.getIterator());
            Console.ReadKey();

        }
        public static void iterate(Iterator it)
        {
            while (it.hasNext())
            {
                Console.Write(it.next()+" ");
            }
            Console.WriteLine();
        }
    }

}
