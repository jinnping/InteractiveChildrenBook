using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO.Ports;

public class Card : MonoBehaviour
{
    public CardState cardState;
    public CardPattern cardPattern;
    public JapanGameManager gameManager;

    public float x, y, z;
    public int timer;

    void Start()
    {
        cardState = CardState.cardturnyet; //未翻牌
    }

    void Update()
    {

        if (ControlArduino.readMessage == this.tag)
        {
            Debug.Log(ControlArduino.readMessage);
            OnMouseUp();
            ControlArduino.sp.BaseStream.Flush();
            ControlArduino.sp.DiscardInBuffer();
            ControlArduino.readMessage = "";
        }

    }

    public void OnMouseUp() //滑鼠點擊
    {
        if (cardState.Equals(CardState.cardturned)) //如果現在卡牌的狀態等於已翻牌
        {
            return; //不執行後面的程式碼
        }
        if (cardState.Equals(CardState.matchsuccess)) //如果現在卡牌的狀態等於比對成功
        {
            return; //不執行後面的程式碼
        }
        if (gameManager.ReadyToCompareCards)
        {
            return;
        }

        OpenCard(); //執行OpenCard
        gameManager.AddCardInCardComparison(this);  //現在的牌放進比對清單
        gameManager.CompareCardsInList();
    }

    void OpenCard()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        cardState = CardState.cardturned; //已翻牌
    }
}


public enum CardState
{
    cardturnyet, cardturned, matchsuccess
}

public enum CardPattern
{
    none, 市松, 麻葉, 青海波, 霞, 鹿子, 矢絣
}