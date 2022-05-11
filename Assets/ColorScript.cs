using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class ColorScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}