using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    int indexPlayer;
    int indexEnemy;

    public GameObject cardback;
    public List<Sprite> imagesCard = new List<Sprite>(36);
    public List<Sprite> copyCards = new List<Sprite>(36);
    public List<int> cardValues;


    public void NewGame()
    {
        indexPlayer = 0;
        indexEnemy = 0;

        player.playerPoints = 0;
        enemy.enemyPoints = 0;

       cardValues = new List<int>() { 2, 3, 4, 6, 7, 8, 9, 10, 11, 2, 3, 4, 6, 7, 8, 9, 10, 11,
           2, 3, 4, 6, 7, 8, 9, 10, 11, 2, 3, 4, 6, 7, 8, 9, 10, 11};

        imagesCard.Clear();

        for (int i = 0; i < copyCards.Count; i++)
        {
            imagesCard.Insert(i, copyCards[i]);
        }
    }

    public void TakeCardPlayer()
    {
        
        int temp = Random.Range(0, cardValues.Count);
        if (indexPlayer >= 2) player.imageCard[indexPlayer].SetActive(true);
        player.imageCard[indexPlayer].GetComponent<SpriteRenderer>().sprite = imagesCard[temp];
        player.playerPoints += cardValues[temp];
        imagesCard.RemoveAt(temp);
        cardValues.RemoveAt(temp);
        indexPlayer++;
    }

    public void TakeFirstCardEnemy()
    {
        int temp = Random.Range(0, cardValues.Count);
        enemy.imageCard1.GetComponent<SpriteRenderer>().sprite = imagesCard[temp];
        enemy.enemyPoints += cardValues[temp];
        imagesCard.RemoveAt(temp);
        imagesCard.RemoveAt(temp);
        enemy.imageCard1.SetActive(false);
    }

    public void TakeCardEnemy()
    {
        int temp = Random.Range(0, cardValues.Count);
        if (indexEnemy >= 1) enemy.imageCard2345[indexEnemy].SetActive(true);
        enemy.imageCard2345[indexEnemy].GetComponent<SpriteRenderer>().sprite = imagesCard[temp];
        enemy.enemyPoints += cardValues[temp];
        imagesCard.RemoveAt(temp);
        cardValues.RemoveAt(temp);
        indexEnemy++;
    }
}
