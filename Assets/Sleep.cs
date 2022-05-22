using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour
{
    float sleep = 1;
    Slider slider;
    public Gradient gradient;
    public GameObject fill;
    public GameManager gameManager;
    public Player player;
    public GameObject sleepArrow;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;
        fill.GetComponent<Image>().color = gradient.Evaluate(sleep);
        slider.maxValue = 1;
    }
    public void UpdateSleep(float change)
    {
        sleep += change;
        slider.value = sleep;
        fill.GetComponent<Image>().color = gradient.Evaluate(sleep);
        if (sleep <= 0.25 && gameManager.sleepTutorial)
        {
            sleepArrow.SetActive(true);
        }
        else {
            sleepArrow.SetActive(false);
        }
        if (sleep <= 0)
        {
            if (player.inputState == "drink")
            {
                gameManager.GameOver(3);
            }
            else {
                gameManager.GameOver(2);
            }
            
        }
    }
}
