using UnityEngine;

public class GameManager5 : MonoBehaviour
{
    private Tree<string> namesTree;

    BinaryTree<int> rootBinaryTree = new(1);
    void Start()
    {
        /*string tarversePre = "";
        namesTree.TraversePreOrder(namesTree.Root, v => 
        {
         tarversePre += v + ", ";
        });
        print(tarversePre);*/

        rootBinaryTree.AddChild(1, 2);
        rootBinaryTree.AddChild(1, 3);

        rootBinaryTree.AddChild(2, 4, true);
        rootBinaryTree.AddChild(2, 5, false);

        rootBinaryTree.AddChild(3, 6);

        rootBinaryTree.TraverseInOrder(rootBinaryTree.Root, v => Debug.Log(v));


    }


}