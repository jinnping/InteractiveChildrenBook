using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadingBlack : MonoBehaviour
{
    public GameObject blackOutBg;

    public static bool EndScene;
    public static bool StartScene;

    void Start()
    {

    }

    void Update()
    {
        if (EndScene == true)
        {
            StartCoroutine(FadeBlackOutBg());
            EndScene = false;
        }

        if (StartScene == true)
        {
            StartCoroutine(FadeBlackOutBg(false));
            StartScene = false;
        }

    }

    public IEnumerator FadeBlackOutBg(bool fadetoBlack = true, int fadeSpeed = 4)
    {
        Color objectColor = blackOutBg.GetComponent<Image>().color;
        float fadeAmount;

        if (fadetoBlack)
        {
            while (blackOutBg.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                blackOutBg.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (blackOutBg.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutBg.GetComponent<Image>().color = objectColor;
                yield return null;

            }
        }
    }

}

