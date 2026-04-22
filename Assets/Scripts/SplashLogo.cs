using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SplashLogo : MonoBehaviour
{
    public float startFontSize = 50f;
    public float endFontSize = 200f;
    public float growTime = 2.5f;
    public float waitTime = 0.5f;

    public int nextSceneIndex = 0;

    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.fontSize = startFontSize;

        StartCoroutine(GrowText());
    }

    IEnumerator GrowText()
    {
        float timer = 0f;

        while (timer < growTime)
        {
            timer += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, timer / growTime);

            text.fontSize = Mathf.Lerp(startFontSize, endFontSize, t);

            yield return null;
        }

        text.fontSize = endFontSize;

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(nextSceneIndex);
    }
}