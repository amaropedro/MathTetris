using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject Piece;
    public GameObject SmallPiece;

    public static Spawner _instance;
   

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

    void Start()
    {
        StartCoroutine(SpawnCoroutine(70));
    }

    private IEnumerator SpawnCoroutine(int chance)
    {
        SpawnSmallPieces(chance);
        yield return new WaitForSeconds(1.5f);
        SpawnPiece();
    }

   public void SpawnPiece()
   {
        Instantiate(Piece);
   }

   public void SpawnSmallPieces(int chance)
   {
        //bool isFalling = true;
        bool hasAtLeatOneSpawned = false;
        float[] x_pos = {-3.5f, -2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f};
        List<Smalltetrisblock> allSmallPieces = new List<Smalltetrisblock>();


        foreach (float i in x_pos)
        {
            if (UnityEngine.Random.Range(0, 100) <= chance)
            {
                hasAtLeatOneSpawned = true;
                //criar uma lista allsmallpieces e colocar cada instancia na lista
                //a intenção é no futuro verificar se as peças atingiram o chão
                allSmallPieces.Add(Instantiate(SmallPiece, new Vector3(i, 18.5f, 0), new Quaternion()).GetComponent<Smalltetrisblock>());
            }

        }
        if (!hasAtLeatOneSpawned)
        {
            allSmallPieces.Add(Instantiate(SmallPiece, new Vector3(0.5f, 18.5f, 0), new Quaternion()).GetComponent<Smalltetrisblock>());
        }
        
        //Talvez com o 'new WaitWhile()' funcione
        // Smalltetrisblock[] allSmallPieces = FindObjectsOfType<Smalltetrisblock>();
        // while (isFalling)
        // {
        //     print("helo");
        //     isFalling = false;
        //     foreach (Smalltetrisblock smallpiece in allSmallPieces)
        //     {
        //         print(smallpiece.hasFallen);
        //         if (!smallpiece.hasFallen)
        //         {
        //             isFalling = true;
        //         }
        //     }
        // }

        //return true;
    }
}