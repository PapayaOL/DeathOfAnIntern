using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public Player player;
    public GameObject inputPrompt;
    public GameManager gameManager;
    public GameObject sanityArrow;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
            sanityArrow.SetActive(false);
        player.inputState = "cat";
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

}
