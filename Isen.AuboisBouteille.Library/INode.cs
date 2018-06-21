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
        
        
    }
    
    
}