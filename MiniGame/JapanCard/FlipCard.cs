using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class FlipCard : MonoBehaviour
{
    public float x, y, z;
    // public GameObject cardBack;
    public bool cardBackIsActive;
    public int timer;
    void Start()
    {
        cardBackIsActive = false;
    }

    public void StartFlip()
    {
        StartCoroutine(CalculateFlip());
    }



    IEnumerator CalculateFlip()
    {
        for (int i = 0; i < 180; i++)
        {
            yield return new WaitForSeconds(0.00001f);
            transform.Rotate(new Vector3(x, y, z));
            timer++;
        }

        timer = 0;
    }


}
