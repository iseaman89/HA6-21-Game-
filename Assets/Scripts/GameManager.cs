using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;
using Zenject;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Button buttonMoreCard, buttonEnough, buttonNewGame;

    [SerializeField] private TextMeshProUGUI text, score;

    [Inject] private Player player;
    [Inject] private Enemy enemy;
    [Inject] private Deck deck;

    private bool gameStop;
    private const string path = "Assets/Data/SaveData.txt";


    private void Start()
    {
        buttonEnough.onClick.AddListener(ButtonEnough);
        buttonMoreCard.onClick.AddListener(ButtonMore);
        buttonNewGame.onClick.AddListener(ButtonNewGame);

        ReadingData();
        StartNewGame();

        score.text = "Score: " + player.PlayerScore;
    }

    private void WritingData()
    {
        StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.Default);
        streamWriter.Write(player.PlayerScore.ToString());
        streamWriter.Close();
    }

    private void ReadingData()
    {
        StreamReader streamReader = new StreamReader(path);

        player.PlayerScore = Int32.Parse(streamReader.ReadLine());

        streamReader.Close();
    }

    private void StartNewGame()
    {
        gameStop = false;

        deck.NewGame();

        deck.TakeCardPlayer();
        deck.TakeCardPlayer();

        deck.TakeFirstCardEnemy();
        deck.TakeCardEnemy();

        if (player.PlayerPoints == 21) GameWin();
    }

    private void ButtonNewGame()
    {
        enemy.ImageCard1.SetActive(false);

        deck.Cardback.SetActive(true);

        buttonNewGame.gameObject.SetActive(false);

        text.gameObject.SetActive(false);

        for (int i = 2; i < player.ImageCard.Length; i++)
        {
            player.ImageCard[i].SetActive(false);
        }

        for (int i = 1; i < enemy.ImageCard2345.Length; i++)
        {
            enemy.ImageCard2345[i].SetActive(false);
        }

        StartNewGame();
    }

    private void ButtonMore()
    {
        if (!gameStop)
        {
            deck.TakeCardPlayer();

            if (player.PlayerPoints > 21) GameLose();
        }
        
    }

    private void ButtonEnough()
    {
        if (!gameStop)
        {
            enemy.ImageCard1.SetActive(true);
            deck.Cardback.SetActive(false);

            while (enemy.EnemyPoints <= player.PlayerPoints)
            {
                deck.TakeCardEnemy();
            }

            if (enemy.EnemyPoints < 22 && enemy.EnemyPoints > player.PlayerPoints)
            {
                GameLose();
            }

            else
            {
                GameWin();
            }
        }
        
    }

    private void GameWin()
    {
        gameStop = true;

        player.PlayerScore += 15;

        score.text = "Score: " + player.PlayerScore.ToString();

        text.text = "Game Won!";
        text.gameObject.SetActive(true);

        buttonNewGame.gameObject.SetActive(true);

        WritingData();
    }

    private void GameLose()
    {
        gameStop = true;

        player.PlayerScore -= 15;

        score.text = "Score: " + player.PlayerScore.ToString();

        text.text = "Looser";
        text.gameObject.SetActive(true);

        buttonNewGame.gameObject.SetActive(true);

        WritingData();
    }
}