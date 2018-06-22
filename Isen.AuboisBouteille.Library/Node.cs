using System;
using System.Collections.Generic;
using System.Linq;

namespace Isen.AuboisBouteille.Library
{
    public class Node<T>
        : INode<T>, IEquatable<Node<T>>
    {
        public T value { get; set; }
        public Guid id { get; }
        public Node<T> parent { get; set; }
        public List<Node<T>> children { get; set; }

        public int depth => parent?.depth + 1 ?? 0;

        public Node()
        {
            children = new List<Node<T>>();
            id = new Guid();
            parent = null;
            value = default(T);
        }    

        public bool Equals(Node<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(value, other.value) && id.Equals(other.id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((value != null ? value.GetHashCode() : 0) * 397) ^ id.GetHashCode();
            }
        }

        public void AddChildNode(Node<T> node)
        {
            node.parent = this;
            children.Add(node);
        }

        public void AddNodes(IEnumerable<Node<T>> nodeList)
        {
            foreach (var myVar in nodeList)
            {
                AddChildNode(myVar);
            }
        }

        public void RemoveChildNode(Guid id)
        {
            foreach (var myVar in children.ToList())
            {
                if (myVar.id == id)
                {
                    children.Remove(myVar);
                }
            }
        }

        public void RemoveChildNode(Node<T> node)
        {
            foreach (var myVar in children.ToList())
            {
                if (node.Equals(myVar))
                {
                    children.Remove(myVar);
                }
            }
        }

        public Node<T> FindTraversing(Guid id)
        {
            Node<T> resu = new Node<T>();
            if(children == null)
            {
                return null;
            }
            foreach (var child in children)
            {
                if (id == child.id)
                {
                    return child;
                } 
                else
                {
                    resu = child.FindTraversing(id);
                }

                if (resu != null)
                {
                    return resu;
                }
            }
            return null;
        }

        public Node<T> FindTraversing(Node<T> node)
        {
            Node<T> resu = new Node<T>();
            if(children == null)
            {
                return null;
            }
            foreach (var child in children)
            {
                if (node.Equals(child))
                {
                    return child;
                } 
                else
                {
                    resu = child.FindTraversing(node);
                }

                if (resu != null)
                {
                    return resu;
                }
            }
            return null;
        }

        public override string ToString()
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write("|-");
            }
            Console.Write(value);
            Console.WriteLine("{" + id + "}");
            foreach (var child in children)
            {
                if (children != null)
                {
                    child.ToString();

                }
            }
            return base.ToString();
        }

    }



}