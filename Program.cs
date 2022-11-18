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
        Node START;
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


            //check if the list empty
            if(START==null || nim <=START.noMhs )
            {
                if((START!=null) && (nim!=START.noMhs)) 
                {
                    Console.WriteLine("\n Duplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if(START!=null)
                    START.prev= newNode;
                newNode.next = null;
                START= newNode;
                return;
            }
            //if the node is to be inserted at between two node
            Node previous, current;
            for(current=previous=START;
                current!=null && nim>= current.noMhs;
                previous=current, current=current.next)
            {
                if(nim== current.noMhs)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            
            //on the execution of the above for loop prev and
            //current will point those nodes
            //between which the new node is to be inserted
            newNode.prev = current;
            newNode.prev = previous;

            //if the node is to be inserted at the end of the list
            if(current==null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            current.next = newNode;
        }

        public bool Search(int rollNo, ref Node Previous, ref Node Current)
        {
            Previous = Current = START;
            while(Current!=null &&
                rollNo != Current.noMhs)
            {
                Previous= Current;
                Current= Current.next;
            }
            return(Current!=null);
        }

        public bool dellNode(int rollNo)
        {
            Node previous, current;
            previous =current = null;
        }


    }

















    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
