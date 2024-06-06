using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    private int levelCount = 0;

    private void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        levels[levelCount].SetActive(true);
    }

    public void NextLevel()
    {
        levels[levelCount].SetActive(false);
        levelCount++;
        levels[levelCount].SetActive(true);
    }
}
