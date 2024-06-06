using UnityEngine;

public class StarCollecting : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject star;
    private PlayerMovement playerMovement;
    private void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(star, spawnPoints[i].position, Quaternion.identity);
        }
    }

    private void Update()
    {
       if (playerMovement.StarCount ==5)
        {
            Debug.Log("bitti");

        }
    }
}
