using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    float hunger = 1;
    Slider slider;
    public Gradient gradient;
    public GameObject fill;
    public GameManager gameManager;
    public GameObject hungerArrow;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;
        fill.GetComponent<Image>().color = gradient.Evaluate(hunger);
        slider.maxValue = 1;
    }
    public void UpdateHunger(float change)
    {
        hunger += change;
        slider.value = hunger;
        if (hunger <= 0.25 && gameManager.sleepTutorial)
        {
            hungerArrow.SetActive(true);
        }
        else
        {
            hungerArrow.SetActive(false);
        }
        fill.GetComponent<Image>().color = gradient.Evaluate(hunger);
        if (hunger <= 0)
        {
            gameManager.GameOver(0);
        }
    }
}
