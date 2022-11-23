using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe3_M.Yoga_Prasetya_Erlangga_012
{
    class Node
    {
        /*creates nodes for the circilar nexted list*/
        public int studentnumber;
        public string studentname;
        public Node next;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }

        public bool Search(int studentNo, ref Node previous, ref Node current)
        /*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current,
                current = current.next)
            {
                if (studentNo == current.studentnumber)
                    return (true); /*returns true if the node is  found*/
            }
            if (studentNo == LAST.studentnumber)/*if the node is present at the end*/
                return true;
            else
                return (false); /*returns false if the node is not found*/
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        public void traverse() /*Traverses all the nodes of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nLsit is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are : \n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.studentnumber + "   " +
                        currentNode.studentname + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.studentnumber + "    " + LAST.studentname + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is : \n\n " +
                    LAST.next.studentnumber + "    " + LAST.next.studentname);
        }
        public bool deleteNode( int studentNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(studentNo, ref previous, ref current) == false)
                return false;
            if (studentNo == LAST.next.studentnumber)
            {
                current = LAST.next;
                LAST.next = current.next;
                return true;
            }
            if (studentNo == LAST.studentnumber)
            {
                current = LAST;
                previous = current.next;
                while (previous.next != LAST)
                    previous = previous.next;
                previous.next = LAST.next;
                LAST = previous;
                return true;
            }
            if (studentNo <= LAST.studentnumber)
            {
                current = LAST.next;
                previous = LAST.next;
                while (studentNo > current.studentnumber || previous == LAST)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = current.next;
            }
            return true;
        }
        public void insertNode()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter the name of the student");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.studentnumber = nim;
            newNode.studentname = nm;

            if (LAST == null || nim <= LAST.studentnumber)
            {
                if ((LAST != null) && (nim == LAST.studentnumber))
                {
                    Console.WriteLine();
                    return;
                }
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            Node previous, current;
            previous = LAST.next;
            current = LAST.next;

            while ((current != null) && (nim >= current.studentnumber))
            {
                if (nim == current.studentnumber)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newNode;
            }
            newNode.next = LAST.next;
            LAST.next = newNode;
        }
    }
}
