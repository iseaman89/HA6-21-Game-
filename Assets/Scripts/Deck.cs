using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class Deck : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerHand, enemyHand;
    [SerializeField] private List<Sprite> imagesCard = new List<Sprite>(36);
    [SerializeField] private List<Sprite> copyCards = new List<Sprite>(36);
    [SerializeField] private List<int> cardValues;
    [SerializeField] private GameObject cardback;


    [Inject] private Player player;
    [Inject] private Enemy enemy;

    private int indexPlayer;
    private int indexEnemy;

    private bool aceTakedYetPlayer = false;
    private bool aceTakedYetEnemy = false;

    

    public GameObject Cardback { get => cardback; set => cardback = value; }

    public void NewGame()
    {
        indexPlayer = 0;
        indexEnemy = 0;

        player.PlayerPoints = 0;
        enemy.EnemyPoints = 0;

        aceTakedYetPlayer = false;
        aceTakedYetEnemy = false;

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

        if (indexPlayer >= 2) player.ImageCard[indexPlayer].SetActive(true);
        player.ImageCard[indexPlayer].GetComponent<SpriteRenderer>().sprite = imagesCard[temp];

        if (cardValues[temp] == 11 && !aceTakedYetPlayer)
        {
            player.PlayerPoints += cardValues[temp];
            aceTakedYetPlayer = true;
        }
        else if (cardValues[temp] == 11 && aceTakedYetPlayer)
        {
            player.PlayerPoints += 1;
        }
        else
        {
            player.PlayerPoints += cardValues[temp];
        }

        playerHand.text = "Your Hand: " + player.PlayerPoints.ToString();

        imagesCard.RemoveAt(temp);
        cardValues.RemoveAt(temp);

        indexPlayer++;
    }

    public void TakeFirstCardEnemy()
    {
        int temp = Random.Range(0, cardValues.Count);

        enemy.ImageCard1.GetComponent<SpriteRenderer>().sprite = imagesCard[temp];

        if (cardValues[temp] == 11)
        {
            enemy.EnemyPoints += cardValues[temp];
            aceTakedYetEnemy = true;
        }
        else
        {
            enemy.EnemyPoints += cardValues[temp];
        }

        enemyHand.text = "Dealer Hand: " + enemy.EnemyPoints.ToString();

        imagesCard.RemoveAt(temp);
        cardValues.RemoveAt(temp);

        enemy.ImageCard1.SetActive(false);
    }

    public void TakeCardEnemy()
    {
        int temp = Random.Range(0, cardValues.Count);

        if (indexEnemy >= 1) enemy.ImageCard2345[indexEnemy].SetActive(true);

        enemy.ImageCard2345[indexEnemy].GetComponent<SpriteRenderer>().sprite = imagesCard[temp];

        if (cardValues[temp] == 11 && !aceTakedYetEnemy)
        {
            enemy.EnemyPoints += cardValues[temp];
            aceTakedYetEnemy = true;
        }
        else if (cardValues[temp] == 11 && aceTakedYetEnemy)
        {
            enemy.EnemyPoints += 1;
        }
        else
        {
            enemy.EnemyPoints += cardValues[temp];
        }

        enemyHand.text = "Dealer Hand: " + enemy.EnemyPoints.ToString();

        imagesCard.RemoveAt(temp);
        cardValues.RemoveAt(temp);

        indexEnemy++;
    }
}