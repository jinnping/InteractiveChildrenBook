using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmericaManager : MonoBehaviour
{
    public GameObject[] conversation;
    public GameObject Gaia;
    public GameObject Ichiro;
    public GameObject Stamp;
    public GameObject video;
    public GameObject Information;
    public GameObject[] StampCon;
    public bool GreyDone = false;
    public bool FreeDone = false;
    public bool ShipDone = false;
    public bool IchiroDone = false;
    public bool JapanTalk = false;
    public static bool AmericaStamp = true;
    public static bool AmericaDone = false;

    void Start()
    {
        StampCon[0].SetActive(false);
        StampCon[1].SetActive(false);
        StampCon[2].SetActive(false);
        StampCon[3].SetActive(false);
        conversation[0].SetActive(false);
        conversation[1].SetActive(false);
        conversation[2].SetActive(false);
        Ichiro.SetActive(false);
        Stamp.SetActive(false);
        Information.SetActive(true);


        if (jump.AmericaGameWin)
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
                FreeConversation();
                ControlArduino.readMessage = "";
                break;

            case "2":
                ShipConversation();
                ControlArduino.readMessage = "";
                break;

            case "7":
                GreyConversation();
                ControlArduino.readMessage = "";
                break;

        }


        if (GreyDialogue.EndCon == true)
        {
            Invoke("GreyEndConversation", 2);

        }

        if (FreeDialogue.EndCon == true)
        {
            Invoke("FreeEndConversation", 2);

            if (!jump.AmericaGameWin)
            {
                ControlArduino.sp.Close();

                AmericaGame();
            }
            else
            {
                Invoke("FreeEndConversation", 2);
            }
        }
        if (ShipDialogue.EndCon == true)
        {
            Invoke("ShipEndConversation", 2);
        }

        if (jump.AmericaGameWin && GreyDone && ShipDone)
        {
            IchiroConversation();
        }

        if (IchiroDialogue.EndCon == true)
        {
            IchiroEndConversation();

        }

        if (IchiroDone == true && jump.AmericaGameWin == true)
        {
            Stamp.SetActive(true);
            if (TaiwanCTwo.TaiwanStamp == true)
            {
                StampCon[0].SetActive(true);
            }
            if (JapanScenes.JapanStamp == true)
            {
                StampCon[1].SetActive(true);
            }
            if (IndiaScene.IndiaStamp == true)
            {
                StampCon[2].SetActive(true);
            }
            Audios.m_ChangeScene = true;
            Invoke("videoPlay", 3);
            ControlArduino.sp.Write("A");
        }


        if (ControlArduino.readMessage == "50" && jump.AmericaGameWin == true)
        {
            AmericaDone = true;
            AmericaStamp = true;
            IchiroDone = false;
            Stamp.SetActive(false);
            ControlArduino.readMessage = " ";
            ControlArduino.sp.Close();
            SceneManager.LoadScene("02-Planets");

        }
    }

    void FreeConversation()
    {
        conversation[0].SetActive(true);
    }
    void ShipConversation()
    {
        conversation[1].SetActive(true);
    }
    public void GreyConversation()
    {
        conversation[2].SetActive(true);
    }
    void IchiroConversation()
    {
        Ichiro.SetActive(true);
    }
    public void FreeEndConversation()
    {
        conversation[0].SetActive(false);
        FreeDone = true;
    }
    public void ShipEndConversation()
    {
        conversation[1].SetActive(false);
        ShipDone = true;
    }
    public void GreyEndConversation()
    {
        conversation[2].SetActive(false);
        GreyDone = true;
    }

    void IchiroEndConversation()
    {
        Ichiro.SetActive(false);
        IchiroDone = true;
    }
    public void AmericaGame()
    {
        SceneManager.LoadScene("AmericaJumpGame");
    }
    public void ReturnPlanet()
    {

        SceneManager.LoadScene("02-Planets");
    }
    public void videoPlay()
    {
        Audios.m_ChangeScene = true;
        video.SetActive(true);
    }


}
