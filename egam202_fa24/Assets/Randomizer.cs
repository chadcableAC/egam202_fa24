using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomzier : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public string student;
        public bool isPresent;
    }

    public Data[] datas;
    public bool isPlaytesting;

    void Start()
    {
        Randomize();        
    }

    private void Randomize()
    {
        // Build the list of present students
        List<Data> finalDatas = new();
        foreach (Data data in datas)
        {
            if (data.isPresent)
            {
                finalDatas.Add(data);
            }
        }

        // Randomize
        Shuffle(finalDatas);

        // Spell out the order        
        string output = string.Empty;

        for (int i = 0; i < finalDatas.Count; i++)
        {
            output += $"{i + 1}: {finalDatas[i].student}\n";

            if (isPlaytesting)
            {
                int adjIndex = (i + 1) % finalDatas.Count;
                output += $"-> playtested by: {finalDatas[adjIndex].student}\n";
            }

            output += "\n";
        }

        Debug.Log(output);
    }

    public void Shuffle<T>(IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}