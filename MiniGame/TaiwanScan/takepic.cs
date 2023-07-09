
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using UnityEngine.SceneManagement;


public class takepic : MonoBehaviour
{
    public float range = 100f;
    public Camera fpsCam;
    private IEnumerator coroutine;

    public GameObject miss;
    GameObject clonemiss;
    public GameObject get;
    GameObject cloneget;
    public Transform placement;

    public static bool TaiwanGameWin = false;
    // public static bool TaiwanInformationCancel = true;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }
    public void click()
    {
        // Debug.Log(ControlArduino.readMessage);
        // if (ControlArduino.readMessage == "8")
        // {
        //     ControlArduino.readMessage = "";
        //     Shoot();
        // }
    }
    void Update()
    {

        if (ControlArduino.readMessage == "8")
        {
            ControlArduino.readMessage = "";
            Shoot();
        }

        if (TaiwanGameWin == true)
        {
            ControlArduino.readMessage = "";
            ControlArduino.sp.Close();
            TaiwanGameWin = true;
            SceneManager.LoadScene("I-Taiwan");
        }

        // TaiwanInformationCancel = true;
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.gameObject.tag == "b1")
            {

                clonemiss = Instantiate(miss, placement.position, Quaternion.identity);
                Destroy(clonemiss, 0.5f);

            }
            if (hit.transform.gameObject.tag != "b1")
            {

                TaiwanGameWin = true;
                cloneget = Instantiate(get, placement.position, Quaternion.identity);
                //Destroy(cloneget, 1.0f);
                //ControlArduino.readMessage = "";
                // Time.timeScale = 0;
            }
        }

    }

    void Taiwan()
    {
        ControlArduino.sp.Close();
        SceneManager.LoadScene("I-Taiwan");
    }


}
