using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JapanScenes : MonoBehaviour
{
    public GameObject[] conversation;
    public GameObject Gaia;
    public GameObject Ichiro;
    public GameObject Stamp;
    public GameObject[] StampCon;
    public GameObject video;
    public GameObject Information;
    bool FoxDone = false;
    bool DoraemonDone = false;
    bool DogDone = false;
    bool IchiroDone = false;
    public static bool JapanStamp = false;
    public static bool JapanDone = false;
    bool isReading = false;


    void Start()
    {
        JapanDone = false;
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
        IchiroDone = false;




        if (JapanGameManager.JapanGameWin)
        {
            Information.SetActive(false);
        }
    }

    void Update()
    {
        Debug.Log(ControlArduino.readMessage);
        if (!JapanDone)
        {

            switch (ControlArduino.readMessage)
            {

                case "1":
                    FoxConversation();
                    ControlArduino.readMessage = "";
                    break;

                case "3":
                    DoraemonConversation();
                    ControlArduino.readMessage = "";
                    break;

                case "6":
                    DogConversation();
                    ControlArduino.readMessage = "";
                    break;

            }

            if (Dialogue.EndCon == true)
            {
                Invoke("FoxEndConversation", 2);
                Dialogue.EndCon = false;
            }

            if (DoraemonDialogue.EndCon == true)
            {
                Invoke("DoraemonEndConversation", 2);
                DoraemonDialogue.EndCon = false;
                if (!JapanGameManager.JapanGameWin)
                {
                    ControlArduino.sp.Close();
                    Invoke("JapanGame", 3);

                }
                else
                {
                    Invoke("DoraemonEndConversation", 2);
                    DoraemonDialogue.EndCon = false;
                }
            }
            if (DogDialogue.EndCon == true)
            {
                Invoke("DogEndConversation", 2);
                DogDialogue.EndCon = false;
            }

            if (IchiroDialogue.EndCon == true)
            {
                Invoke("IchiroEndConversation", 2);
                IchiroDialogue.EndCon = false;
            }

            if (FoxDone && DogDone && JapanGameManager.JapanGameWin)
            {
                IchiroConversation();
            }

            if (IchiroDone == true && JapanGameManager.JapanGameWin)
            {
                IchiroEndConversation();
                Stamp.SetActive(true);
                JapanStamp = true;
                Audios.m_ChangeScene = true;
                Invoke("videoPlay", 3);
                ControlArduino.sp.Write("A");
            }



            if (ControlArduino.readMessage == "50" && JapanGameManager.JapanGameWin)
            {
                Stamp.SetActive(false);
                if (TaiwanCTwo.TaiwanStamp == true)
                {
                    StampCon[0].SetActive(true);
                }

                if (IndiaScene.IndiaStamp == true)
                {
                    StampCon[2].SetActive(true);
                }
                if (AmericaManager.AmericaDone == true)
                {
                    StampCon[3].SetActive(true);
                }
                // FoxDone = false;
                // DogDone = false;
                IchiroDone = false;
                JapanDone = true;
                JapanStamp = true;
                ControlArduino.sp.Close();
                SceneManager.LoadScene("02-Planets");
            }

        }
    }

    public void FoxConversation()
    {
        isReading = true;
        conversation[0].SetActive(true);
    }

    void DoraemonConversation()
    {
        isReading = true;
        conversation[1].SetActive(true);
    }

    void DogConversation()
    {
        isReading = true;
        conversation[2].SetActive(true);
    }

    void IchiroConversation()
    {
        Ichiro.SetActive(true);
    }
    public void FoxEndConversation()
    {
        conversation[0].SetActive(false);
        FoxDone = true;
    }
    public void DoraemonEndConversation()
    {
        conversation[1].SetActive(false);
        DoraemonDone = true;
    }
    public void DogEndConversation()
    {
        conversation[2].SetActive(false);
        DogDone = true;
    }
    void IchiroEndConversation()
    {
        Ichiro.SetActive(false);
        IchiroDone = true;
    }

    public void JapanGame()
    {
        SceneManager.LoadScene("II-JapanGame");
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
