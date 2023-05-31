using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrisblock : MonoBehaviour
{
    public float fallspeed = 2.0f;
    private float falltimer;
    private float currentfallspeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) //GetKeyDown é toda vez que for precionado, se segurar não faz nada
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            transform.position += new Vector3(1,0, 0);
        }

        if(Input.GetKey(KeyCode.DownArrow)) //GetKey é enquanto estiver precionado, pode segurar
        {
            currentfallspeed = fallspeed/10;
        }
        else
        {
            currentfallspeed = fallspeed;
        }

        if ((Time.time - falltimer) > currentfallspeed)
        {
            transform.position += new Vector3(0, -1, 0);
            falltimer = Time.time;
        }

        if(transform.position.y < 0) //eu coloquei a camera pra acabar em 0, então toda vez que sai da camera volta pra origem. só por enquanto
        {
            transform.position = new Vector3(0, 13, 0);
        }

    }
}
