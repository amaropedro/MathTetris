using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smalltetrisblock : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool hasFallen = false;
    public float fallspeed = 1.0f;
    private float falltimer;
    public int result;
    private bool res_already_added = true;

    void Start()
    {
        //Mudar esse range
        result = UnityEngine.Random.Range(1, 100);
        ExpressionControler._instance.addToList(result);
        text.text = result.ToString();
    }

    void Update()
    {
        RaycastHit2D down_hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);

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
            if (transform.position.y >= 16.5f)
            {
                SceneManager.LoadScene("GameOverScreen");
            }
            Collider2D up_hit = Physics2D.OverlapPoint(transform.position + new Vector3(0, 0.6f, 0));

            if (up_hit)
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), Vector2.up, Color.red, 0.5f);
                if (res_already_added)
                {         
                    if (up_hit.CompareTag("SmallBlock") && up_hit.gameObject != this.gameObject)
                    {
                        Debug.Log("Colided with" + up_hit + "Remove: " + result);
                        ExpressionControler._instance.removeFromList(result);
                        res_already_added = false;
                    }
                }
            }
            else 
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), Vector2.up, Color.blue, 0.5f);
                if (!res_already_added)
                {
                    Debug.Log("Nothing on top. Add: " + result);
                    ExpressionControler._instance.addToList(result);

                    res_already_added = true;
                }
            }
        }
    }
}
