using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] string additionalText;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void OnDisable()
    {
        PlayerManager.OnCollected -= PlayerManager_OnCollected;
    }

    void OnEnable()
    {
        PlayerManager.OnCollected += PlayerManager_OnCollected;
    }

    void PlayerManager_OnCollected(int amount)
    {
        GameManager.score += amount;
        text.text = additionalText + GameManager.score;
    }
}
