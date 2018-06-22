using System;
using System.Collections.Generic;

namespace Isen.AuboisBouteille.Library
{
    public interface INode<T>
    {
        T value { get; set; }
        Guid id { get; }
        Node<T> parent { get; set; }
        List<Node<T>> children { get; set; }
        int depth { get; }

        void AddChildNode(Node<T> node);
        void AddNodes(IEnumerable<Node<T>> nodeList);
        void RemoveChildNode(Guid id);
        void RemoveChildNode(Node<T> node);
        Node<T> FindTraversing(Guid id);
        Node<T> FindTraversing(Node<T> node);
    }
    
    
}