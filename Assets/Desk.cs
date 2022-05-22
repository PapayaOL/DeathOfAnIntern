using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desk : MonoBehaviour
{
    public Player player;
    public GameObject inputPrompt;
    public GameObject progressBar;
    public GameManager gameManager;
    public GameObject deskArrow;
    public float fileSpeed = 0.015f;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.inputState = "work";
        deskArrow.SetActive(false);
        showPrompt();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player.playerState != null) {
            hidePrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.inputState = null;
        player.playerState = null;
        hidePrompt();
    }
    public void showPrompt() { 
        
        inputPrompt.SetActive(true);
    }

    public void hidePrompt() { 
        inputPrompt.SetActive(false);
    }

    public void UpdateFileProgress() {
        hidePrompt();
        progressBar.SetActive(true);
        gameManager.fileProgress += fileSpeed;
        if (gameManager.fileProgress >= 1) {
            gameManager.FileCompleted();
        }
        progressBar.GetComponent<Slider>().value = gameManager.fileProgress;
    }

    public void StopWorking() {

        progressBar.SetActive(false);
    }

    private void Start()
    {
        progressBar.GetComponent<Slider>().maxValue = 1;
    }

}
