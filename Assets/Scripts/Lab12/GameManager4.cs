using UnityEngine;
public class GameManager4 : MonoBehaviour
{
    private Tree2<string> namesTree;
    private string traversePreOrder = "";
    private string traversePostOrder = "";
    private string traverseLevelOrder = "";
    private void Start()
    {
        namesTree = new Tree2<string>("Willard Carroll Smith");
        namesTree.AddChild("Willard Carroll Smith", "Will Smith");
        namesTree.AddChild("Will Smith", "Trey Smith");
        namesTree.AddChild("Will Smith", "Jaden Smith");
        namesTree.AddChild("Will Smith", "Willow Smith");
        Debug.Log("Árbol de nombres (pre orden):");
        namesTree.TraversePreOrder(namesTree.Root, v => traversePreOrder += v + ", ");
        Debug.Log(traversePreOrder);
        Debug.Log("Árbol de nombres (post orden):");
        namesTree.TraversePostOrder(namesTree.Root, v => traversePostOrder += v + ", ");
        Debug.Log(traversePostOrder);
        Debug.Log("Árbol de nombres (level orden):");
        namesTree.TraverseLevelOrder(namesTree.Root, v => traverseLevelOrder += v + ", ");
        Debug.Log(traverseLevelOrder);
    }
}