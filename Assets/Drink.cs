using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Drink : MonoBehaviour
{
    public Player player;
    public GameObject inputPrompt;
    public GameManager gameManager;
    public GameObject drinkPrompt;
    public GameObject inputPrompt2;
    public List<GameObject> drinkPromptList;
    public GameObject sanityIndicator;
    public GameObject hungerIndicator;
    public GameObject sleepIndicator;
    int curSelect = 0;

    float pop = 0.1f;
    float redbull = 0.2f;
    float redbullSanity = -0.05f;
    float beer = 0.4f;
    float beerSleep = -0.2f;
    int popCost = -4;
    int redbullCost = -8;
    int beerCost = -15;



    public Hunger hunger;
    public Sleep sleep;
    public Money money;
    public Sanity sanity;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (money.money <= 0)
        {
            inputPrompt2.SetActive(true);
        }
        else
        {
            player.inputState = "drink";
            ShowEffect();
            showPrompt();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.inputState = null;
        player.playerState = null;
        hidePrompt();
        HideEffect();
    }
    public void showPrompt()
    {
        drinkPrompt.SetActive(true);
        inputPrompt.SetActive(true);
    }

    public void hidePrompt()
    {
        inputPrompt.SetActive(false);
        drinkPrompt.SetActive(false);
        inputPrompt2.SetActive(false);
    }

    public void LeftSelect()
    {
        if (curSelect > 0)
        {
            drinkPromptList[0].SetActive(false);
            drinkPromptList[1].SetActive(false);
            drinkPromptList[2].SetActive(false);
            
            curSelect--;
            drinkPromptList[curSelect].SetActive(true);
            ShowEffect();

        }
    }

    void ShowEffect() {
        hungerIndicator.SetActive(false);
        sleepIndicator.SetActive(false);
        sanityIndicator.SetActive(false);
        if (curSelect == 0)
        {
            hungerIndicator.SetActive(true);
            hungerIndicator.GetComponent<TextMeshProUGUI>().text = "+";
            hungerIndicator.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        else if (curSelect == 1)
        {
            sanityIndicator.SetActive(true);
            sanityIndicator.GetComponent<TextMeshProUGUI>().text = "-";
            sanityIndicator.GetComponent<TextMeshProUGUI>().color = Color.red;
            sleepIndicator.SetActive(true);
            sleepIndicator.GetComponent<TextMeshProUGUI>().text = "+";
            sleepIndicator.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        else if (curSelect == 2)
        {
            sanityIndicator.SetActive(true);
            sanityIndicator.GetComponent<TextMeshProUGUI>().text = "++";
            sanityIndicator.GetComponent<TextMeshProUGUI>().color = Color.green;
            sleepIndicator.SetActive(true);
            sleepIndicator.GetComponent<TextMeshProUGUI>().text = "--";
            sleepIndicator.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }

    public void RightSelect()
    {
        if (curSelect < 2)
        {
            drinkPromptList[0].SetActive(false);
            drinkPromptList[1].SetActive(false);
            drinkPromptList[2].SetActive(false);
            curSelect++;
            drinkPromptList[curSelect].SetActive(true);
            ShowEffect();
        }
    }

    public void Purchase()
    {
        if (curSelect == 0)
        {
            hunger.UpdateHunger(pop);
            money.UpdateMoney(popCost);
        }
        else if (curSelect == 1)
        {
            sleep.UpdateSleep(redbull);
            sanity.UpdateSanity(redbullSanity);
            money.UpdateMoney(redbullCost);
        }
        else if (curSelect == 2)
        {
            sanity.UpdateSanity(beer);
            sleep.UpdateSleep(beerSleep);
            money.UpdateMoney(beerCost);
        }
        hidePrompt();
    }

    void HideEffect() {
        hungerIndicator.SetActive(false);
        sleepIndicator.SetActive(false);
        sanityIndicator.SetActive(false);
    }
}
