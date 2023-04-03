using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tama : MonoBehaviour
{
    private int Speed = 5;
    private int FireRate;
    private EnemySpawn enemySpawn;

    private void Start()
    {
        enemySpawn = EnemySpawn.instance;
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        Destroytama();
    }

    private void Move()
    {
        transform.position += new Vector3(Speed, 0, 0) * Time.deltaTime;
    }

    private void Destroytama()
    {
        if(this.transform.position.x>10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            enemySpawn.clear += 1;
        }

        else if(!collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}

