using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    public Gradient gradient;
    float timeOfDay = 0.4f;
    public int days = 0;
    public GameObject night;
    bool nightShift = true;
    public GameObject day;
    public SpriteRenderer spriteRenderer;
    public int trackNum = 1;
    public AudioManager audioManager;
    Color temp = Color.white;

    public void TimeMove() 
    {
        temp.a = 0f;
        spriteRenderer.color = gradient.Evaluate(timeOfDay);
        timeOfDay += 0.0005f;
        day.transform.Translate(new Vector3(-0.008f, 0, 0));
        night.transform.Translate(new Vector3(-0.01f, 0, 0));
        if (timeOfDay > 1)
        {
            nightShift = true;
            day.transform.SetPositionAndRotation(new Vector3(18, 3, 0), Quaternion.identity);
            day.GetComponent<SpriteRenderer>().color = temp;
            days++;
            timeOfDay = 0;
        }
        if (timeOfDay > 0.4 && nightShift) {
            nightShift = false;
            night.GetComponent<SpriteRenderer>().color = temp;
            night.transform.SetPositionAndRotation(new Vector3(18, 3, 0), Quaternion.identity);
        }
        if (days >= 3 && trackNum == 1)
        {
            audioManager.ChangeTrackAfterFinish("Track2");
            trackNum++;
        }
        else if (days >= 8 && trackNum == 2)
        {
            trackNum++;
            audioManager.ChangeTrackAfterFinish("Track3");
        }


    }

    private void Start()
    {
        spriteRenderer.color = gradient.Evaluate(timeOfDay);
    }

}
