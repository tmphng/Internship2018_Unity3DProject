using UnityEngine;
using System.Collections;

public class InvokeScript : MonoBehaviour
{
    public GameObject target;
    public float x_pos = 0f;
    public float y_pos = 0f;
    public float z_pos = 0f;
    public float timeSpawn = 2f;

    void Start()
    {
        Invoke("SpawnObject", timeSpawn);
    }

    void SpawnObject()
    {
        Instantiate(target, new Vector3(x_pos, y_pos, z_pos), Quaternion.identity);
    }
}