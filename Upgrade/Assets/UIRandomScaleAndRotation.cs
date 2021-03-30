using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRandomScaleAndRotation : MonoBehaviour
{
    float scale;
    [SerializeField] bool Rotate;
    [SerializeField] bool Scale;

    void Start()
    {



        StartCoroutine(ObjectRotate());
        StartCoroutine(ObjectScale());


        //-20, 20
    }

    private void OnEnable()
    {

        StartCoroutine(ObjectRotate());
        StartCoroutine(ObjectScale());

    }

    void Update()
    {
        scale = Random.Range(0.5f, 2f);

    }
    IEnumerator ObjectRotate()
    {
        if (Rotate)
        {
            float timer = 0;
            while (true)
            {
                float angle = Mathf.Sin(timer) * 20;
                gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                timer += Time.deltaTime;
                yield return null;
            }
        }
    }

    public float maxSize = 2f;
    public float growFactor = 1f;
    public float waitTime = 5f;

    IEnumerator ObjectScale()
    {
        float timer = 0;
        if (Scale)
        {
            while (true)
            {

                while (maxSize > transform.localScale.x)
                {
                    timer += Time.deltaTime;
                    transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                    yield return null;
                }
                // reset the timer

                yield return new WaitForSeconds(waitTime);

                timer = 0;
                while (1 < transform.localScale.x)
                {
                    timer += Time.deltaTime;
                    transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                    yield return null;
                }

                timer = 0;
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}