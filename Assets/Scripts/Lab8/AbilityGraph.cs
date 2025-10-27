using System.Collections.Generic;
using UnityEngine;

public class AbilityGraph
{
    private Dictionary<string, Node<Habilidad>> nodes = new Dictionary<string, Node<Habilidad>>();
    private Dictionary<string, HashSet<string>> connections = new Dictionary<string, HashSet<string>>();

    public void AddAbility(Habilidad habilidad)
    {
        if (!nodes.ContainsKey(habilidad.Nombre))
        {
            nodes[habilidad.Nombre] = new Node<Habilidad>(habilidad);
            connections[habilidad.Nombre] = new HashSet<string>();
            Debug.Log($"Added ability: {habilidad}");
        }
    }

    public void Connect(string nombreA, string nombreB)
    {
        if (nodes.ContainsKey(nombreA) && nodes.ContainsKey(nombreB))
        {
            connections[nombreA].Add(nombreB);
            connections[nombreB].Add(nombreA);
            Debug.Log($"Connected {nombreA} <-> {nombreB}");
        }
    }

    public void PrintAbilities()
    {
        Debug.Log("Abilities in graph:");
        foreach (var kv in nodes)
        {
            Debug.Log(kv.Value.Value.ToString());
        }
    }

    public void PrintConnections()
    {
        Debug.Log("Ability connections:");
        foreach (var kv in connections)
        {
            string line = kv.Key + " <-> ";
            foreach (var conn in kv.Value)
                line += conn + ", ";
            Debug.Log(line.TrimEnd(',', ' '));
        }
    }

    public Node<Habilidad> GetNode(string nombre)
    {
        nodes.TryGetValue(nombre, out var node);
        return node;
    }
}