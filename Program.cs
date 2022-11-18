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
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            //beginning of data
            if(current.next==null)
            {
                previous.next = null;
                return true;
            }
            //node between two nodes in he list
            if(current==START)
            {
                START = START.next;
                if(START != null)
                    START.prev= null;
                return true;
            }
            
            //if the to be deleted is in between the list then the following lines of is executed
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool listEmpty()
        {
            if (START== null)
                return true;
            else
                return false;
        }

        public void ascending()
        {
            if(listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\n Record in the ascending order of"+ "Roll Number are: \n");
                Node currentNode;
                for(currentNode = START;currentNode!=null; currentNode= currentNode.next)
                    Console.Write(currentNode.noMhs+ currentNode.name + "\n");
            }
        }

        public void descending()
        {
            if(listEmpty())
                Console.WriteLine("\n List is Empty");
            else
            {
                Console.WriteLine("\n Record in the Descending order of" + " Roll Number are: \n" );
                Node currentNode;
                //membawa currentnode ke node paling belakang
                currentNode= START;
                while(currentNode.next != null)
                {
                    currentNode= currentNode.next;
                }

                //membaca data dari last node ke first node
                while(currentNode!= null)
                {
                    Console.Write(currentNode.noMhs + " " + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }


    }



    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while(true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from to the list");
                    Console.WriteLine("3. View all record in the asceding order of roll number");
                    Console.WriteLine("4. View all record in  the descending order of roll number");
                    Console.WriteLine("5. Search for a record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.WriteLine("Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.WriteLine("\nEnter the roll number of the student" +
                                    "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + "deleted \n");
                            }
                            break;
                    }
                }
            }

        }
    }
}
