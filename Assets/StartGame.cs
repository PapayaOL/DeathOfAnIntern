using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioManager audioManager;
    public void StartTheGame() {
        audioManager.Stop("Main");
        SceneManager.LoadScene("SampleScene");
    }

    private void Start()
    {
        audioManager.Play("Main");
    }
}
