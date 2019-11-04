using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresFundamental
{
    public class DynamicList<T>
    {
        private class ListNode
        { 
            public T Element { get; set; }
            public ListNode NextNode { get; set; }

            public ListNode(T element)
            {
                this.Element = element;
                NextNode = null;
            }

            public ListNode(T element, ListNode prevNode)
            {
                this.Element = element;
                prevNode.NextNode = this;
            }
        }

        private ListNode head;
        private ListNode tail;
        private int count;

        public DynamicList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void Add(T item)
        {            
            if (this.head == null)
            {
                // We have an empty list -> create a new head and tail
                this.head = new ListNode(item);
                this.tail = this.head;
            }
            else
            {
                // We have a non-empty list -> append the item after tail
                ListNode newNode = new ListNode(item, this.tail);
                this.tail = newNode;
            }
            this.count++;
        }

        public T RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: "+index);
            }

            int currentIndex = 0;
            ListNode currentNode = this.head;
            ListNode prevNode = null;
            while (currentIndex < index)
            {
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            RemoveListNode(currentNode,prevNode);

            return currentNode.Element;
        }

        private void RemoveListNode(ListNode node, ListNode prevNode)
        {
            count--;
            if (count ==0)
            {
                this.head = null;
                this.tail = null;
            }
            else if (prevNode == null)
            {
                this.head = node.NextNode;
            }
            else
            {
                prevNode.NextNode = node.NextNode;
            }

            if (object.ReferenceEquals(this.tail, node))
                this.tail = prevNode;
        }

        public int Remove(T item)
        {
            int currentIndex = 0;
            ListNode currentNode = this.head;
            ListNode prevNode = null;
            while (currentNode!=null)
            {
                if (object.Equals(currentNode.Element, item))
                    break;

                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            if (currentNode != null)
            {
                RemoveListNode(currentNode, prevNode);
                return currentIndex;
            }
            else
            {
                return -1;
            }
        }

        public int IndexOf(T item)

        {

            int index = 0;

            ListNode currentNode = this.head;

            while (currentNode != null)

            {

                if (object.Equals(currentNode.Element, item))

                {

                    return index;

                }

                currentNode = currentNode.NextNode;

                index++;

            }

            return -1;

        }



        /// <summary>

        /// Checks if the specified element exists in the list

        /// </summary>

        /// <param name="item">The item to be checked</param>

        /// <returns>

        /// True if the element exists or false otherwise

        /// </returns>

        public bool Contains(T item)

        {

            int index = IndexOf(item);

            bool found = (index != -1);

            return found;

        }

        /// <summary>

        /// Gets or sets the element at the specified position

        /// </summary>

        /// <param name="index">

        /// The position of the element [0 … count-1]

        /// </param>

        /// <returns>The item at the specified index</returns>

        /// <exception cref="System.ArgumentOutOfRangeException">

        /// When an invalid index is specified

        /// </exception>

        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

                ListNode currentNode = this.head;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }
                return currentNode.Element;
            }

            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

                ListNode currentNode = this.head;

                for (int i = 0; i < index; i++)                    
                {
                    currentNode = currentNode.NextNode;
                }
                currentNode.Element = value;
            }
        }
               
        /// <summary>
        /// Gets the count of elements in the list
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
        }

    }
}
