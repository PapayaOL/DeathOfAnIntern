using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FileCounter : MonoBehaviour
{
    public int filesRemaining = 100;
    // Start is called before the first frame update
    public void UpdateFiles() {
        filesRemaining--;
        GetComponent<TextMeshProUGUI>().text = "Files Remaining: " + filesRemaining;
        if (filesRemaining <= 0) {
            GetComponent<TextMeshProUGUI>().text = "You win! Thanks for playing.";
        }
    }
}
