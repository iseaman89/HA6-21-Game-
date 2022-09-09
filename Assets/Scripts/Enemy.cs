using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int enemyPoints;

    [SerializeField] private GameObject imageCard1;
    [SerializeField] private GameObject[] imageCard2345 = new GameObject[7];

    public GameObject ImageCard1 { get => imageCard1; set => imageCard1 = value; }
    public GameObject[] ImageCard2345 { get => imageCard2345; set => imageCard2345 = value; }
    public int EnemyPoints { get => enemyPoints; set => enemyPoints = value; }
}