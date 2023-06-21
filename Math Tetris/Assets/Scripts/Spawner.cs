using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Piece;
    public GameObject SmallPiece;
    private float[] x_pos = {-4.5f, -3.5f, -2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, 3.5f, 4.5f, 5.5f};

    // Start is called before the first frame update
    void Start()
    {
        SpawnPiece();
        
        //quero melhorar isso pra pegar posições aleatorias dentre as possiveis
        for (int i = 0; i < 5; i++)
        {
            SpawnSamllPiece(new Vector3(x_pos[i], 3.5f, 0));
        }
    }

   public void SpawnPiece()
   {
        Instantiate(Piece);
   }

   public void SpawnSamllPiece(Vector3 position)
   {
        Instantiate(SmallPiece, position, new Quaternion());
   }
}
