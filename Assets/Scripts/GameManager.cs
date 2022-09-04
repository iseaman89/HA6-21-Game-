using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public Button buttonMoreCard, buttonEnough, buttonNewGame;

    public TextMeshProUGUI text, score;

    public Player player;
    public Enemy enemy;
    public Deck deck;
    private const string path = "Assets/Data/SaveData.txt";


    private void Start()
    {
        buttonEnough.onClick.AddListener(ButtonEnough);
        buttonMoreCard.onClick.AddListener(ButtonMore);
        buttonNewGame.onClick.AddListener(ButtonNewGame);

        ReadingData();
        StartNewGame();

        score.text = "Score: " + player.playerScore;
    }

    void WritingData()
    {
        StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.Default);
        streamWriter.Write(player.playerScore.ToString());
        streamWriter.Close();
    }

    void ReadingData()
    {
        StreamReader streamReader = new StreamReader(path);
        
        player.playerScore = Int32.Parse(streamReader.ReadLine());
        
        streamReader.Close();
    }

    private void StartNewGame()
    {
        deck.NewGame();

        deck.TakeCardPlayer();
        deck.TakeCardPlayer();

        deck.TakeFirstCardEnemy();
        deck.TakeCardEnemy();

        if (player.playerPoints == 21) GameWin();
    }

    private void ButtonNewGame()
    {
        enemy.imageCard1.SetActive(false);
        deck.cardback.SetActive(true);

        buttonNewGame.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        for (int i = 2; i < player.imageCard.Length; i++)
        {
            player.imageCard[i].SetActive(false);
        }
        for (int i = 1; i < enemy.imageCard2345.Length; i++)
        {
            enemy.imageCard2345[i].SetActive(false);
        }

        StartNewGame();
    }

    public void ButtonMore()
    {
        deck.TakeCardPlayer();

        if (player.playerPoints > 21) GameLose();
    }

    public void ButtonEnough()
    {
        enemy.imageCard1.SetActive(true);
        deck.cardback.SetActive(false);
        if (player.playerPoints < enemy.enemyPoints) GameLose();
        else if (enemy.enemyPoints < player.playerPoints) deck.TakeCardEnemy();
        else if (enemy.enemyPoints > player.playerPoints && enemy.enemyPoints <= 21) GameLose();
        else if (enemy.enemyPoints > 21) GameWin();
        else if (enemy.enemyPoints < 21) deck.TakeCardEnemy();
        else if (enemy.enemyPoints > 21) GameWin();
        else if (enemy.enemyPoints > player.playerPoints && enemy.enemyPoints <= 21) GameLose();
        else if (enemy.enemyPoints < 21) deck.TakeCardEnemy();
        else if (enemy.enemyPoints > 21) GameWin();
        else if (enemy.enemyPoints > player.playerPoints && enemy.enemyPoints <= 21) GameLose();
        else if (enemy.enemyPoints < 21) deck.TakeCardEnemy();
        else if (enemy.enemyPoints > 21) GameWin();
        else if (enemy.enemyPoints > player.playerPoints && enemy.enemyPoints <= 21) GameLose();
        else if (enemy.enemyPoints < 21) deck.TakeCardEnemy();
        else if (enemy.enemyPoints > 21) GameWin();
        else if (enemy.enemyPoints > player.playerPoints && enemy.enemyPoints <= 21) GameLose();
        else if (enemy.enemyPoints < 21) deck.TakeCardEnemy();
        else if (enemy.enemyPoints > 21) GameWin();
        else if (enemy.enemyPoints > player.playerPoints && enemy.enemyPoints <= 21) GameLose();

    }

    public void GameWin()
    {
        player.playerScore += 15;
        score.text = "Score: " + player.playerScore.ToString();
        text.text = "Digga! Gewonnen!";
        text.gameObject.SetActive(true);
        buttonNewGame.gameObject.SetActive(true);
        WritingData();
    }

    public void GameLose()
    {
        player.playerScore -= 2;
        score.text = "Score: " + player.playerScore.ToString();
        text.text = "Looser";
        text.gameObject.SetActive(true);
        buttonNewGame.gameObject.SetActive(true);
        WritingData();
    }
}
