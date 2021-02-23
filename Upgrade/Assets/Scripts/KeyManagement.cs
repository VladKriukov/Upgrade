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

    private void Start()
    {
        keytext.text = keys.ToString();
    }
}