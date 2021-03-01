using System;
using AlgorithmsDataStructures;

namespace Main
{
    class Program
    {
        public static string NodeToString(LinkedList t)
        {
            Node node = t.head;
            var text = new System.Text.StringBuilder();
            var counter = 0;
            text.Append($"List:\nHead:{t.head?.value}\nTail:{t.tail?.value}\n");
            while (node != null)
            {
                counter++;
                text.Append($"{counter} - {node.value}\n");
                node = node.next;
            }
            text.Append($"End. {counter} elements in list.");
            return text.ToString();
        }
        static void Main(string[] args)
        {
            var t = new LinkedList();
            var second_node = new Node(2);
            var first_node = new Node(1);
            t.AddInTail(first_node);
            t.AddInTail(second_node);

            t.Remove(2);

        }
    }
}
