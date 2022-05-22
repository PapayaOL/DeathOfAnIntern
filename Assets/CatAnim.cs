using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnim : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    public void Pet() {
        animator.SetBool("Petting", true);
    }

    public void StopPet() {
        animator.SetBool("Petting", false);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
