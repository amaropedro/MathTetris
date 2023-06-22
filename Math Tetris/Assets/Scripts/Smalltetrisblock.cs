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

    // Start is called before the first frame update
    void Start()
    {
        text.text = UnityEngine.Random.Range(0, 9).ToString();
    }

    // Update is called once per frame
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
    }

 
}
