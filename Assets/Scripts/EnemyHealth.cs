using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int healthValue;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //This will check every frame whether or not the health is less than zero. If less than zero, destroy the gameobject.
        if (healthValue <= 0)
        {
            Destroy(gameObject);
        }

    }

    //This function runs when the collision occurs
    //After a collision is detected, it checks its TAG.
    //IF the tag is "bullet", the health will decrease by 1.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            healthValue -= 1;
        }
    }
}
