using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetText(int fileRemaining, int causeOfDeath) {
        string death;
        if (causeOfDeath == 0)
        {
            death = "Starvation";
        }
        else if (causeOfDeath == 1)
        {
            death = "Insanity";
        }
        else if (causeOfDeath == 2)
        {
            death = "Sleep Deprevation";
        }
        else if (causeOfDeath == 3)
        {
            death = "Alcohol overdose";
        }
        else if (causeOfDeath == 4)
        {
            death = "Energy drink overdoes";
        }
        else {
            death = "UNKNOWN";
        }
        GetComponent<TextMeshProUGUI>().text = "You Died\n" + "Files Remaining: "+ fileRemaining + "\nCause of Death: " + death;
    }
}
