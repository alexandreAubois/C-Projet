using System;
using System.Collections.Generic;

namespace Isen.AuboisBouteille.Library
{
    public interface INode
    {
        string value { get; set; }
        Guid id { get; }
        Node parent { get; set; }
        List<Node> children { get; set; }
        int depth { get; }

        void AddChildNode(Node node);
        void AddNodes(IEnumerable<Node> nodeList);
        void RemoveChildNode(Guid id);
        void RemoveChildNode(Node node);
        Node FindTraversing(Guid id);
        Node FindTraversing(Node node);
    }
    
    
}