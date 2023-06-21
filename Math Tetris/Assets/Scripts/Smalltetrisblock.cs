using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Smalltetrisblock : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = UnityEngine.Random.Range(0, 9).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
