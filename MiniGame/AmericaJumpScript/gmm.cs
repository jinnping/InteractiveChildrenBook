using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gmm : MonoBehaviour
{
    public GameObject block;
    public GameObject destination;
    public GameObject longBlock;
    public GameObject blockSpawnPosition;
    public GameObject doorSpawnPosition;
    public GameObject longBlockSpawnPosition;
    public float blockspawnTime;
    public float doorspawnTime;
    public float longblockspawnTime;
    float timer1;
    float timer2;
    float timer3;
    public GameObject button;
    public static bool restartBtn;

    void Start()
    {
       // Time.timeScale = 1;
    }

    void Update()
    {
        timer1 += Time.deltaTime;
        if (timer1 >= blockspawnTime)
        {
            Instantiate(block, blockSpawnPosition.transform);
            timer1 = 0;
        }
        timer2 += Time.deltaTime;
        if (timer2 >= doorspawnTime)
        {
            Instantiate(destination, doorSpawnPosition.transform);
            timer2 = 0;
        }
        timer3 += Time.deltaTime;
        if (timer3 >= longblockspawnTime)
        {
            Instantiate(longBlock, longBlockSpawnPosition.transform);
            timer3 = 0;
        }

        if (restartBtn == true)
        {
            button.SetActive(true);
            if (ControlArduino.readMessage == "1")
            {
                ControlArduino.readMessage = "";
                restartBtn = false;
                Restart();
            }
        }

        if (!restartBtn)
        {
            button.SetActive(false);
        }
    }

    public void Restart()
    {
        ControlArduino.sp.Close();
        ControlArduino.readMessage = "";
        SceneManager.LoadScene("AmericaJumpGame");
    }
}
