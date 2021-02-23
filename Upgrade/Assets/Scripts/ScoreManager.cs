using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private string additionalText;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void OnDisable()
    {
        PlayerManager.OnCollected -= PlayerManager_OnCollected;
    }

    private void OnEnable()
    {
        PlayerManager.OnCollected += PlayerManager_OnCollected;
    }

    private void PlayerManager_OnCollected(int amount)
    {
        GameManager.score += amount;
        text.text = additionalText + GameManager.score;
    }
}