using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace double_linked_list
{
    class Node
    {
        // Node Class represent the node of doubly linked list
        //it conscist of the information part and links to
        //its succeding and preceeding
        //in terms of next and provious

        public int noMhs;
        public string name;
        //point to the succeding node
        public Node next;
        public Node prev;
    }

    class DoubleLinkedList
    {
        Node STAR;
        //constructor

        public void addNote()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the roll number of students: ");
            nim= Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Enter the name of students: ");
            nm= Console.ReadLine();
            Node newNode = new Node();
            newNode.noMhs= nim;
            newNode.name = nm;


            //check
        }
    }

















    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
