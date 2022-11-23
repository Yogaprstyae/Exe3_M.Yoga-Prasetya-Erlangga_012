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
    }
}
