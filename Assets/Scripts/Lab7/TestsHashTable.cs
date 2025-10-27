using System.Collections.Generic;
using UnityEngine;

public class TestsHashTable : MonoBehaviour
{
    void Start()
    {
        Test1_IntegerKeysToNames();
        Test2_StringKeysToGameObjects();
        Test3_ForceCollisions();
        Test4_DifferentSizes();
        Test5_RemoveAndVerify();
        Test6_CompareWithDictionary();
    }

    void Test1_IntegerKeysToNames()
    {
        Debug.Log("TEST 1: Integer keys to names");
        var table = new CustomHashTable<int, string>(5);
        table.Add(1, "Apple");
        table.Add(2, "Banana");
        table.Add(3, "Cherry");
        table.Add(4, "Date");
        table.Get(2, out _);
        table.Get(5, out _);
        table.PrintDistribution();
    }

    void Test2_StringKeysToGameObjects()
    {
        Debug.Log("TEST 2: String keys to GameObjects");
        var table = new CustomHashTable<string, GameObject>(5);
        table.Add("Car", new GameObject("CarObject"));
        table.Add("Tree", new GameObject("TreeObject"));
        table.Add("House", new GameObject("HouseObject"));
        table.Get("Car", out GameObject found);
        if (found != null) Debug.Log("Found GameObject: " + found.name);
        table.Get("River", out _);
        table.PrintDistribution();
    }

    void Test3_ForceCollisions()
    {
        Debug.Log("TEST 3: Force collisions");
        var table = new CustomHashTable<int, string>(3);
        table.Add(2, "Red");
        table.Add(5, "Green");
        table.Add(8, "Blue");
        table.PrintDistribution();
    }

    void Test4_DifferentSizes()
    {
        Debug.Log("TEST 4: Different table sizes");
        var small = new CustomHashTable<int, string>(3);
        var large = new CustomHashTable<int, string>(10);
        for (int i = 0; i < 5; i++)
        {
            small.Add(i, $"animal{i}");
            large.Add(i, $"animal{i}");
        }
        Debug.Log("Small table:");
        small.PrintDistribution();
        Debug.Log("Large table:");
        large.PrintDistribution();
    }

    void Test5_RemoveAndVerify()
    {
        Debug.Log("TEST 5: Remove elements");
        var table = new CustomHashTable<string, int>(5);
        table.Add("Cat", 10);
        table.Add("Dog", 20);
        table.Remove("Cat");
        if (!table.Get("Cat", out int val))
            Debug.Log("'Cat' was removed correctly");
    }

    void Test6_CompareWithDictionary()
    {
        Debug.Log("TEST 6: Compare with Dictionary");
        var myTable = new CustomHashTable<string, string>(5);
        var dict = new Dictionary<string, string>();
        myTable.Add("city", "London");
        dict.Add("city", "London");
        myTable.Get("city", out string myVal);
        string dictVal = dict["city"];
        Debug.Log($"MyHashTable: {myVal}");
        Debug.Log($"Dictionary: {dictVal}");
    }
}
