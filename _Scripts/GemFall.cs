using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class GemFall : MonoBehaviour
{
    public float time;

    public int countUpSpeed = 5;
    public float spawnInterval = 2f;
    public GameObject addTime;
    List<GameObject> subPrefab = new List<GameObject>();
    public GameObject subPointPrefab;

    List<GameObject> addPrefab = new List<GameObject>();
    public GameObject addPointPrefab;

    List<GameObject> upSpeedPrefab = new List<GameObject>();
    public GameObject upSpeed;

    List<GameObject> listObjectMoves = new List<GameObject>();

    public bool isGameover = false;

    void Start()
    {
        // Initialize lists
        addPointPrefab.SetActive(true);
        subPointPrefab.SetActive(true);
        upSpeed.SetActive(true);
    }

    void Update()
    {
        // if(isGameover)
        // Check for spawning gems
        CheckedSpawn();
        Debug.Log("hello");
    }

    private void CheckedSpawn()
    {
        int x = UnityEngine.Random.Range(0, 2);
        // Debug.Log(x);
        this.time += Time.deltaTime;
        // Debug.Log(this.timer);
        if (time >= spawnInterval)
        {
            if (ScoreManager.remainingTime % 2 == 0)
            {
                if (x == 1)
                    SpawnAdd();
                SpawnSub();
            }
            if (this.countUpSpeed > 0)
                SpawnUpSpeed();
            time = 0;
        }
    }

    private void SpawnAdd()
    {
        Vector2 positionAddItem = Position();

        GameObject newAddPrefab = Instantiate(
            this.addPointPrefab,
            positionAddItem,
            Quaternion.identity
        );
        addPrefab.Add(newAddPrefab);
        listObjectMoves.Add(newAddPrefab);
    }

    private void SpawnSub()
    {
        Vector2 positionSubItem = Position();
        GameObject newSubPrefab = Instantiate(
            this.subPointPrefab,
            positionSubItem,
            Quaternion.identity
        );
        subPrefab.Add(newSubPrefab);
        listObjectMoves.Add(newSubPrefab);
    }

    // Spawn Up Speed (Implement functionality here if needed)
    private void SpawnUpSpeed()
    {
        Vector2 positionSubItem = Position();

        if (time != 0 && subPrefab.Count > 3 && subPrefab.Count > 2)
        {
            GameObject newUpSpeedPrefab = Instantiate(
                this.upSpeed,
                positionSubItem,
                Quaternion.identity
            );
            addPrefab.Add(newUpSpeedPrefab);
            countUpSpeed--;
        }
    }

    public void StopAll()
    {
        for (int i = 0; i < listObjectMoves.Count; i++) {
            var gameMove = listObjectMoves[i].GetComponent<GemMove>();
            if(gameMove!= null) gameMove.speed =0;

            var gameMove1 = listObjectMoves[i].GetComponent<GemMove1>();
            if(gameMove1!= null) gameMove1.speed =0;

            var gameMove2 = listObjectMoves[i].GetComponent<GemMove2>();
            if(gameMove2!= null) gameMove2.speed =0;
            
         }
    }

    // Random Spawn
    private Vector2 Position()
    {
        float x = UnityEngine.Random.Range(-8.5f, 8.5f);
        float y = 4.5f;
        Vector2 positionGem = new Vector2(x, y);
        return positionGem;
    }
}
