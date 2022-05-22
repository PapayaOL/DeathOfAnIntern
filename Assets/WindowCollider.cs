using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCollider : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Color temp = GetComponent<SpriteRenderer>().color;
        temp.a = 1f;
        print("hi");
        if (collision.tag == "sky")
        {

            collision.gameObject.GetComponent<SpriteRenderer>().color = temp;
        }
    }
}
