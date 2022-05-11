using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public GameObject bulletOject;
    public float timeDestroy = 2f;

    void Start()
    {
        Destroy(bulletOject, timeDestroy);
    }
}
