using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    GameManager gameManager;
    public float maxSecondsOnScreen = 2.5f;
    public float currentSecondsOnScreen = 0;

    void Start()
    {
        Init();
    }

    void Update()
    {
        Debug.Log(ControlArduino.readMessage);

        if (ControlArduino.readMessage == this.tag)
        {
            OnMouseDown();
            ControlArduino.readMessage = "";
        }
    }

    private void Init()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        ResetCurrentSecondsOnScreen();
    }

    public void OnMouseDown()
    {
        gameManager.AddScore();
        ResetCurrentSecondsOnScreen();
        Hide();
    }

    private void Hide()
    {
        gameManager.HideMonster(gameObject);
    }

    public bool IsActive => gameObject.activeInHierarchy;
    bool OnScreenTimeUp => currentSecondsOnScreen < 0;

    void FixedUpdate()
    {
        TryCountDownToHide();
    }

    private void TryCountDownToHide()
    {
        if (IsActive)
        {
            CountDownCurrentSecondsOnScrren();
        }

        if (OnScreenTimeUp)
        {
            ResetCurrentSecondsOnScreen();
            Hide();
        }
    }

    private void CountDownCurrentSecondsOnScrren()
    {
        currentSecondsOnScreen -= Time.fixedDeltaTime;
    }

    private void ResetCurrentSecondsOnScreen()
    {
        currentSecondsOnScreen = maxSecondsOnScreen;
    }
}
