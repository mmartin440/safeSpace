using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    // public float moveSpeed; // this tells you the speed of the player 
    // public bool isMoving;
    // public Vector2 input; // vector is something in unity, hold x,y value 

    // private void Update() {
    //     if(!isMoving) {
    //         input.x = Input.GetAxisRaw("Horizontal"); // Input.GetAxisRow manages the direction of your player
    //         input.y = Input.GetAxisRaw("Vertical"); 

    //         if(input.x !=0) input.y = 0; 
    //         if(input != Vector2.zero) {
    //             var targetPos = transform.position; // transform.position are unity functions that control the thing 
    //             targetPos.x += input.x; // you are adding input.x inside the varible 
    //             targetPos.y += input.y; 
    //             StartCoroutine(Move(targetPos)); 
    //         }
    //     }
    // }

    // IEnumerator Move (Vector3 targetPos) {
    //     isMoving = true; 
    //     while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) { // if ther is any movement bigger than zero, then that means the user moved 
    //         transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime); // Time.deltaTime helps with frame rate on other computers 
    //         yield return null; 
    //     }
    //     transform.position = targetPos; 

    //     isMoving = false; 
    // }

   [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D rb; 
    private Vector2 movementDirection; 

    void Start() {
        rb = GetComponent<Rigidbody2D>(); 

    }

    void Update() {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); 
    }
    
    void FixedUpadate() {
        rb.velocity = movementDirection * moveSpeed; 
    }

}
