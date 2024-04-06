using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GemMove2 : MonoBehaviour
{
    public static float pointSpeedUp = 0.02f;
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
        if (other.gameObject.CompareTag("Player") && gameObject.name != "DarkMountain")
        {
            audioSource.Play();
            pointSpeedUp += 0.01f;
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Ground") && gameObject.name != "DarkMountain")
            Destroy(gameObject);
    }

    private void MoveDown()
    {
        transform.Translate(Vector2.down * ScoreManager.timeMoveSpeed * speed);
    }
}
