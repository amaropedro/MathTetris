using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expression_Control : MonoBehaviour
{
    public static Expression_Control _instance;
    List<int> _Results = new List<int>();    

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
