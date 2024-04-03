using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip1 : MonoBehaviour
{
    public GameObject flip;

    // Start is called before the first frame update
    void Start()
    {
        this.Flip();
    }

    // Update is called once per frame
    void Update(){ }

    private void Flip()
    {
        flip.transform.Rotate(0f, 0f, -130f);
    }
}
