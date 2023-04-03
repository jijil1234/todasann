using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int MoveSpeed = 8;
    public GameObject tama;
    public GameObject fireposition;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private EnemySpawn enemyspawn;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = (AudioClip)Resources.Load("ショット");
        enemyspawn = EnemySpawn.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        if(transform.position.y + y>= 4.55 || transform.position.y + y <= -4.55)
        {
            Debug.Log("JJJJJ");
            return;
        }

        if(transform.position.x + x >= 8.5 || transform.position.x + x <= -8.5)
        {
            Debug.Log("BBBBB");
            return;
        }
        transform.position += new Vector3(x, y, 0);
    }

    private void Shot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(tama, fireposition.transform.position, transform.rotation);
            audioSource.PlayOneShot(audioClip);
        }
    }

    private void OnDestroy()
    {
        enemyspawn.flg = false;
    }
}
