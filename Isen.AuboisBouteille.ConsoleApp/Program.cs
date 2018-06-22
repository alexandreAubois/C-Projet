using System;
using System.Xml.XPath;
using Isen.AuboisBouteille.Library;

namespace Isen.AuboisBouteille.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var item1 = new Node<string>();
            var item11 = new Node<string>();
            var item111 = new Node<string>();
            var item1111 = new Node<string>();
            var item112 = new Node<string>();
            var item1121 = new Node<string>();
            var item1122 = new Node<string>();
            var item113 = new Node<string>();
            var item12 = new Node<string>();
            item1.value = "Item1";
            item11.value = "Item11";
            item111.value = "Item111";
            item1111.value = "Item1111";
            item112.value = "Item112";
            item1121.value = "Item1121";
            item1122.value = "Item1122";
            item113.value = "Item113";
            item12.value = "Item12";
            item1.AddChildNode(item11);
            item11.AddChildNode(item111);
            item111.AddChildNode(item1111);
            item11.AddChildNode(item112);
            item112.AddChildNode(item1121);
            item112.AddChildNode(item1122);
            item11.AddChildNode(item113);
            item1.AddChildNode(item12);
            item1.ToString();
            //item11.AddChildNode(item);
          
        }
    }
}
