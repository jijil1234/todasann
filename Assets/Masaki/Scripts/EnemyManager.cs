using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private int Speed = 5;
    [SerializeField]
    private int FireRate;
    public GameObject Enemytama;
    public GameObject fireposition;

    private void Start()
    {
        Shot();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyEnemy();
    }

    private void Move()
    {
        transform.position += new Vector3(-Speed, 0, 0) * Time.deltaTime;
    }

    private void DestroyEnemy()
    {
        if (this.transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void Shot()
    {
        Instantiate(Enemytama, fireposition.transform.position, transform.rotation);
        //audiosource.PlayOneShot(audioclip[0]);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}