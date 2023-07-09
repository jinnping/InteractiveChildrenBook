using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaiwanControl : MonoBehaviour
{
    public GameObject[] conversation;
    public GameObject Gaia;
    public GameObject Ichiro;
    public GameObject Stamp;
    public GameObject Video;
    public GameObject Information;
    public bool MaskDone = false;
    public bool BubbleDone = false;
    public bool ScanDone = false;
    public bool IchiroDone = false;
    public bool IchiroCon = false;
    public static bool TaiwanStamp = true;
    void Start()
    {
        conversation[0].SetActive(false);
        conversation[1].SetActive(false);
        conversation[2].SetActive(false);
        Stamp.SetActive(false);
        Ichiro.SetActive(false);

        if (takepic.TaiwanGameWin == true)
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

            case "2":
                Bubble();
                ControlArduino.readMessage = "";
                break;

            case "3":
                Scan();
                ControlArduino.readMessage = "";
                break;

        }


        if (TaiwanDialogue.EndCon == true)
        {
            if (!takepic.TaiwanGameWin)
            {
                ControlArduino.sp.Close();
                TaiwanGame();
            }
            else
            {
                ScanEndConversation();
            }
        }

        if (MaskDialogue.EndCon == true)
        {
            MaskEndConversation();
            MaskDialogue.EndCon = false;

        }
        if (BearDialogue.EndCon == true)
        {
            BubbleEndConversation();
            BearDialogue.EndCon = false;
        }
        if (IchiroDialogue.EndCon == true)
        {
            IchiroEndConversation();
            IchiroDialogue.EndCon = false;
        }

        if (takepic.TaiwanGameWin && BubbleDone && MaskDone)
        {
            IchiroConversation();
        }

        if (IchiroDone == true)
        {
            IchiroEndConversation();
            Stamp.SetActive(true);
            TaiwanStamp = true;
            Audios.m_ChangeScene = true;
            Invoke("videoPlay", 3);
            ControlArduino.sp.Write("A");
        }
        // if (PlanetManager1227.changingScene == true)
        // {
        //     ControlArduino.readMessage = "";
        //     PlanetManager1227.changingScene = false;
        // }

        if (ControlArduino.readMessage == "50")
        {
            Stamp.SetActive(false);
            Audios.m_ChangeScene = true;
            ControlArduino.readMessage = "";
            // PlanetManager1227.changingScene = true;
            ControlArduino.sp.Close();
            Invoke("ReturnToPlanet", 1);
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
        IchiroCon = true;
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
        Video.SetActive(true);
    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(10);
    }
}
