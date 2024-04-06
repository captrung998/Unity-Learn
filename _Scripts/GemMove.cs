using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GemMove : MonoBehaviour
{
    public float speed = 1f;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        this.MoveDown();
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.name != "GemPrefab")
        {
            audioSource.Play();
            ScoreManager.AddScore(1);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Ground") && gameObject.name != "GemPrefab")
            Destroy(gameObject);
    }

    private void MoveDown()
    {
        transform.Translate(Vector2.down * ScoreManager.timeMoveSpeed * speed);
    }
}
