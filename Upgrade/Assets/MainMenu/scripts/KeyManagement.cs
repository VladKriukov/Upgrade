using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManagement : MonoBehaviour
{
    public int keys = 0;
    public Text keytext;
    public void keypickup()
    {
        keys = keys + 1;
        keytext.text = keys.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        keytext.text = keys.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
