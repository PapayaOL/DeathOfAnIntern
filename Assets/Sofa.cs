using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sofa : MonoBehaviour
{
    public Player player;
    public GameObject inputPrompt;
    public GameManager gameManager;
    public GameObject sofaArrow;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.inputState = "sleep";
        sofaArrow.SetActive(false);
        showPrompt();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player.playerState != null)
        {
            hidePrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.inputState = null;
        player.playerState = null;
        hidePrompt();
    }
    public void showPrompt()
    {
        inputPrompt.SetActive(true);
    }

    public void hidePrompt()
    {
        inputPrompt.SetActive(false);
    }




    private void Start()
    {
    }
}
