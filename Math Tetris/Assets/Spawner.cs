using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Piece;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPiece();
    }

   public void SpawnPiece()
    {
        Instantiate(Piece);
    }
}
