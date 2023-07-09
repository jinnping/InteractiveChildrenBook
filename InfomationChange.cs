using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfomationChange : MonoBehaviour
{
    private bool fadeOut, fadeIn;
    public float fadeSpeed;
    void Start()
    {
        fadeOut = true;
    }

    void Update()
    {

        if (fadeOut)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            if (objectColor.a <= 0)
            {
                fadeOut = false;
                Destroy(this);
            }
        }

        if (fadeIn)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            if (objectColor.a >= 0)
            {
                fadeIn = false;
                Destroy(this);
            }
        }

    }



    public void FadeOutObject()
    {
        fadeOut = true;
    }
    public void FadeInObject()
    {
        fadeIn = true;
    }

}