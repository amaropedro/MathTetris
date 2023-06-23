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
    int res;
    Boolean res_already_added = true;
    Boolean is_Blocked = false;
    Expression_Control expression_Control;


    private void Awake()
    {
        /*  expression_Control = GameObject.Find("PeçaP").GetComponent<Expression_Control>();  */
        
    }

    // Start is called before the first frame update
    void Start()
    {
        

       /* res = UnityEngine.Random.Range(0, 9);
        expression_Control._Results.Add(res);// adiciona resultado da peça na lista
        text.text = res.ToString();  */
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D down_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1f);
        RaycastHit2D up_hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1f);

        if ((Time.time - falltimer) > fallspeed && !down_hit)
        {
            transform.position += new Vector3(0, -1, 0);
            falltimer = Time.time;
        }
        if (down_hit)
        {
            hasFallen = true;
            
        }


       /* if (hasFallen)
        {
            if (up_hit)// verifica se há uma outra peça pequena em cima dessa
            {
                is_Blocked = true; // no futuro, fazer com que is_Blocked = false quando a peça de cima é destruída
            }
            if (is_Blocked && res_already_added) // verifica se há uma outra peça pequena em cima dessa e se o resultado está na lista
            {
                expression_Control._Results.Remove(res);
                res_already_added = false;

            }
            if (!is_Blocked && !res_already_added)
            {
                expression_Control._Results.Add(res);
                res_already_added = true;
            } 
        } */
    }

 
}
