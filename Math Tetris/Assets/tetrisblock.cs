using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class tetrisblock : MonoBehaviour
{
    public float fallspeed = 2.0f;
    private float falltimer;
    private float currentfallspeed;
    public Vector3 Origin;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D down_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1f);
        RaycastHit2D right_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1f);
        RaycastHit2D left_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1f);


        if (Input.GetKeyDown(KeyCode.LeftArrow) && !left_hit)
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !right_hit)
        {
            transform.position += new Vector3(1, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentfallspeed = fallspeed / 10;
        }
        else
        {
            currentfallspeed = fallspeed;
        }

        if (!down_hit)
        {
            if ((Time.time - falltimer) > currentfallspeed)
            {
                transform.position += new Vector3(0, -1, 0);
                falltimer = Time.time;
            }
        }       

        if (Input.GetKeyDown(KeyCode.E) || transform.position.y < 0)
        {
            transform.position = Origin;
        }
        
    }
}
