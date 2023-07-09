using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jump : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpy;
    bool isJumping;
    public gmm gm;
    public Transform placement;
    public GameObject fail;
    public GameObject win;
    public GameObject button;
    public bool restartgame = false;
    public bool isWalking;
    public static bool AmericaGameWin;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        
    }

    void Update()
    {
        Debug.Log(ControlArduino.readMessage);


        if (ControlArduino.readMessage == "5" && isJumping == false)
        {
            ControlArduino.readMessage = "";
            rb.velocity = new Vector2(0, jumpy);
            isJumping = true;
            Debug.Log("Jump");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //isJumping = false;
        if (collision.gameObject.tag == "block")
        {
            //gm.GameOver();
            Instantiate(fail, placement.position, Quaternion.identity);
            Time.timeScale = 0;
            button.SetActive(true);
            //restartgame = true;
            gmm.restartBtn = true;
            ControlArduino.readMessage = "";
        }
        if (collision.gameObject.tag == "destination")
        {
            // gm.Win();
            Instantiate(win, placement.position, Quaternion.identity);
            win.SetActive(true);
            Time.timeScale = 0;
            AmericaGameWin = true;
            ControlArduino.readMessage = "";
            ControlArduino.sp.Close();
            SceneManager.LoadScene("IV-America");

        }

        if (collision.gameObject.tag == "road")
        {
            isJumping = false;//true;
        }

        else
        {
            //isWalking = false;
            isJumping = true;//true;

        }

    }
    void ReturnAme()
    {
        SceneManager.LoadScene("IV-America");
    }

}
