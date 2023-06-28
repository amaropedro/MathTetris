using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Smalltetrisblock : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool hasFallen = false;
    public float fallspeed = 2.0f;
    private float falltimer;
    public int result;
    private bool res_already_added = true;

    void Start()
    {
        //Mudar esse range
        result = UnityEngine.Random.Range(0, 100);
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
            RaycastHit2D up_hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.TransformDirection(Vector2.up), 0.3f);

            if (up_hit)
            {
                if (res_already_added)
                {         
                    if (up_hit.collider.CompareTag("SmallBlock"))
                    {
                        //Debug.Log("Remove possibilidade se tem algo em cima: " + result);
                        ExpressionControler._instance.removeFromList(result);
                        res_already_added = false;
                    }
                }
            }
            else if (!res_already_added)
            {
                //Debug.Log("Adiciona possibilidade ACHO QUE SE O BLOCO DE CIMA SUMIU: " + result);
                ExpressionControler._instance.addToList(result);
                
                res_already_added = true;
            }
        }
    }
}
