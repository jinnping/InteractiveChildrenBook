using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class JapanGameManager : MonoBehaviour
{
    [Header("比對卡牌的清單")]
    public List<Card> cardComparison;
    public int cardCount;
    public GameObject gameOverCanvasPrefab;
    public static bool JapanGameWin = false;
    void Start()
    {
    }

    public void AddCardInCardComparison(Card card)
    {
        cardComparison.Add(card);
    }
    public bool ReadyToCompareCards
    {
        get
        {
            if (cardComparison.Count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void CompareCardsInList()
    {
        if (ReadyToCompareCards)
        {
            //Debug.Log("可以比對卡牌了");
            if (cardComparison[0].cardPattern == cardComparison[1].cardPattern)
            {
                Debug.Log("兩張牌一樣");
                foreach (var card in cardComparison)
                {
                    card.cardState = CardState.matchsuccess;
                }
                ClearCardComparison(); //清空比對結果
                cardCount += 2;
            }
            else
            {
                Debug.Log("兩張牌不一樣A");
                StartCoroutine(MissMatchCards());
                // TurnBackCards();
                // ClearCardComparison(); //清空比對結果

            }
            if (cardCount == 8)
            {
                Debug.Log("You win!");
                gameOverCanvasPrefab.SetActive(true);
                JapanGameWin = true;
                ControlArduino.close = true;

                Invoke("JapanScene", 3);

            }
        }
    }




    void ClearCardComparison()
    {
        cardComparison.Clear(); //把比對清單內容消除
    }

    void TurnBackCards()
    {
        foreach (var card in cardComparison) //比對清單裡的每張牌
        {
            card.gameObject.transform.eulerAngles = Vector3.zero;
            //=card.gameObject.transform.eulerAngles = new Vector3(0,0,0);
            card.cardState = CardState.cardturnyet;
        }
    }

    IEnumerator MissMatchCards()
    {
        yield return new WaitForSeconds(1.5f);  //程式執行到此時暫停1.5秒
        TurnBackCards();
        ClearCardComparison();
    }

    void JapanScene()
    {
        SceneManager.LoadScene("II-Japan");
    }

}

