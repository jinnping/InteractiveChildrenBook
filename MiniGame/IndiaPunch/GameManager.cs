using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float showMonsterIntervalSeconds = 2;
    [SerializeField] float countDownShowMonsterSeconds;
    int MAX_MONSTERS_ON_SCREEN = 3;
    public GameObject gameOverCanvasPrefab;

    public static bool IndiaGameWin;
    bool readyForNext;
    //public Monster monstercs;
    public List<Monster> monsters;
    Text score;
    int scoreNumber = 0;

    public void HideMonster(GameObject monster)
    {
        monster.SetActive(false);
    }

    void ShowMonster(GameObject monster)
    {
        monster.SetActive(true);
    }

    public void AddScore()
    {
        //score = 100;
        scoreNumber += 10;
        score.text = scoreNumber.ToString();
        if (scoreNumber == 100)
        {
            IndiaGameWin = true;
            readyForNext = true;
            Debug.Log("YOU WIN");
            HideMonster(gameObject);
            gameOverCanvasPrefab.SetActive(true);
            ControlArduino.sp.Close();
            Invoke("IndiaScene", 3);
        }
    }

    void Start()
    {
        InitScore();
        InitMonsterList();
        HideAllMonsters();
        //ShowRandomMonster ();
        ResetShowMonserSeconds();
    }
    void Update()
    {
        if (readyForNext == true)
        {
            ControlArduino.readMessage = "";
            ControlArduino.sp.Close();
        }
    }


    private void ResetShowMonserSeconds()
    {
        countDownShowMonsterSeconds = showMonsterIntervalSeconds;
    }

    void HideAllMonsters()
    {
        foreach (var m in monsters)
        {
            HideMonster(m.gameObject);
        }
    }

    List<Monster> HiddenMonsters
    {
        get
        {
            var result = new List<Monster>();

            foreach (var m in monsters)
            {
                if (!m.IsActive)
                {
                    result.Add(m);
                }
            }

            return result;
        }
    }

    int MonsterCountOnScreen
    {
        get
        {
            int result = 0;
            foreach (var m in monsters)
            {
                if (m.IsActive)
                {
                    result += 1;
                }
            }
            return result;
        }
    }

    void ShowRandomMonster()
    {
        int r = Random.Range(0, HiddenMonsters.Count);
        Monster m = HiddenMonsters[r];
        ShowMonster(m.gameObject);
    }

    private void InitMonsterList()
    {
        monsters = GameObject.FindObjectsOfType<Monster>().ToList();
    }

    private void InitScore()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        score.text = "";
    }

    void FixedUpdate()
    {
        TryCountDownToShowMonster();
    }

    bool CountDownShowMonsterTimeUp => countDownShowMonsterSeconds <= 0;
    bool MonstersOnScreenAreFull => MonsterCountOnScreen >= MAX_MONSTERS_ON_SCREEN;

    private void TryCountDownToShowMonster()
    {
        countDownShowMonsterSeconds -= Time.fixedDeltaTime;
        if (CountDownShowMonsterTimeUp)
        {
            ResetShowMonserSeconds();

            if (!MonstersOnScreenAreFull)
            {
                ShowRandomMonster();
            }
        }
    }

    void IndiaScene()
    {
        SceneManager.LoadScene("III-India");
    }
}
