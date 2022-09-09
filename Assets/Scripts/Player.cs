using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerPoints;
    private int playerScore;

    [SerializeField] private GameObject[] imageCard = new GameObject[8];

    public int PlayerPoints { get => playerPoints; set => playerPoints = value; }
    public int PlayerScore { get => playerScore; set => playerScore = value; }
    public GameObject[] ImageCard { get => imageCard; set => imageCard = value; }
}