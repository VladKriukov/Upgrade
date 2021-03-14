using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadsettings : MonoBehaviour
{
    SettingsManager settings;
    // Start is called before the first frame update
    void Start()
    {
        settings=FindObjectOfType<SettingsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        settings.loadsettings();
    }
}
