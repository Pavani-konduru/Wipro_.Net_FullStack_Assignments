using System;

public class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
    public TreeNode(int value = 0, TreeNode left = null, TreeNode right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}
public class BinaryTree
{
    public static TreeNode CreateTreeFromArray(int[] elements)
    {
        if (elements == null || elements.Length == 0)
            return null;

        return CreateTreeFromArray(elements, 0);
    }
    private static TreeNode CreateTreeFromArray(int[] elements, int index)
    {
        if (index >= elements.Length || elements[index] == -1)
            return null;

        TreeNode node = new TreeNode(elements[index]);
        node.Left = CreateTreeFromArray(elements, 2 * index + 1);
        node.Right = CreateTreeFromArray(elements, 2 * index + 2);
        return node;
    }
    public static bool IsBalanced(TreeNode root)
    {
        return CheckHeight(root) != -1;
    }

    private static int CheckHeight(TreeNode node)
    {
        if (node == null)
            return 0;

        int leftHeight = CheckHeight(node.Left);
        int rightHeight = CheckHeight(node.Right);

        if (leftHeight == -1 || rightHeight == -1)
            return -1;

        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -1;

        return Math.Max(leftHeight, rightHeight) + 1;
    }
    public static void PrintInOrder(TreeNode node)
    {
        if (node == null)
            return;

        PrintInOrder(node.Left);
        Console.Write(node.Value + " ");
        PrintInOrder(node.Right);
    }
}

public class Balanced_Tree_program
{
    public static void Main()
    {
        int[] elements = { 10,30,40,30,50,20,60,75,65,55,87 };
        TreeNode tree = BinaryTree.CreateTreeFromArray(elements);
        bool isBalanced = BinaryTree.IsBalanced(tree);
        Console.Write("Tree elements: ");
        BinaryTree.PrintInOrder(tree);
        Console.WriteLine();
        Console.WriteLine($"Is the tree is balanced: {isBalanced}");
    }
}