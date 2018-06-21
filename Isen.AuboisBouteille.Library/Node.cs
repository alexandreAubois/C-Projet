﻿using System;
using System.Collections.Generic;

namespace Isen.AuboisBouteille.Library
{
    public class Node
        : INode, IEquatable<Node>
    {
        public string value { get; set; }
        public Guid id { get; }
        public Node parent { get; set; }
        public List<Node> children { get; set; }
        public int depth { get; }

        public bool Equals(Node other)
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
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((value != null ? value.GetHashCode() : 0) * 397) ^ id.GetHashCode();
            }
        }

        public void AddChildNode(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public void AddNodes(IEnumerable<Node> nodeList)
        {
            foreach (var myVar in nodeList)
            {
                AddChildNode(myVar);
            }
        }

        public void RemoveChildNode(Guid id)
        {
            foreach (var myVar in children)
            {
                if (myVar.id == id)
                {
                    children.Remove(myVar);
                }
            }
        }

        public void RemoveChildNode(Node node)
        {
            foreach (var myVar in children)
            {
                if (node.Equals(myVar))
                {
                    children.Remove(myVar);
                }
            }
        }
    }



}