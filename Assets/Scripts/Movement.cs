using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour {
   
    public float speed = 2f;
    public Animator animator;


    void Start() {
       animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        moveCharacter();
    }

    public void moveCharacter() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);

        AnimateMovement(direction);

        transform.position += direction * speed * Time.deltaTime;
    }

    void AnimateMovement(Vector3 direction) {
        if (animator != null) {

            if (direction.magnitude > 0) {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
