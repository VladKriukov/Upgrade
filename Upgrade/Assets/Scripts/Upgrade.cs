using UnityEngine;

public class Upgrade : MonoBehaviour
{

    [SerializeField] int requredAmount;

    public bool CanUpgrade()
    {
        if (GameManager.score >= requredAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
