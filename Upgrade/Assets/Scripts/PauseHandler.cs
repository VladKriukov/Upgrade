using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    bool Paused = false;
    [SerializeField] GameObject blur;
    [SerializeField] GameObject UI;

    public float slowdownTime = 0.1f;
    public float slowdownLength = 2f;

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") && GameManager.inGame)
        {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                GameManager.lockMovements = false;
                blur.SetActive(false);
                UI.SetActive(true);
                Paused = false;
            }
            else
            {
                SlowMotion();
                GameManager.lockMovements = true;
                blur.SetActive(true);
                UI.SetActive(false);
                Paused = true;
            }
        }
    }

    public void SlowMotion()
    {
        Time.timeScale = slowdownTime;
        Time.fixedDeltaTime = Time.timeScale * .02f;

        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
}