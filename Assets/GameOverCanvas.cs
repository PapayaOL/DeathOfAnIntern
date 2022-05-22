using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public void GameOver() { 
        gameObject.SetActive(true);
        Invoke("GameOverAnim", 3f);
        
    }

    void GameOverAnim() {
        GetComponent<Animator>().SetBool("GameOver", true);
    }
}
