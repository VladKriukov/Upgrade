using UnityEngine;

public class LivesManager : MonoBehaviour
{
    private GameObject lifeSprite;

    private int children;
    private int index;

    private void Start()
    {
        lifeSprite = Resources.Load("Life") as GameObject;
        if (transform.childCount < GameManager.playerHealth)
        {
            children = transform.childCount;
            for (int i = 0; i < GameManager.playerHealth - children; i++)
            {
                Instantiate(lifeSprite, transform);
            }
        }
    }

    private void OnDisable()
    {
        PlayerManager.OnDie -= PlayerManager_OnDie;
    }

    private void OnEnable()
    {
        PlayerManager.OnDie += PlayerManager_OnDie;
    }

    private void PlayerManager_OnDie()
    {
        transform.GetChild(index).gameObject.SetActive(false);
        index++;
    }
}