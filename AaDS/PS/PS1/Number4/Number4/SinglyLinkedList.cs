using System.Collections;
using System.Collections.Generic;

namespace Number4
{
    public class Node
    {
        public Node(Konj data)
        {
            Data = data;
        }

        public Konj Data { get; set; }
        public Node Next { get; set; }
    }

    public class SinglyLinkedList : IEnumerable
    {
        public Node Head;
        public Node Tail;

        public void Add(Konj data)
        {
            Node node = new Node(data);

            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
            }
            Tail = node;
            Count++;
        }

        public bool Contains(Konj data)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }


        public int Count { get; set; }

        public bool IsEmpty => Count == 0;

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public Node this[int index]
        {
            get
            {
                var current = Head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current;
            }
        }

        public IEnumerator<Node> GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
