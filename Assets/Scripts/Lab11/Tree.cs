using System;
using System.Collections.Generic;
using UnityEngine;

public class Tree<T>
{
    public TreeNode<T> Root;

    public Tree(T rootValue)
    {
        Root = new TreeNode<T>(rootValue);
    }

    public TreeNode<T> Find(TreeNode<T> node, T value)
    {
        if (node == null) return null;

        //-> comparacion
        if (EqualityComparer<T>.Default.Equals(node.Value, value)) return node;

        //-> Si fallo realizo la busqueda
        foreach (TreeNode<T> child in node.Children)
        {
            TreeNode<T> result = Find(child, value);
            if (result != null) return result;
        }
        return null;
    }

    //-> No deberian por definicion tener un metodo addchild

    public bool AddChild(T parentValue, T childValue)
    {
        TreeNode<T> parentNode = Find(Root, parentValue);
        if (parentNode == null)
        {
            Debug.Log("El nodo que buscas no se encuentra en el arbol");
            return false;
        }
        TreeNode<T> childNode = new(childValue);

        parentNode.AddChild(childNode);
        return true;
    }

    public void TraverPreOrder(TreeNode<T> node, Action<T> action)
    {
        if (node == null) return;
        action(node.Value);

        foreach (var child in node.Children)
        {
            TraverPreOrder(child, action);
        }
    }
}
