using System.Collections.Generic;
using UnityEngine;

public class CustomHashTable<TKey, TValue>
{
    private List<KeyValuePair<TKey, TValue>>[] buckets;
    private int capacity;

    public CustomHashTable(int capacity = 10)
    {
        this.capacity = Mathf.Max(1, capacity);
        buckets = new List<KeyValuePair<TKey, TValue>>[this.capacity];
    }

    private int GetBucketIndex(TKey key)
    {
        int hash = key.GetHashCode();
        return Mathf.Abs(hash % capacity);
    }

    public void Add(TKey key, TValue value)
    {
        int idx = GetBucketIndex(key);
        if (buckets[idx] == null)
            buckets[idx] = new List<KeyValuePair<TKey, TValue>>();
        buckets[idx].Add(new KeyValuePair<TKey, TValue>(key, value));
        Debug.Log($"Added: {key} -> {value} (Bucket {idx})");
    }

    public bool Get(TKey key, out TValue value)
    {
        value = default;
        int idx = GetBucketIndex(key);
        if (buckets[idx] != null)
        {
            foreach (var pair in buckets[idx])
            {
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    Debug.Log($"Found: {key} -> {value}");
                    return true;
                }
            }
        }
        Debug.Log($"Not found: {key}");
        return false;
    }

    public void Remove(TKey key)
    {
        int idx = GetBucketIndex(key);
        if (buckets[idx] != null)
        {
            int removed = buckets[idx].RemoveAll(pair => pair.Key.Equals(key));
            if (removed > 0)
                Debug.Log($"Removed: {key}");
        }
    }

    public bool ContainsKey(TKey key)
    {
        TValue v;
        return Get(key, out v);
    }

    public void PrintDistribution()
    {
        Debug.Log("BUCKET DISTRIBUTION:");
        for (int i = 0; i < capacity; i++)
        {
            int count = buckets[i]?.Count ?? 0;
            Debug.Log($"Bucket {i}: {count} items");
        }
    }
}
