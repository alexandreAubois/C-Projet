using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Isen.AuboisBouteille.Library
{
    public class Node<T>
        : INode<T>, IEquatable<Node<T>>
    {
        /// <summary>
        /// Question 2 :
        /// Propriétés de la classe Node qui représente un arbre
        /// </summary>
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
        
        /// <summary>
        /// Question 2 :
        /// Implémentation de l’égalité entre 2 nodes 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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

        #region Question3
        
        /// <summary>
        /// ajoute un enfant à un Node et met à jour le champ Parent du Node ajouté.
        /// </summary>
        /// <param name="node"></param>
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
        #endregion

        #region Question4
        /// <summary>
        /// Recherche un Node, selon son id en traversant l’arbre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Node<T> FindTraversing(Guid id)
        {
            Node<T> resu = new Node<T>();
            if (children == null)
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
        /// <summary>
        /// fonctionne de façon
        /// similaire, mais en utilisant Node.Equals
        /// </summary>
        /// <returns></returns>
        
        public Node<T> FindTraversing(Node<T> node)
        {
            Node<T> resu = new Node<T>();
            if (children == null)
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
        #endregion
        
        #region Question5    
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
        #endregion

        #region question7
        public JObject SerializeJson()
        {
            JObject json = new JObject();
            json.Add(new JProperty("value", value));
            JArray jChild = new JArray();
            if (children != null)
            {
                foreach (var child in children)
                {
                    if (child.children != null)
                    {
                        jChild.Add(child.SerializeJson());
                    }              
                }
            } 
            json.Add(new JProperty("children", jChild ));
            return json; 
        }

        public void DeserializeJson(JToken json)
        {
            value = json["value"].ToObject<T>();

            foreach (var jChild in json["children"])
            {
                Node<T> child = new Node<T>();
                child.DeserializeJson(jChild);
                AddChildNode(child);
            }
        }
        
        #endregion

       
    }
    
    


}