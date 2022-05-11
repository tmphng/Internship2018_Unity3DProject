using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBricks : MonoBehaviour {

    public Rigidbody bullet;
    public Transform posBarrelEnd;
    public float puiss = 100f;

    public float timeDestroy = 2f;
    //public int nbBullets = 5;
    public List <Rigidbody> bulletList = new List <Rigidbody> ();

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(bullet, posBarrelEnd.position, posBarrelEnd.rotation) as Rigidbody;
            bulletInstance.AddForce(posBarrelEnd.forward * puiss);

            bulletList.Add(bulletInstance);
        }
        Destr(bulletList, timeDestroy);
    }

    void Destr(List <Rigidbody> toDestroy, float timeToDestroy)
    {
       for(int i = 0; i< toDestroy.Count; i++)
        {
            Destroy(toDestroy[i], timeToDestroy);
        }
    }
}
