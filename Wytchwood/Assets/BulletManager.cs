using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletManager : MonoBehaviour
{


    private PlayerManager pl;


    private void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Room"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy") || collision.CompareTag("Soul"))
        {
            collision.GetComponent<EnemyMovement>().Death();
            Destroy(gameObject);
        }
    }
}
