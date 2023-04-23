using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed; 
    public float checkRadius; 
    public float attackRadius; 

    public bool shouldRotate; 
    public LayerMask whatIsPlayer; 

    private Transform target; 
    private Rigidbody2D rb;

    private Animator anim; 
    private Vector2 movement; 
    public Vector3  dir; 

    private bool isInChaseRange; 
    private bool isInAttackRange;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>(); 
        target = GameObject.FindWithTag("Player").transform; 
    }


    void Update()
    {
        anim.SetBool("isFlying", isInChaseRange); 

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer); 
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer); 

        dir = target.position - transform.position; 
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg; 

        dir.Normalize(); 
        movement = dir; 

        if(shouldRotate) {
           anim.SetFloat("X", dir.x); 
            anim.SetFloat("Y", dir.y); 
        }
// Debug.Log("Moving character");
    }

    private void FixedUpdate()  {
    
        if(isInChaseRange && !isInAttackRange) {
            MoveCharacter(movement); 
        //    OnDrawGizmosSelected(); 
        }
        if(isInAttackRange) {
            rb.velocity = Vector2.zero; 
        }
    }
    
    private void MoveCharacter(Vector2 dir) {
       
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime)); 
    }

    // void OnDrawGizmosSelected(){
    //     Gizmos.DrawWireSphere(transform.position, checkRadius); 
    // } 
}
