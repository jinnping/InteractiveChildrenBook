using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDelay : MonoBehaviour
{
    public GameObject CountdownInfo;
    private bool fadeOut, fadeIn;
    public float fadeSpeed;
    void Start()
    {
        Color objectColor = this.GetComponent<Renderer>().material.color;
        objectColor.a = 1;
        if (objectColor.a == 1)
        {
            StartCoroutine("StartDelaying");
        }
    }

    void Update()
    {

    }

    IEnumerator StartDelaying()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 4f;
        StartCoroutine(FadeOutobject());
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        Time.timeScale = 1;
    }

    public IEnumerator FadeOutobject()
    {
        while (this.GetComponent<Renderer>().material.color.a > 0)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            yield return null;
        }
    }
    public IEnumerator FadeInObject()
    {
        while (this.GetComponent<Renderer>().material.color.a < 1)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            yield return null;
        }
    }
}
