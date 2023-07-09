using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayFlip : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    // IEnumerator StartDelaying()
    // {
    //     Time.timeScale = 0;
    //     Debug.Log("123");
    //     float pauseTime = Time.realtimeSinceStartup + 3f;
    //     while (Time.realtimeSinceStartup < pauseTime)
    //         yield return 0;
    //     //CountdownInfo.gameObject.SetActive(false);
    //     Time.timeScale = 1;
    // }

    IEnumerator ExampleCoroutine()
    {
        while (ControlArduino.readMessage == "51")
            
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
    }
}
