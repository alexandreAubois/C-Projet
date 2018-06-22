using System;
using Isen.AuboisBouteille.Library;

namespace Isen.AuboisBouteille.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {    
            Node item1 = new Node();
            Node item11 = new Node();
            Node item111 = new Node();
            Node item1111 = new Node();
            Node item112 = new Node();
            Node item1121 = new Node();
            Node item1122 = new Node();
            Node item113 = new Node();
            Node item12 = new Node();
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
