using UnityEngine;

public class loadsettings : MonoBehaviour
{
    SettingsManager settings;
    void Start()
    {
        settings=FindObjectOfType<SettingsManager>();
        settings.loadsettings();
    }
}
