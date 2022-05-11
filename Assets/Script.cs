using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour {

    public float moveSpeed = 10f;
    public float turnSpeed = 100f;
    bool OnTheGround = false;
    public GameObject childObject;
    public GameObject thisObject;
    public float countdown = 0.0f;
    public GameObject Light;

    private TurnTheLight scriptLight;

    void Awake()
    {
        scriptLight = Light.GetComponent<TurnTheLight>();
    }

    void Start () {

        // 3. Debug.Log
        Debug.Log("x = ");
        Debug.Log(transform.position.x);

        print("Hello!");

        thisObject = this.gameObject;

    }

    void Update () {

        // 1. Behaviour Component
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }

        // 2. Function
        if (OnTheGround == false)
        {
            GetPosition();
        }

        // 13. Translate and Rotate
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log(childObject.activeSelf);
            childObject.SetActive(!childObject.activeSelf);
            Debug.Log(childObject.activeSelf);
        }

        countdown += Time.deltaTime;
        if (countdown >= 20f)
            scriptLight.lightning.enabled = true;

    }

    // 2. Function
    void GetPosition()
    {
        /*float counter = 0f;
        while (OnTheGround == false)
        {
            counter += 1f;*/
            if (this.transform.position.y <= 0f)
            {
                print("I'm on the ground!");
                OnTheGround = true;
                //counter = counter * Time.deltaTime;
                //print(counter);
            }
        //}
    }
    // 19. OnMouseDown
    /*void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Rigidbody>().AddForce(-transform.forward * 500f);
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
    */
}
