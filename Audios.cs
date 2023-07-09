using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public AudioSource SceneMusic;
    // public static bool m_NowScene = true;
    public static bool m_ChangeScene = false;

    void Start()
    {

    }

    void Update()
    {
        if (m_ChangeScene == true)
        {
            ChangeScene();
        }

    }
    public void NowScene()
    {
        SceneMusic.Play();
    }
    public void ChangeScene()
    {
        // m_NowScene = false;
        SceneMusic.Stop();
        m_ChangeScene = false;
    }
}
