/******************************************************************************
Лаб 17 - 30.05.25 - бинарное дерево
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace BinaryTree
{
    unsafe class ProductTree
    {
        struct Node
        {
            public int id;
            public string name;
            public Node* left;
            public Node* right;
            public Node(int id, string name)
            {
                this.id = id;
                this.name = name;
                left = null;
                right = null;
            }
            public void Print() => Console.WriteLine($"{id} {name}");
        }
        struct BinaryTree
        {
            public Node* head;

            public void Add(int id, string name)
            {
                Node* newNode = (Node*)Marshal.AllocHGlobal(sizeof(Node));
                *newNode = new Node(id, name);
                if (head == null) 
                {
                    head = newNode;
                    return;
                }
                Node* current = head; 
                while (true)
                {
                    if (newNode->id < current->id)
                    {
                        if (current->left == null)
                        {
                            current->left = newNode;
                            break;
                        }
                        current = current->left;
                    }
                    else
                    {
                        if (current->right == null)
                        {
                            current->right = newNode;
                            break;
                        }
                        current = current->right;
                    }
                }
            }
            public void PrintTree()
            {
                if (head == null) return;

                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(*head); 
                while (queue.Count != 0)
                {
                    var currentNode = queue.Dequeue();
                    currentNode.Print();
                    if (currentNode.left != null) queue.Enqueue(*(currentNode.left));
                    if (currentNode.right != null) queue.Enqueue(*(currentNode.right));
                }
            }
        }
        static void Main()
        {
            BinaryTree tree = new BinaryTree();
            tree.Add(9, "Вода");
            tree.Add(21, "Молоко");
            tree.Add(18, "Сок");
            tree.Add(3, "Чай");
            tree.Add(25, "Кофе");
            tree.PrintTree();
        }
    }
}