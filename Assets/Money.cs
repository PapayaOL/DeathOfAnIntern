using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public int money = 100;
    // Start is called before the first frame update
    public void UpdateMoney(int moneyChange) {
        money += moneyChange;
        if (money <= 0)
        {
            GetComponent<TextMeshProUGUI>().text = "$" + money + "\nYou are broke!";
        }
        else {
            GetComponent<TextMeshProUGUI>().text = "$" + money;
        }
        
    }
}
