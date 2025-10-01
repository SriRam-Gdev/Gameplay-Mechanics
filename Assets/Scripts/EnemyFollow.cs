using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class EnemyFollow : MonoBehaviour
{
    public float followSpeed;
    private Rigidbody enemyRb;
    private GameObject player;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookDirection = (player.transform.position - transform.position).normalized ;
        enemyRb.AddForce(LookDirection * followSpeed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

}
