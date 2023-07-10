using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionControler : MonoBehaviour
{
    public List<int> results = new List<int>();

    public static ExpressionControler _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void addToList(int value)
    {
        results.Add(value);
    }

    public void removeFromList(int value) 
    {
        results.Remove(value);
    }

    public int chooseRandomResult()
    {
        int choice;
        choice = UnityEngine.Random.Range(0, results.Count);
        return results[choice];
    }

    //debug function
    public void printAllCurrentOptions()
    {
        foreach (int value in results)
        {
            Debug.Log(value);
        }
        Debug.Log("----");
    }
}
