using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnBox : MonoBehaviour
{
    public GameObject box;
    private int countBox;
    public float spawnInterval = 3f;
    private float time = 0f;

    // Update is called once per frame
    void Start()
    {
        this.countBox = ScoreManager.remainingTime / 4;
    }

    void Update()
    {
        SpawnItem();
    }

    private void SpawnItem()
    {
        this.time += Time.deltaTime;
        Vector2 positionBox = Position();
        if (time >= 10 && countBox > 0)
        {
            Instantiate(this.box, positionBox, Quaternion.identity);
            countBox--;
            time = 0;
        }
    }

    private Vector2 Position()
    {
        float x = UnityEngine.Random.Range(-8.5f, 8.5f);
        float y = -4.2f;
        Vector2 positionGem = new Vector2(x, y);
        return positionGem;
    }
}
