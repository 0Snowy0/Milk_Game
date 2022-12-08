using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject prefabProjectile;
    private GameObject launchedProjectile;

    //Projectile force is the force at which the projectile will be launched
    public float projectileForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame.

    void Update()
    {

        //If left click is pressed down, launch a projectile. 
        //then add a force to the projectile 
        //added to the camera so that the projectile goes in the direction your camera is facing.
        if (Input.GetMouseButtonDown(1))
        {
            launchedProjectile = Instantiate(prefabProjectile, transform.position + (transform.forward * 3), Quaternion.identity);
            launchedProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce, ForceMode.Impulse);
        }
    }
}
