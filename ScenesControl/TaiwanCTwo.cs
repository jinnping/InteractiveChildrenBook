using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaiwanCTwo : MonoBehaviour
{
    public GameObject[] conversation;
    public GameObject Gaia;
    public GameObject Ichiro;
    public GameObject Stamp;
    public GameObject Video;
    public GameObject Information;
    public GameObject JapanStamp;
    public AudioSource SceneMusic;
    public GameObject[] StampCon;

    public bool MaskDone = false;
    public bool BubbleDone = false;
    public bool ScanDone = false;
    bool IchiroDone = false;

    public static bool TaiwanStamp = false;
    public static bool TaiwanDone = false;

    void Start()
    {
        ControlArduino.readMessage = "";
        conversation[0].SetActive(false);
        conversation[1].SetActive(false);
        conversation[2].SetActive(false);
        Ichiro.SetActive(false);
        Stamp.SetActive(false);
        Information.SetActive(false);
        MaskDone = false;
        BubbleDone = false;
        IchiroDone = false;
        // takepic.TaiwanGameWin = false;

        // TaiwanStamp = false;
        if (takepic.TaiwanGameWin)
        {
            Information.SetActive(false);
        }
    }

    void Update()
    {
        Debug.Log(ControlArduino.readMessage);

        switch (ControlArduino.readMessage)
        {
            case "1":
                Mask();
                ControlArduino.readMessage = "";
                break;

            case "6":
                Bubble();
                ControlArduino.readMessage = "";
                break;

            case "7":
                Scan();
                ControlArduino.readMessage = "";
                break;

        }

        if (TaiwanDialogue.EndCon == true)
        {
            Invoke("ScanEndConversation", 2);
            if (!takepic.TaiwanGameWin)
            {
                ControlArduino.sp.Close();
                Invoke("TaiwanGame", 3);
            }
            else
            {
                Invoke("ScanEndConversation", 2);
            }
        }

        if (MaskDialogue.EndCon == true)
        {
            Invoke("MaskEndConversation", 2);
        }
        if (BearDialogue.EndCon == true)
        {
            Invoke("BubbleEndConversation", 3);
        }
        if (IchiroDialogue.EndCon == true)
        {
            Invoke("IchiroEndConversation", 2);
        }

        if (takepic.TaiwanGameWin && BubbleDone && MaskDone)
        {
            IchiroConversation();
        }
        if (IchiroDialogue.EndCon == true)
        {
            IchiroEndConversation();
        }

        if (IchiroDone == true && takepic.TaiwanGameWin)
        {

            Stamp.SetActive(true);
            if (JapanScenes.JapanStamp == true)
            {
                StampCon[1].SetActive(true);
            }
            if (IndiaScene.IndiaStamp == true)
            {
                StampCon[2].SetActive(true);
            }
            if (AmericaManager.AmericaDone == true)
            {
                StampCon[3].SetActive(true);
            }
            Invoke("videoPlay", 3);
            ControlArduino.sp.Write("A");
        }

        if (ControlArduino.readMessage == "50" && takepic.TaiwanGameWin)
        {
            IchiroDone = false;
            TaiwanStamp = true;
            TaiwanDone = true;
            ControlArduino.readMessage = " ";
            Invoke("ReturnToPlanet", 1);
            ControlArduino.sp.Close();

        }
    }

    void Mask()
    {
        conversation[0].SetActive(true);
    }

    void Bubble()
    {
        conversation[1].SetActive(true);
    }

    void Scan()
    {
        conversation[2].SetActive(true);
    }

    void IchiroConversation()
    {
        Ichiro.SetActive(true);

    }

    public void MaskEndConversation()
    {
        conversation[0].SetActive(false);
        MaskDone = true;
    }
    public void BubbleEndConversation()
    {
        conversation[1].SetActive(false);
        BubbleDone = true;
    }
    public void ScanEndConversation()
    {
        conversation[2].SetActive(false);
        ScanDone = true;
    }
    void IchiroEndConversation()
    {
        Ichiro.SetActive(false);
        IchiroDone = true;
    }

    void TaiwanGame()
    {
        SceneManager.LoadScene("TaiwanScan");
    }
    public void ReturnToPlanet()
    {
        SceneManager.LoadScene("02-Planets");
    }
    public void videoPlay()
    {
        SceneMusic.Stop();
        Video.SetActive(true);
    }

}
