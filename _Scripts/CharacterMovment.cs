using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactaerMovement : MonoBehaviour
{
    private float speed;
    public float tallJum = 0.8f;
    private Animator animator;
    private int canJum = 2;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        speed = GemMove2.pointSpeedUp;
        // Debug.Log(speed);
        this.CharacterMoving();
        this.CharacterFlip();
        this.CharacterJum();
        // Debug.Log(this.canJum);
    }

    private void CharacterMoving()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0;
        animator.SetBool("isMoving", isMoving);
        if (isMoving)
        {
            transform.position += new Vector3(moveHorizontal * speed, 0f, 0f);
        }
    }

    private void CharacterJum()
    {
        if (Input.GetButtonDown("Jump") && this.canJum > 0)
        {
            transform.position += new Vector3(0f, this.tallJum + this.speed + 0.04f, 0f);
            this.canJum--;
        }
    }

    private void CharacterFlip()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")|other.gameObject.CompareTag("Box"))
            this.canJum = 2;
            
    }
}
