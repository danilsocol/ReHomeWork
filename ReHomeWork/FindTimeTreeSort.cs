using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Numerics;
using System.Collections;

namespace ReHomeWork
{
    public class TreeNode
    {
        public TreeNode(int data)
        {
            Data = data;
        }

        //данные
        public int Data { get; set; }

        //левая ветка дерева
        public TreeNode Left { get; set; }

        //правая ветка дерева
        public TreeNode Right { get; set; }

        //рекурсивное добавление узла в дерево
        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }

        //преобразование дерева в отсортированный массив
        public int[] Transform(List<int> elements = null)
        {
            if (elements == null)
            {
                elements = new List<int>();
            }

            if (Left != null)
            {
                Left.Transform(elements);
            }

            elements.Add(Data);

            if (Right != null)
            {
                Right.Transform(elements);
            }

            return elements.ToArray();
        }
    }
    class FindTimeTreeSort
    {
        public static void TreeSort(int[] array, int count)
        {
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < count; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }
        }

    }
}
