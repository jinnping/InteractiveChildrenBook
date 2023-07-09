using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndiaScene : MonoBehaviour
{
    public GameObject[] conversation;
    public GameObject Gaia;
    public GameObject Ichiro;
    public GameObject Stamps;
    public GameObject Video;
    public GameObject Information;
    public GameObject[] StampCon;
    public bool SandDone = false;
    public bool LightDone = false;
    public bool InternetDone = false;
    bool IchiroDone = false;
    public static bool IndiaDone = false;
    public static bool IndiaStamp = false;
    public bool videoPlays = false;

    // public static bool IndiaStamp = false;

    void Start()
    {
        StampCon[0].SetActive(false);
        StampCon[1].SetActive(false);
        StampCon[2].SetActive(false);
        StampCon[3].SetActive(false);
        ControlArduino.readMessage = "";
        conversation[0].SetActive(false);
        conversation[1].SetActive(false);
        conversation[2].SetActive(false);
        Ichiro.SetActive(false);
        Stamps.SetActive(false);
        Information.SetActive(false);
        SandDone = false;
        LightDone = false;
        InternetDone = false;
        IchiroDone = false;
        //GameManager.IndiaGameWin = false;

        if (GameManager.IndiaGameWin)
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
                Internet();
                ControlArduino.readMessage = "";
                break;

            case "2":
                Light();
                ControlArduino.readMessage = "";
                break;

            case "7":
                Sand();
                ControlArduino.readMessage = "";
                break;
        }

        if (SandDialogue.EndCon == true)
        {
            SandEndConversation();
        }

        if (LightDialogue.EndCon == true)
        {
            LightEndConversation();
            if (!GameManager.IndiaGameWin)
            {
                ControlArduino.sp.Close();
                IndiaGame();
            }
            else
            {
                LightEndConversation();
            }

        }
        if (InternetDialogue.EndCon == true)
        {
            InternetEndConversation();
        }

        if (SandDone && GameManager.IndiaGameWin && InternetDone)
        {
            IchiroConversation();
        }

        if (IchiroDialogue.EndCon == true)
        {
            IchiroEndConversation();
        }

        if (IchiroDone == true && GameManager.IndiaGameWin)
        {
            Stamps.SetActive(true);
            if (TaiwanCTwo.TaiwanStamp == true)
            {
                StampCon[0].SetActive(true);
            }
            if (JapanScenes.JapanStamp == true)
            {
                StampCon[1].SetActive(true);
            }
            if (AmericaManager.AmericaStamp == true)
            {
                StampCon[3].SetActive(true);
            }
            Invoke("videoPlayed", 3);
            if (videoPlays == true)
            {
                
                ControlArduino.sp.Write("A");
            }
        }


        if (ControlArduino.readMessage == "50" && GameManager.IndiaGameWin)
        {
            IchiroDone = false;
            IndiaDone = true;
            IndiaStamp = true;
            ControlArduino.readMessage = " ";
            Invoke("ReturnPlanet", 1);
            ControlArduino.sp.Close();
        }
    }

    void Sand()
    {
        conversation[0].SetActive(true);
    }

    void Light()
    {
        conversation[1].SetActive(true);
    }

    void Internet()
    {
        conversation[2].SetActive(true);
    }

    void IchiroConversation()
    {
        Ichiro.SetActive(true);
    }

    public void SandEndConversation()
    {
        conversation[0].SetActive(false);
        SandDone = true;
    }
    public void LightEndConversation()
    {
        conversation[1].SetActive(false);
        LightDone = true;
    }
    public void InternetEndConversation()
    {
        conversation[2].SetActive(false);
        InternetDone = true;
    }
    void IchiroEndConversation()
    {
        Ichiro.SetActive(false);
        IchiroDone = true;
    }

    void IndiaGame()
    {
        SceneManager.LoadScene("IndiaPunchs");
    }
    public void ReturnPlanet()
    {
        SceneManager.LoadScene("02-Planets");
    }
    public void videoPlayed()
    {
        Audios.m_ChangeScene = true;
        Video.SetActive(true);
        videoPlays = true;
    }
}
