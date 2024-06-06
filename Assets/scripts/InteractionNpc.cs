using UnityEngine;

public class InteractionNpc : MonoBehaviour
{
    private int currentText = 0;
    public GameObject[] texts;

    public GameObject maincanvas;

    private LevelManager levelManager;

    private bool isGameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].SetActive(false);
        }
        maincanvas.SetActive(false);
        levelManager =  FindAnyObjectByType<LevelManager>();
    }
    private void startGame()
    {
        texts[currentText].SetActive(true);
        isGameStarted = true;
        maincanvas.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            startGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGameStarted)
        {


            if (currentText < texts.Length -1)
            {
                texts[currentText].SetActive(false);
                currentText++;
                texts[currentText].SetActive(true);

            }
            else
            {
                texts[currentText].SetActive(false);
                maincanvas.SetActive(false);
                levelManager.NextLevel();
                return;
            }

        }
    }
}
