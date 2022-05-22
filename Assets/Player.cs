using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //movement
    public float moveSpeed;
    public GameObject desk;
    Vector2 movement;
    Rigidbody2D rb;
    Animator animator;
    float curSpeed;

    //states
    public string playerState = null;
    public string inputState = null;

    //references
    public GameManager gameManager;
    public GameObject sofaPos;
    public Food foodVending;
    public Drink drinkVending;
    public CatAnim cat;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputState != "dead") {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            curSpeed = movement.sqrMagnitude;
        }
            
        if (inputState == "food")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                foodVending.LeftSelect();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                foodVending.RightSelect();
            }
        }
        else if (inputState == "drink") {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                drinkVending.LeftSelect();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                drinkVending.RightSelect();
            }
        }

            if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (inputState) {
                case "work":
                    playerState = "work";
                    animator.SetBool("Working", true);
                    break;
                case "sleep":
                    gameManager.sleepTutorial = false;
                    playerState = "sleep";
                    rb.isKinematic = true;
                    transform.position = new Vector2(sofaPos.transform.position.x+0.5f, sofaPos.transform.position.y);
                    animator.SetBool("Sleeping", true);
                    break;
                case "food":
                    foodVending.Purchase();
                    gameManager.hungerTutorial = false;
                    break;
                case "drink":
                    drinkVending.Purchase();
                    break;
                case "cat":
                    playerState = "cat";
                    cat.Pet();
                    gameManager.sanityTutorial = false;
                    animator.SetBool("Petting", true);
                    break;
                default:
                    break;

            }
            
        }

        
        if (curSpeed > 0.01) {
            animator.SetBool("Working", false);
            animator.SetBool("Sleeping", false);
            animator.SetBool("Petting", false);
            cat.StopPet();
            rb.isKinematic = false;
            playerState = null;
        }

        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", curSpeed);
    }

    public void Die() {
        animator.SetBool("Working", false);
        animator.SetBool("Sleeping", false);
        animator.SetBool("Petting", false);
        animator.SetBool("Sleeping", true);
        playerState = null;
        inputState = "dead";
        GetComponent<SpriteRenderer>().sortingOrder = 10;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        
    }


}
