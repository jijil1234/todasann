using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytama : MonoBehaviour
{
    [SerializeField]
    private int Speed = 7;
    private int FireRate;

    // Update is called once per frame
    void Update()
    {
        Move();
        Destroytama();
    }

    private void Move()
    {
        transform.position += new Vector3(-Speed, 0, 0) * Time.deltaTime;
    }

    private void Destroytama()
    {
        if (this.transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
