using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DogDialogue : MonoBehaviour
{
   public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public int index;
    public static bool EndCon;

    void Awake()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (textComponent.text == lines[index])
        {
            StopAllCoroutines();
            EndCon = true;
        }
        else
        {
            EndCon = false;
        }

    }
    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //GameObject.SetActive(false);
        }
    }
}
