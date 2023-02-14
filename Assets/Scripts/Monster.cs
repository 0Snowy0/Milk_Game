using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject player;
    public float speed = 11f;
    public float damage = 10f;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
            player.GetComponent<Player>().Hit(damage);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;


    }
}
