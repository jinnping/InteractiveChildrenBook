using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public GameObject video;
    // public static bool videoPlayed = false;

    void Start()
    {
        //FadingBlack.StartScene = true;
    }

    void Update()
    {

        if (ControlArduino.readMessage == "7")
        {
            print(ControlArduino.readMessage);
            Time.timeScale = 1f;
            video.SetActive(true);
            Audios.m_ChangeScene = true;
            ControlArduino.sp.Close();
            ControlArduino.readMessage = "";
            Invoke("videoPlay", 34);
            // videoPlayed = true;
            // FadingBlack.EndScene = true;
        }


        else
        {
            // videoPlayed = false;
        }



    }

    public void videoPlay()
    {
        SceneManager.LoadScene("02-planets");

    }
}
