using UnityEngine;

public class GameManager3 : MonoBehaviour
{
    private Tree<string> namesTree;

    private void Start()
    {
        namesTree = new Tree<string>("Capac Yupanqui");

        namesTree.AddChild("Capac Yupanqui", "Curu Yaya");
        namesTree.AddChild("Capac Yupanqui", "Mayta Capac");

        namesTree.AddChild("Mayta Capac", "Mama Cura");
        namesTree.AddChild("Mayta Capac", "Lloque Yupanqui");

        namesTree.AddChild("Lloque Yupanqui", "Chimpu Urma");
        namesTree.AddChild("Lloque Yupanqui", "Sinchi Roca");

        namesTree.AddChild("Sinchi Roca", "Manco Cápac");
        namesTree.AddChild("Sinchi Roca", "Mama Ocllo");

        Debug.Log("Árbol de nombres (preorden):");
        namesTree.TraverPreOrder(namesTree.Root, v => Debug.Log(v));
    }
}
