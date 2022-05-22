using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Food : MonoBehaviour
{
    public Player player;
    public GameObject inputPrompt;
    public GameManager gameManager;
    public GameObject FoodPrompt;
    public List<GameObject> FoodPromptList;
    public GameObject inputPrompt2;
    int curSelect = 0;
    public GameObject sanityIndicator;
    public GameObject hungerIndicator;
    public GameObject sleepIndicator;
    public GameObject hungerArrow;

    float fries = 0.25f;
    float burg = 0.5f;
    float friesnburg = 0.70f;
    float friesnburgSanity = 0.05f;
    int friesCost = -10;
    int burgCost = -20;
    int friesnburgCost = -30;



    public Hunger hunger;
    public Money money;
    public Sanity sanity;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {

        hungerArrow.SetActive(false);
        
        if (money.money <= 0) {
            inputPrompt2.SetActive(true);
        } else {
            player.inputState = "food";
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
        FoodPrompt.SetActive(true);
        inputPrompt.SetActive(true);
    }

    public void hidePrompt()
    {
        inputPrompt.SetActive(false);
        FoodPrompt.SetActive(false);
        inputPrompt2.SetActive(false);
    }

    public void LeftSelect() {
        if (curSelect > 0) {
            FoodPromptList[0].SetActive(false);
            FoodPromptList[1].SetActive(false);
            FoodPromptList[2].SetActive(false);
            curSelect--;
            FoodPromptList[curSelect].SetActive(true);
            ShowEffect();
        }
    }

    public void RightSelect()
    {
        if (curSelect < 2)
        {
            FoodPromptList[0].SetActive(false);
            FoodPromptList[1].SetActive(false);
            FoodPromptList[2].SetActive(false);
            curSelect++;
            FoodPromptList[curSelect].SetActive(true);
            ShowEffect();

        }
    }

    public void Purchase() {
        if (curSelect == 0)
        {
            hunger.UpdateHunger(fries);
            money.UpdateMoney(friesCost);
        }
        else if (curSelect == 1)
        {
            hunger.UpdateHunger(burg);
            money.UpdateMoney(burgCost);
        }
        else if (curSelect == 2) {
            hunger.UpdateHunger(friesnburg);
            sanity.UpdateSanity(friesnburgSanity);
            money.UpdateMoney(friesnburgCost);
        }
        hidePrompt();
    }

    void ShowEffect()
    {
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
            hungerIndicator.SetActive(true);
            hungerIndicator.GetComponent<TextMeshProUGUI>().text = "++";
            hungerIndicator.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        else if (curSelect == 2)
        {
            sanityIndicator.SetActive(true);
            sanityIndicator.GetComponent<TextMeshProUGUI>().text = "+";
            sanityIndicator.GetComponent<TextMeshProUGUI>().color = Color.green;
            hungerIndicator.SetActive(true);
            hungerIndicator.GetComponent<TextMeshProUGUI>().text = "+++";
            hungerIndicator.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
    }

    void HideEffect()
    {
        hungerIndicator.SetActive(false);
        sleepIndicator.SetActive(false);
        sanityIndicator.SetActive(false);
    }
}
