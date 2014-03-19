using System;
using System.Collections;
using System.Collections.Generic;

namespace PatternLibrary
{
    class NodeEnumerator : IEnumerator
    {
        int enumeratorPosition;
        private List<Node> nodeCollection;

        public NodeEnumerator(List<Node> nodeCollection)
        {
            this.nodeCollection = nodeCollection;
            Reset();
        }

        public Node Current
        {
            get
            {
                Node node = null;

                try
                {
                    node = nodeCollection[enumeratorPosition];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }

                return node;
            }
        }

        Object IEnumerator.Current          { get { return Current; } }

        public void Reset()
        {
            this.enumeratorPosition = -1;
        }

        public bool MoveNext()
        {
            return (this.enumeratorPosition++ < nodeCollection.Count);
        }
    }

    public class Node : IEnumerable
    {
        private List<Node> nodeCollection;
        public String Name { get; set; }

        public Node()
        {
            nodeCollection = new List<Node>();
        }

        public Node(string name) : this()
        {
            Name = name;
        }

        public List<Node> Nodes { get { return nodeCollection; } }

        public void Add(Node node)
        {
            nodeCollection.Add(node);
        }

        public void AddRange(Node[] nodes)
        {
            nodeCollection.AddRange(nodes);
        }

        private NodeEnumerator GetEnumerator()
        {
            return new NodeEnumerator(nodeCollection);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
