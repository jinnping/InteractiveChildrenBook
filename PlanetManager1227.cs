using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetManager1227 : MonoBehaviour
{

    public GameObject[] WorldPics;
    public GameObject[] PlanetBlack;
    public GameObject video;
    public GameObject flip;
    bool EnterPlannets = false;
    bool EnterTaiwan = false;
    bool EnterJapan = false;
    bool EnterIndia = false;
    bool EnterAmerica = false;


    // Start is called before the first frame update
    void Start()
    {
        WorldPics[0].SetActive(false);
        WorldPics[1].SetActive(false);
        WorldPics[2].SetActive(false);
        WorldPics[3].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ControlArduino.readMessage);

        switch (ControlArduino.readMessage)
        {
            case "1":
                Debug.Log("Taiwan Opened");
                WorldPics[0].SetActive(true);
                Debug.Log(ControlArduino.readMessage);
                EnterTaiwan = true;
                if (EnterTaiwan == true)
                {
                    EnterIndia = false;
                    EnterJapan = false;
                    EnterAmerica = false;
                }
                break;

            case "2":
                Debug.Log("Japan Opened");
                WorldPics[1].SetActive(true);
                Debug.Log(ControlArduino.readMessage);
                EnterJapan = true;
                if (EnterJapan == true)
                {
                    EnterAmerica = false;
                    EnterIndia = false;
                    EnterTaiwan = false;
                }
                break;

            case "3":
                Debug.Log("India Opened");
                WorldPics[2].SetActive(true);
                Debug.Log(ControlArduino.readMessage);
                EnterIndia = true;
                if (EnterIndia == true)
                {
                    EnterTaiwan = false;
                    EnterJapan = false;
                    EnterAmerica = false;
                }
                break;

            case "4":
                Debug.Log("America Opened");
                WorldPics[3].SetActive(true);
                Debug.Log(ControlArduino.readMessage);
                EnterAmerica = true;
                if (EnterAmerica == true)
                {
                    EnterIndia = false;
                    EnterJapan = false;
                    EnterTaiwan = false;
                }
                break;
        }

        if (EnterJapan || EnterTaiwan || EnterAmerica || EnterIndia)
        {
            ControlArduino.sp.Write("B");
        }

        if (ControlArduino.readMessage == "51")
        {
            if (EnterTaiwan == true)
            {
                ControlArduino.readMessage = "";
                video.SetActive(true);
                EnterTaiwan = false;
                Audios.m_ChangeScene = true;
                ControlArduino.sp.Close();
                Invoke("Taiwan", 13);
            }

            else if (EnterJapan == true)
            {
                ControlArduino.readMessage = "";
                video.SetActive(true);
                Audios.m_ChangeScene = true;
                ControlArduino.sp.Close();
                EnterJapan = false;
                Invoke("Japan", 13);
            }

            else if (EnterIndia == true)
            {
                ControlArduino.readMessage = "";
                video.SetActive(true);
                Audios.m_ChangeScene = true;
                ControlArduino.sp.Close();
                EnterIndia = false;
                Invoke("India", 13);
            }

            else if (EnterAmerica == true)
            {
                ControlArduino.readMessage = "";
                video.SetActive(true);
                Audios.m_ChangeScene = true;
                ControlArduino.sp.Close();
                EnterAmerica = false;
                Invoke("America", 13);
            }
        }

        if (TaiwanCTwo.TaiwanDone == true)
        {
            PlanetBlack[0].SetActive(true);
        }
        if (JapanScenes.JapanDone == true)
        {
            PlanetBlack[1].SetActive(true);
        }
        if (IndiaScene.IndiaDone == true)
        {
            PlanetBlack[2].SetActive(true);
        }
        if (AmericaManager.AmericaDone == true)
        {
            PlanetBlack[3].SetActive(true);
        }


    }

    void PressedPlanet()
    {
        ControlArduino.sp.Write("B");
        Debug.Log("HelloSonic");
    }

    public void Taiwan()
    {
        SceneManager.LoadScene("I-Taiwan");
    }
    public void Japan()
    {
        SceneManager.LoadScene("II-Japan");
    }
    public void India()
    {
        SceneManager.LoadScene("III-India");
    }
    public void America()
    {
        SceneManager.LoadScene("IV-America");
    }

}
