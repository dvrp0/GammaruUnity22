using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }
    private static GameManager instance;

    public Transform Player;
    public Text TimeText;

    public Transform GameoverUI;
    public Text GameoverResultText;
    public Transform GameclearUI;

    public float ClearTime;

    private float time = 0;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        time += Time.deltaTime;
        TimeText.text = time.ToString();

        if (time < ClearTime && Player.GetComponent<Player>().Life == 0)
            Gameover();
        else if (time >= ClearTime)
            Gameclear();    
    }

    void Gameover()
    {
        GameoverUI.gameObject.SetActive(true);
        GameoverResultText.text = $"{time}√ ";
        Time.timeScale = 0;
    }

    void Gameclear()
    {
        GameclearUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}