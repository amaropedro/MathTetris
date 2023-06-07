using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Edge : MonoBehaviour
{
    public static Right_Edge _instance;
    public BoxCollider2D area;
    public bool touching_edge;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("GameObject1 collided with " + collision.name);
        print("here");
        touching_edge = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("out");
        touching_edge = false;
    }
}
