using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    public GameObject player;
    public Animator zombieAnimator;
    private float chaseDist = 15f;
    public float speed = 5f;
    public float damage = 10f;
    private float health = 100;

    public void Hit(float bDamage)
    {
        health -= bDamage;

        if (health <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < chaseDist)
        {
            GetComponent<NavMeshAgent>().destination = player.transform.position;
        }

        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            zombieAnimator.SetBool("isRunning", true);
        }
        else
        {
            zombieAnimator.SetBool("isRunning", false);
        }

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Player>().Hit(damage);
        }
    }
}
