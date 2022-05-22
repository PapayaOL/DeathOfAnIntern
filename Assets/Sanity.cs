using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    float sanity = 1;
    Slider slider;
    public Gradient gradient;
    public GameObject fill;
    public GameManager gameManager;
    public Player player;
    public GameObject sanityArrow;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;
        fill.GetComponent<Image>().color = gradient.Evaluate(sanity);
        slider.maxValue = 1;
    }
    public void UpdateSanity(float sanityChange) {
        sanity += sanityChange;
        fill.GetComponent<Image>().color = gradient.Evaluate(sanity);
        slider.value = sanity;
        if (sanity <= 0.25 && gameManager.sleepTutorial)
        {
            sanityArrow.SetActive(true);
        }
        else
        {
            sanityArrow.SetActive(false);
        }
        if (sanity <= 0) {
            if (player.inputState == "drink")
            {
                gameManager.GameOver(4);
            }
            else {
                gameManager.GameOver(1);
            }
            
        }
    }
    
}
