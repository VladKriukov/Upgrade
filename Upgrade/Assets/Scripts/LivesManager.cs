using UnityEngine;

public class LivesManager : MonoBehaviour
{

    GameObject lifeSprite;

    int children;
    int index;

    void Start()
    {
        lifeSprite = Resources.Load("Life") as GameObject;
        if (transform.childCount < GameManager.lives)
        {
            children = transform.childCount;
            for (int i = 0; i < GameManager.lives - children; i++)
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
