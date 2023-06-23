using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Smalltetrisblock : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool hasFallen = false;
    public float fallspeed = 2.0f;
    private float falltimer;
    private int result;
    private bool res_already_added = true;

    void Start()
    {
        result = UnityEngine.Random.Range(0, 9);
        ExpressionControler._instance.addToList(result);
        text.text = result.ToString();
    }

    void Update()
    {
        RaycastHit2D down_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1f);

        if ((Time.time - falltimer) > fallspeed && !down_hit)
        {
            transform.position += new Vector3(0, -1, 0);
            falltimer = Time.time;
        }

        if (down_hit)
        {
            hasFallen = true;
        }

        if (hasFallen)
        {
            RaycastHit2D up_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1f);

            if (up_hit)
            {
                if (res_already_added)
                {
                    ExpressionControler._instance.removeFromList(result);
                    res_already_added = false;
                }
            }
            else if (!res_already_added)
            {
                ExpressionControler._instance.addToList(result);
                res_already_added = true;
            }
        }
    }
}
