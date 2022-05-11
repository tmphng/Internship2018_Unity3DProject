using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTheLight : MonoBehaviour {

    public Light lightning;

	// Use this for initialization
	void Start () {
        lightning = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            lightning.enabled = !lightning.enabled;
            lightning.intensity = 0f;
        }
	}

    void FixedUpdate()
    {
        if (lightning.enabled == true)
        {
            lightning.intensity = Mathf.Lerp(lightning.intensity, 10f, 1f * Time.deltaTime);
        }
    }
}
