using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Desk desk;
    public Money money;
    public FileCounter file;
    public Sanity sanity;
    public Sleep sleep;
    public Hunger hunger;
    public GameOverCanvas gameOverCanvas;
    public GameOverText gameOverText;
    public GameObject mainUI;
    public Sky sky;
    public AudioManager audioManager;
    public int trackNum = 1;
    public GameObject rewardCanvas;
    public GameObject rewardText;

    public float fileProgress = 0;
    int moneyPerFile = 10;
    float sanityDrain = 0.0003f;
    float hungerDrain = 0.0006f;
    float hungerDrainWhileSleep = 0.0004f;
    float sleepDrainWhileCat = 0.0004f;
    float sleepDrain = 0.0005f;
    float sofaSleep = 0.0008f;
    float catSanity = 0.0005f;
    List<int> bonusRange = new List<int> {0, 1, 2, 3, 4};
    int numOfFilesCompleted = 0;
    public float timescale = 1;

    public bool sleepTutorial = true;
    public bool hungerTutorial = true;
    public bool sanityTutorial = true;






    // Start is called before the first frame update
    void Start()
    {
        audioManager.Play("Track1");
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timescale;
    }

    public void FileCompleted() {
        fileProgress = 0;
        file.UpdateFiles();
        numOfFilesCompleted++;
        money.UpdateMoney(moneyPerFile);
        if (numOfFilesCompleted == 5)
        {
            RandomEvent(30);
        }
        else if (numOfFilesCompleted == 10)
        {
            RandomEvent(-1);
        }
        else if (numOfFilesCompleted == 15)
        {
            RandomEvent(20);
        }
        else if (numOfFilesCompleted == 20)
        {
            RandomEvent(-1);
        }
        else if (numOfFilesCompleted == 25)
        {
            RandomEvent(10);
        }
        else if (numOfFilesCompleted == 30)
        {
            RandomEvent(-1);
        }
        else if (numOfFilesCompleted == 40)
        {
            RandomEvent(10);
        }
        else if (numOfFilesCompleted == 50)
        {
            RandomEvent(-1);
        }
        else if (numOfFilesCompleted == 60)
        {
            RandomEvent(10);
        }
        else if (numOfFilesCompleted == 70)
        {
            RandomEvent(10);
        }
        else if (numOfFilesCompleted == 80)
        {
            RandomEvent(10);
        }
        else if (numOfFilesCompleted == 90)
        {
            RandomEvent(10);
        }

    }

    private void FixedUpdate()
    {
        switch (player.playerState)
        {
            case "work":
                sanity.UpdateSanity(-sanityDrain);
                sleep.UpdateSleep(-sleepDrain);
                hunger.UpdateHunger(-hungerDrain);
                desk.UpdateFileProgress();
                sky.TimeMove();
                break;
            case "sleep":
                sleep.UpdateSleep(sofaSleep);
                hunger.UpdateHunger(-hungerDrainWhileSleep);
                sky.TimeMove();
                break;
            case "cat":
                sleep.UpdateSleep(-sleepDrainWhileCat);
                hunger.UpdateHunger(-hungerDrainWhileSleep);
                sanity.UpdateSanity(catSanity);
                sky.TimeMove();
                break;
            default:
                desk.StopWorking();
                break;
        }
    }

    public void GameOver(int causeOfDeath) {
        audioManager.StopAll();
        mainUI.SetActive(false);
        player.Die();
        gameOverCanvas.GameOver();
        gameOverText.SetText(file.filesRemaining, causeOfDeath);
    }

    public void RestartGame() {
        SceneManager.LoadScene("SampleScene");
    }

    public void RandomEvent(int bonus) {
        
        string letterText = "";
        if (bonus > 0)
        {
            letterText = "Good job on your recent file submissions. \nHere is a bonus for ya.\n\n + $" + bonus + " Money";
            money.UpdateMoney(bonus);
        }
        else {
            int randPos = Random.Range(0, bonusRange.Count);
            int randEvent = bonusRange[randPos];
            bonusRange.RemoveAt(randPos);
            if (randEvent == 0)
            {
                letterText = "We addded padding to your sofa to accomodate your wellbeing.\n\n + sleep energy restoration";
                sofaSleep += 0.0001f;
            }
            else if (randEvent == 1)
            {
                letterText = "Looks like you like the cat a lot. \nIt is yours now!.\n\n + sanity restoration from cat";
                catSanity += 0.0001f;
            }
            else if (randEvent == 2)
            {
                letterText = "Your computer is a bit old. \nWe upgraded it so you can work faster.\n\n + file completion speed";
                desk.fileSpeed += 0.001f;
            }
            else if (randEvent == 3)
            {
                letterText = "A new intern joined this month. \nGonna take some of your load from ya.\n\n -10 files remaining";
                file.filesRemaining -= 9;
                file.UpdateFiles();
            }
            else if (randEvent == 4)
            {
                letterText = "Thanks for all the hard work \nYou got a raise!.\n\n + $1 per file";
                moneyPerFile += 1;
            }
        }
        player.playerState = null;
        player.inputState = "dead";
        rewardCanvas.SetActive(true);
        rewardText.GetComponent<TextMeshProUGUI>().text = letterText;
        
        
    }

    public void Resume() {
        player.inputState = null;
        rewardCanvas.SetActive(false);
    }
}
