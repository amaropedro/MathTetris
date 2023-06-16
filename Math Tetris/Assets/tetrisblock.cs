using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class tetrisblock : MonoBehaviour
{
    public float fallspeed = 2.0f;
    private float falltimer;
    private float currentfallspeed;
    private bool enable = true;
    public TextMeshProUGUI text;

    private void Start()
    {
        text.text = UnityEngine.Random.Range(0, 9).ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if (enable)
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
                currentfallspeed = fallspeed / 20;
            }
            else
            {
                currentfallspeed = fallspeed;
            }


            if ((Time.time - falltimer) > currentfallspeed)
            {
                if (!down_hit)
                {
                    transform.position += new Vector3(0, -1, 0);
                    falltimer = Time.time;
                }
                else
                {
                    enable = false;
                    if (transform.position.y >= 18.5f)
                    {
                        //game over
                        print("game over");
                    }
                    else
                    {
                        StartCoroutine(SpawnerCoroutine());
                    }
                }
            }

        }
    }
    IEnumerator SpawnerCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<Spawner>().SpawnPiece();
    }
}
