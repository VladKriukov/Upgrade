using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private string additionalText;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        UpdateScore();
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
        UpdateScore();
    }

    void UpdateScore()
    {
        text.text = additionalText + GameManager.score;
    }
}